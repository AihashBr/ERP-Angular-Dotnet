import { Component, Input, Output, EventEmitter, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppWindow } from '../../interface/app/appWindow';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-window-app',
  imports: [
    CommonModule
  ],
  templateUrl: './window-app.html',
  styleUrl: './window-app.scss'
})
export class WindowApp {
  @Input() window!: AppWindow;
  @Output() close = new EventEmitter<number>();
  @Output() bringToFront = new EventEmitter<AppWindow>();

  safeUrl!: SafeResourceUrl;

  isResizing = false;
  isDragging = false;
  startX = 0;
  startY = 0;
  startWidth = 0;
  startHeight = 0;
  startTop = 0;
  startLeft = 0;

  constructor(private sanitizer: DomSanitizer) {}

  ngOnChanges() {
    if (this.window?.content) {
      this.safeUrl = this.sanitizer.bypassSecurityTrustResourceUrl(this.window.content);
    }
  }

  closeWindow() {
    this.close.emit(this.window.id);
  }

  toggleFullscreen() {
    this.window.fullscreen = !this.window.fullscreen;
    this.bringToFront.emit(this.window);
  }

  startDrag(event: MouseEvent) {
    event.preventDefault();
    this.isDragging = true;
    this.startX = event.clientX;
    this.startY = event.clientY;
    this.startTop = this.window.top;
    this.startLeft = this.window.left;
    this.bringToFront.emit(this.window);
  }

  startResize(event: MouseEvent) {
    event.preventDefault();
    this.isResizing = true;
    this.startX = event.clientX;
    this.startY = event.clientY;
    this.startWidth = this.window.width;
    this.startHeight = this.window.height;
    this.bringToFront.emit(this.window);
  }

  @HostListener('document:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {
    if (this.isDragging) {
      this.window.top = this.startTop + (event.clientY - this.startY);
      this.window.left = this.startLeft + (event.clientX - this.startX);
    }
    if (this.isResizing) {
      this.window.width = this.startWidth + (event.clientX - this.startX);
      this.window.height = this.startHeight + (event.clientY - this.startY);
    }
  }

  @HostListener('document:mouseup')
  stopActions() {
    this.isDragging = false;
    this.isResizing = false;
  }

  onFocus() {
    this.bringToFront.emit(this.window);
  }
}
