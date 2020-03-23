import { DomSanitizer, SafeHtml, SafeUrl } from '@angular/platform-browser';
import { ChangeDetectionStrategy, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { isEmpty } from '@core/utils/check';

export type ExceptionType = 403 | 404 | 500;

@Component({
    selector: 'se',
    exportAs: 'se',
    templateUrl: './se.component.html',
    host: { '[class.se]': 'true' },
    preserveWhitespaces: false,
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None,
})
export class ExceptionComponent implements OnInit, OnDestroy {

    @ViewChild('conTpl', { static: true }) private conTpl: ElementRef;

    _label: string;
    _error: string;

    @Input()
    set label(value: string) { this._label = value }

    @Input()
    set error(value: string) { this._error = value; }

    constructor(private dom: DomSanitizer) { }

    ngOnInit() {
    }

    ngOnDestroy() {
    }
}
