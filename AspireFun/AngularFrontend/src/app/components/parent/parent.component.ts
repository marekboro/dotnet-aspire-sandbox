import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChildComponent } from '../child/child.component';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [CommonModule, ChildComponent],
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ParentComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  complaintResponseSubject: BehaviorSubject<string | null> =
    new BehaviorSubject<string | null>(null);
  complaintResponse$ = this.complaintResponseSubject.asObservable();

  handleEvent(message: string) {
    if (message.includes('But captain')) {
      this.complaintResponseSubject.next('Shut up Westley!!');
      setTimeout(() => this.complaintResponseSubject.next(null), 1000);
    }

    console.log(message); // Output: "Button was clicked in child!"
  }
}
