import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WindowApp } from '../../components/window-app/window-app';
import { AppWindow } from '../../interface/app/appWindow';
import { AppItem } from '../../interface/app/appItem';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    WindowApp
  ],
  templateUrl: './home.html',
  styleUrls: ['./home.scss']
})
export class Home {
  apps: AppItem[] = [
    {
      name: 'Clientes',
      icon: 'bi-people-fill',
      route: '/customers',
      width: 1000,
      height: 600,
    },
    { 
      name: 'Produtos',
      icon: 'bi-box-seam',
      route: '/products',
      width: 1000,
      height: 600,
    },
    { 
      name: 'Vendas',
      icon: 'bi-currency-dollar',
      route: '/sales',
      width: 1000,
      height: 600,
    },
    { 
      name: 'Relatórios',
      icon: 'bi-graph-up',
      route: '/reports',
      width: 1000,
      height: 600,
    },
    { 
      name: 'Configurações',
      icon: 'bi-gear-fill',
      route: '/settings',
      width: 1000,
      height: 600,
    },
    { 
      name: 'Importação de Dados',
      icon: 'bi-file-earmark-arrow-up-fill',
      route: '/data-import',
      width: 1000,
      height: 600,
    }
  ];

  openWindows: AppWindow[] = [];
  private zIndexCounter = 100;
  private idCounter = 0;

  openApp(app: AppItem) {
    console.log('Abrindo app:', app);
    const newWindow: AppWindow = {
      id: this.idCounter++,
      title: app.name,
      icon: app.icon,
      content: app.route,
      fullscreen: false,
      width: app.width,
      height: app.height,
      top: 50 + this.openWindows.length * 30,
      left: 50 + this.openWindows.length * 30,
      zIndex: this.zIndexCounter++
    };
    this.openWindows.push(newWindow);
  }

  closeWindow(id: number) {
    this.openWindows = this.openWindows.filter(w => w.id !== id);
  }

  bringToFront(win: AppWindow) {
    win.zIndex = this.zIndexCounter++;
  }

  toggleFullscreen(win: AppWindow) {
    win.fullscreen = !win.fullscreen;
    this.bringToFront(win);
  }
}
