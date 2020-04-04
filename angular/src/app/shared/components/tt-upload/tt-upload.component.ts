import { Component, OnInit, forwardRef, OnChanges, SimpleChanges, NgZone, Input, Output, EventEmitter } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { UploadFile, UploadXHRArgs } from 'ng-zorro-antd';
import { OssQuery } from 'src/store/oss/oss.query';
import { HttpRequest, HttpClient, HttpEvent, HttpResponse, HttpEventType } from '@angular/common/http';
@Component({
    selector: 'tt-upload',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => TtUploadComponent),
            multi: true,
        },
    ],
    template: `
<div class="clearfix">
    <nz-upload nzListType="picture-card" [(nzFileList)]="imgList" 
    [nzAction]="ossQuery.uploadUrl$ | async" [nzCustomRequest]="customReq" (nzChange)="handleChange($event)" [nzRemove]="handleRemove"
        [nzShowButton]="imgList.length < length" [nzShowUploadList]="showUploadList" [nzPreview]="handlePreview" >
        <i nz-icon nzType="plus"></i>
        <div class="ant-upload-text">{{ "upload" | translate}}</div>
    </nz-upload>
    <nz-modal [nzVisible]="previewVisible" [nzContent]="modalContent" [nzFooter]="null" (nzOnCancel)="previewVisible = false">
        <ng-template #modalContent>
            <img [src]="previewImage" [ngStyle]="{ width: '100%' }" />
        </ng-template>
    </nz-modal>
</div>
    `
})
export class TtUploadComponent implements OnChanges {

    _value: any;
    imgList: any[] = [];
    @Input() length = 1;
    @Input() previewVisible = false;
    @Output() change = new EventEmitter();
    /**
     * Constructor
     */
    constructor(
        private zone: NgZone,
        private http: HttpClient,
        public ossQuery: OssQuery) {
    }

    get value(): any {
        return this._value;
    }

    @Input()
    set value(v) {
        if (v !== this._value) {
            this._value = v;
            this.onChange(v);
        }
    }

    ngOnChanges(changes: SimpleChanges) {

    }

    /**
     * Value update process
     */
    updateValue(value: any) {
        this.zone.run(() => {
            this.value = value;
            this.onChange(value);
            this.onTouched();
            this.change.emit(value);
        });
    }

    /**
     * Implements ControlValueAccessor
     */
    writeValue(value: any) {
        this._value = value;
        if (this._value && this._value.length) {
            this.imgList = this._value.map(v => {
                return {
                    uid: v,
                    name: v,
                    status: 'done',
                    url: v,
                    thumbUrl: v,
                }
            });
        }
    }
    onChange(_: any) {
    }
    onTouched() {
    }
    registerOnChange(fn: any) {
        this.onChange = fn;
    }
    registerOnTouched(fn: any) {
        this.onTouched = fn;
    }


    showUploadList = {
        showPreviewIcon: true,
        showRemoveIcon: true,
        hidePreviewIconInNonImage: true
    };
    previewImage: string | undefined = '';

    handlePreview = (file: UploadFile) => {
        this.previewImage = file.url || file.thumbUrl;
        this.previewVisible = true;
        console.log(this.imgList)
    };


    customReq = (item: UploadXHRArgs) => {
        // Create a FormData here to store files and other parameters.
        const formData = new FormData();
        // tslint:disable-next-line:no-any
        formData.append('file', item.file.name);
        formData.append('file', item.file as any);
        formData.append('authorization', `UPYUN ${this.ossQuery.getValue().accessId}:${this.ossQuery.getValue().signature}`);
        formData.append('policy', this.ossQuery.getValue().policy);

        const req = new HttpRequest('POST', item.action!, formData, {
            reportProgress: true,
            withCredentials: false
        });
        // Always returns a `Subscription` object. nz-upload would automatically unsubscribe it at correct time.
        return this.http.request(req).subscribe(
            // tslint:disable-next-line no-any
            (event: HttpEvent<any>) => {
                if (event.type === HttpEventType.UploadProgress) {
                    if (event.total! > 0) {
                        // tslint:disable-next-line:no-any
                        (event as any).percent = (event.loaded / event.total!) * 100;
                    }
                    item.onProgress!(event, item.file!);
                } else if (event instanceof HttpResponse) {
                    item.onSuccess!(event.body, item.file!, event);
                }
            },
            err => {
                item.onError!(err, item.file!);
            }
        );
    };

    handleChange(e) {
        // console.log(e);
        // console.log(this.value);
        // console.log(this._value);
        if (e.type === "success") {
            const url = e.file.response.url;
            this.updateValue([...this._value, `http://img.somall.top${url}`])
            //this.change.emit([...this._value, `http://img.somall.top${url}!w500`]);
        }
    }

    handleRemove = (item: any) => {
        console.log(item, this.value)
        this.updateValue([...this._value.filter(x => x !== item.uid)])
    }
}