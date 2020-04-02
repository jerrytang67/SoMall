import { Component, OnInit, Input, ViewChild, Injector, ElementRef } from '@angular/core';
import { VisitorShopCreateOrEditDto, OssProxyService } from 'src/api/appService';
import { NgForm } from '@angular/forms';
import base64 from '@core/utils/base64';
import { UploadXHRArgs } from 'ng-zorro-antd';
import { HttpRequest, HttpEvent, HttpEventType, HttpResponse, HttpClient } from '@angular/common/http';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import * as DecoupledEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { OssService } from 'src/store/oss/oss.service';
import { OssQuery } from 'src/store/oss/oss.query';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-shop-edit',
  templateUrl: './shop-edit.component.html',
  styleUrls: ['./shop-edit.component.scss']
})
export class ShopEditComponent implements OnInit {

  //public Editor = ClassicEditor;

  public Editor = DecoupledEditor;

  public onReady(editor) {
    editor.ui.getEditableElement().parentElement.insertBefore(
      editor.ui.view.toolbar.element,
      editor.ui.getEditableElement()
    );
  }

  @ViewChild('f', { static: true }) f: NgForm;

  @Input() title: string;

  @Input() id: string;

  @Input() form: VisitorShopCreateOrEditDto;

  i: any = {};

  uploadUrl$: Observable<string>;

  uploadData: any = {};
  action: string;
  constructor(private http: HttpClient,
    public ossQuery: OssQuery
  ) {
  }

  ngOnInit() {
    // this.uploadUrl$ = this.ossQuery.uploadUrl$;
  }


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
    console.log(e);
    if (e.type === "success") {
      const url = e.file.response.url;
      this.form.coverImage = `http://img.somall.top${url}!w500`
    }
  }

  handleChange2(e) {
    console.log(e);
    if (e.type === "success") {
      const url = e.file.response.url;
      this.form.logoImage = `http://img.somall.top${url}!w500`
    }
  }

  onSubmit(f: NgForm) { }

  ngOnDestroy(): void {
  };

}
