import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'boolToString',
  standalone: true
})
export class BoolToStringPipe implements PipeTransform {
  transform(value: boolean, ...args: unknown[]): string {
    return value == true ? 'not true' : 'not false';
  }
}
