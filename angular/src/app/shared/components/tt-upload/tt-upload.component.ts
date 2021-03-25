import { Component, OnInit, forwardRef, OnChanges, SimpleChanges, NgZone, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzUploadFile, NzUploadXHRArgs, NzUploadComponent } from 'ng-zorro-antd/upload';

import { OssQuery } from 'src/store/oss/oss.query';
import { HttpRequest, HttpClient, HttpEvent, HttpResponse, HttpEventType } from '@angular/common/http';
import { OssService } from 'src/store/oss/oss.service';
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
    <nz-upload #host nzListType="picture-card" [(nzFileList)]="imgList" [customSuffix]="'!'"
    [nzAction]="ossQuery.uploadUrl$ | async" [nzCustomRequest]="customReq" (nzChange)="handleChange($event)" [nzRemove]="handleRemove"
        [nzShowButton]="imgList.length < length" [nzShowUploadList]="showUploadList" [nzPreview]="handlePreview" [nzPreviewIsImage]="previewIsImage" >
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

    @ViewChild("host") upload: NzUploadComponent

    _value: any;
    imgList: any[] = [];
    @Input() length = 1;
    @Input() customSuffix: string = "!";
    @Input() thumbStr: string = "w500";
    @Input() previewVisible = false;
    @Output() change = new EventEmitter();
    /**
     * Constructor
     */
    constructor(
        private zone: NgZone,
        private http: HttpClient,
        public ossQuery: OssQuery,
        public ossService: OssService) {
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


    createNew(v): NzUploadFile {
        return {
            uid: v,
            name: v,
            status: 'done',
            url: v,
            thumbUrl: v,
            isImageUrl: true
        }
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
            if (this.length > 1) {
                this.imgList = this._value.map(v => {
                    return this.createNew(v)
                });
            } else {
                this.imgList = [this.createNew(value)]
            }
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

    handlePreview = (file: NzUploadFile) => {
        this.previewImage = file.url || file.thumbUrl;
        this.previewVisible = true;
        console.log(this.imgList)
    };

    previewIsImage = (file: NzUploadFile) => {
        return true;
    }


    customReq = (item: NzUploadXHRArgs) => {
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
            debugger;
            const url = e.file.response.url;
            const v = `${this.ossQuery.getValue().domainHost}${url}${this.customSuffix}${this.customSuffix ? this.thumbStr : ''}`;
            if (this.length > 1)
                this.updateValue([...this._value || [], v])
            else
                this.updateValue(v);
            this.imgList.pop();
            this.imgList = [...this.imgList, this.createNew(v)];
        }
    }

    handleRemove = (item: any) => {
        console.log(item, this.value)
        if (this.length > 1) {
            this.updateValue([...this._value.filter(x => x !== item.uid)])
            this.imgList = this.imgList.filter(x => x.uid != item.uid)
        }
        else {
            this.updateValue([]);
            this.imgList = [];
        }

    }
}