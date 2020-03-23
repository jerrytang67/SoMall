import { DomSanitizer, SafeHtml, SafeUrl } from '@angular/platform-browser';
import { ChangeDetectionStrategy, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { isEmpty } from '@core/utils/check';

export type ExceptionType = 403 | 404 | 500;

@Component({
    selector: 'exception',
    exportAs: 'exception',
    templateUrl: './exception.component.html',
    host: { '[class.exception]': 'true' },
    preserveWhitespaces: false,
    changeDetection: ChangeDetectionStrategy.OnPush,
    encapsulation: ViewEncapsulation.None,
})
export class ExceptionComponent implements OnInit, OnDestroy {
    @ViewChild('conTpl', { static: true }) private conTpl: ElementRef;

    _type: ExceptionType;
    locale: any = {};
    hasCon = false;

    _img: SafeUrl = '';
    _title: SafeHtml = '';
    _desc: SafeHtml = '';

    @Input()
    set type(value: ExceptionType) {
        const item = {
            403: {
                img: 'https://gw.alipayobjects.com/zos/rmsportal/wZcnGqRDyhPOEYFcZDnb.svg',
                title: '403',
            },
            404: {
                img: 'https://gw.alipayobjects.com/zos/rmsportal/KpnpchXsobRgLElEozzI.svg',
                title: '404',
            },
            500: {
                img: 'https://gw.alipayobjects.com/zos/rmsportal/RVRUAYdCGeYNBWoKiIwB.svg',
                title: '500',
            },
        }[value];

        if (!item) return;

        this.fixImg(item.img);
        this._type = value;
        this._title = item.title;
        this._desc = '';
    }

    private fixImg(src: string): void {
        this._img = this.dom.bypassSecurityTrustStyle(`url('${src}')`);
    }

    @Input()
    set img(value: string) {
        this.fixImg(value);
    }

    @Input()
    set title(value: string) {
        this._title = this.dom.bypassSecurityTrustHtml(value);
    }

    @Input()
    set desc(value: string) {
        this._desc = this.dom.bypassSecurityTrustHtml(value);
    }

    checkContent() {
        this.hasCon = !isEmpty(this.conTpl.nativeElement);
    }

    constructor(private dom: DomSanitizer) { }

    ngOnInit() {
        this.checkContent();
    }

    ngOnDestroy() {
    }
}
