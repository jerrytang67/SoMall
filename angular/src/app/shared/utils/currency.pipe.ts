import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'currency' })
export class CurrencyPipe implements PipeTransform {
    transform(value: number, length: number = 2) {
        if (!value) {
            return '';
        }
        return `¥${value.toFixed(length)}`
    }
}
