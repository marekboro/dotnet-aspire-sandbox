import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HighlightfunDirective } from 'src/app/directives/highlightfun.directive';
import { ServerService } from 'src/app/services/server.service';
import { RouterModule } from '@angular/router';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { CommonModule } from '@angular/common';
import { MyTestPipePipe } from 'src/app/pipes/my-test-pipe.pipe';
import { BoolToStringPipe } from 'src/app/pipes/bool-to-string.pipe';
import { ParentComponent } from "../parent/parent.component";

@Component({
  selector: 'app-dbtc',
  standalone: true,
  templateUrl: './dbtc.component.html',
  // imports: [NgIf, AsyncPipe, HighlightfunDirective, FormsModule],
  imports: [RouterModule, HighlightfunDirective, FormsModule, CommonModule, MyTestPipePipe, BoolToStringPipe, ParentComponent],
  styleUrls: ['./dbtc.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DbtcComponent implements OnInit {
  testData1: number = 0;
  testData2: number = 1;
  testData3: number = 0;
  testData4: number = 4;
  isDisabled = true;
  textFromInput: string = '';
  constructor() {}

  ngOnInit(): void {}

  private service: ServerService = inject(ServerService);

  inputLength$: BehaviorSubject<number | null> =
    this.service.numberBehaviourSubject$;

  lenghts: number[] = [];
  inputLengthAsObservable$: Observable<number | null> = this.inputLength$
    .asObservable()
    .pipe(
      tap((v) => {
        if (v != null) {
          this.lenghts = [...this.lenghts, v]
        }
        return v;
      }),
    );

  clickFunction() {
    this.isDisabled = !this.isDisabled;
    this.testData1 += 1;
    if (this.isDisabled) {
      this.service.numberBehaviourSubject$.next(this.textFromInput.length);
    }
  }

  mouseOverFunction() {
    if (this.isDisabled) {
      this.testData3 += 1;
    } else {
      this.testData3 -= 1;
    }
  }

  getCharCount() {
    return this.textFromInput.length;
  }

  getColor(): string {
    let color = this.lenghts.length % 2 == 0 ? 'red' : 'blue';
    return color;
  }

  private classes = { classA: 'classA', classB: 'classB' };

  getClass(): string {
    let className =
      this.lenghts.length % 2 == 0 ? this.classes.classA : this.classes.classB;
    return className;
  }
}
