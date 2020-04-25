import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MomentFormatPipe } from './moment-format.pipe';
import { MomentFromNowPipe } from './moment-from-now.pipe';
import { CurrencyPipe } from './currency.pipe';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
    ],
    declarations: [
        MomentFormatPipe,
        MomentFromNowPipe,
        CurrencyPipe
    ],
    exports: [
        MomentFormatPipe,
        MomentFromNowPipe,
        CurrencyPipe
    ]
})
export class UtilsModule { }
