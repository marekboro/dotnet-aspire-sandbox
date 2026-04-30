import {
  Directive,
  ElementRef,
  HostListener,
  inject,
} from '@angular/core';
import { ServerService } from '../services/server.service';

@Directive({
  // selector: 'div[appHighlightfun]',
  selector: '[appHighlightfun]',
  standalone: true,
})
export class HighlightfunDirective {
  constructor(private el: ElementRef) {}

  service: ServerService = inject(ServerService);

  private highlight(color: string) {
    this.el.nativeElement.style.backgroundColor = color;
  }

  @HostListener('mouseenter') onMouseEnter() {
  
    if (this.el.nativeElement.tagName.toLowerCase() === 'p') {
      this.highlight('yellow');
    } else {
      this.highlight('green');
    }

    // this.service.numberBehaviourSubject$.next(1)
  }

  @HostListener('mouseleave') onMouseLeave() {

    this.highlight('');
  }
}
