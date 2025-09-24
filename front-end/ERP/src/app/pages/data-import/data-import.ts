import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-data-import',
  imports: [
    CommonModule
  ],
  templateUrl: './data-import.html',
  styleUrl: './data-import.scss'
})
export class DataImport {
  selected: string = '';

  select(option: string) {
    this.selected = option;
  }
}