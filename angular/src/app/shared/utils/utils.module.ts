import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MomentFormatPipe } from './moment-format.pipe';
import { MomentFromNowPipe } from './moment-from-now.pipe';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
    ],
    declarations: [
        MomentFormatPipe,
        MomentFromNowPipe
    ],
    exports: [
        MomentFormatPipe,
        MomentFromNowPipe
    ]
})
export class UtilsModule { }
