import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-child',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css'],
})
export class ChildComponent implements OnInit {
  constructor() {}

  @Input() childName: string = '';

  ngOnInit(): void {}

  isInigo(): boolean {
    return this.childName == 'Inigo Montoya';
  }

  

  getMoreText(): string {
    return this.isInigo()==true ? ', you Killed my father, prepare to DIE!' : '';
  }

  @Output() onAction = new EventEmitter<string>();

  complain() {
    
    if (!this.isInigo()) {
      this.onAction.emit('But captain, we should be doing the other thing...');
    }

  }
}
