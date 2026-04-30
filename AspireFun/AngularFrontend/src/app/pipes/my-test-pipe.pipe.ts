import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'myTestPipe',
  standalone: true,
})
export class MyTestPipePipe implements PipeTransform {
  transform(value: number[], ...args: any[]): boolean {
    let zero = 0;
    if (args[0] == 'invert') {
      zero = 1;
    }

    if (!value) {
      return false;
    }

    return value.length % 2 == zero;
  }
}
