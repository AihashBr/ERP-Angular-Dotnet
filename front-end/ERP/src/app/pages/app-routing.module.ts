import { Routes } from '@angular/router';
import { Home } from './home/home';
import { Login } from './login/login';
import { DataImport } from './data-import/data-import';
import { Products } from './products/products';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },
  { path: 'home', component: Home },
  { path: 'data-import', component: DataImport},
  { path: 'products', component: Products},
  { path: '**', redirectTo: 'login' }
];