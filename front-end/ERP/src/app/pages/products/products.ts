import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [CommonModule], // necessário para *ngIf, *ngFor, etc
  templateUrl: './products.html',
  styleUrls: ['./products.scss']
})
export class Products {
  selected: string = '';

  select(option: string) {
    this.selected = option;
  }
}
