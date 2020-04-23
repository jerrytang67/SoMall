import { Pipe, PipeTransform } from '@angular/core';
import * as moment from 'moment';

@Pipe({ name: 'momentFormat' })
export class MomentFormatPipe implements PipeTransform {
    transform(value: moment.MomentInput, format: string) {
        if (!value) {
            return '';
        }
        if (!format) {
            format = "YYYY-MM-DD"
        }
        return moment(value).locale(window.navigator.language).format(format);
    }
}
