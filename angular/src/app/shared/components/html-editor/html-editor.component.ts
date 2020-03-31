// Imports
import {
    Component,
    Input,
    Output,
    ViewChild,
    EventEmitter,
    NgZone,
    forwardRef,
    SimpleChanges,
    OnChanges,
} from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
    selector: 'html-editor',
    providers: [
        {
            provide: NG_VALUE_ACCESSOR,
            useExisting: forwardRef(() => HtmlEditorComponent),
            multi: true,
        },
    ],
    template: `
    {{height}}
    {{_value}}
    <ckeditor  [config]="ckeConfig"  [(ngModule)]="_value" [name]="name" (fileUploadRequest)="onFileUploadRequest($event)"            (fileUploadResponse)="onFileUploadResponse($event)">
        </ckeditor>
    `,
})
export class HtmlEditorComponent implements OnChanges {
    @Input() height: number | string;
    @Input() name: string;

    @Output() change = new EventEmitter();

    ckeConfig: any = {
        uploadUrl: "https://v0.api.upyun.com/ttwork",
        allowedContent: false,
        forcePasteAsPlainText: true,
        // font_names: 'Arial;Times New Roman;Verdana',
        toolbar: [
            { name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', '-', 'Undo', 'Redo'] },
            { name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', '-', 'CopyFormatting', 'RemoveFormat'] },
            { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
            { name: 'insert', items: ['Image', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak'] },
            { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
            { name: 'colors', items: ['TextColor', 'BGColor'] },
            { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
            { name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', 'Preview', 'Print'] },
        ],
    };

    _value = '';
    _height: any;

    /**
     * Constructor
     */
    constructor(private zone: NgZone) {
        this.ckeConfig = { ...this.ckeConfig, height: this.height }
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
    }


    onChange(_: any) { }
    onTouched() { }
    registerOnChange(fn: any) {
        this.onChange = fn;
    }
    registerOnTouched(fn: any) {
        this.onTouched = fn;
    }

    private documentContains(node: Node) {
        return document.contains ? document.contains(node) : document.body.contains(node);
    }

    operator = "";
    signature = "";
    policy = "";


    onFileUploadRequest(evt) {
        console.log("onFileUploadRequest");
        let fileLoader = evt.data.fileLoader
        let formData = new FormData()
        formData.append('file', evt.data.fileLoader.file.name);
        formData.append('file', evt.data.fileLoader.file as any);
        formData.append('authorization', `UPYUN ${this.operator}:${this.signature}`);
        formData.append('policy', this.policy);
        fileLoader.xhr.send(formData);

        evt.stop();
    }

    onFileUploadResponse(evt) {
        console.log(evt)
        // Prevent the default response handler.
        evt.stop();
        // Get XHR and response.
        var data = evt.data,
            xhr = data.fileLoader.xhr,
            response = JSON.parse(xhr.responseText.split('|')[0]);
        console.log(response);
        if (response) {
            // An error occurred during upload.
            data.url = `http://img.somall.top${response.url}!w500`;
        }
        else {
            evt.cancel();
        }
    }

    onDrop(evt) {
        console.log(evt)
    }

    onPaste(evt) {
        console.log(evt)
    }

}
