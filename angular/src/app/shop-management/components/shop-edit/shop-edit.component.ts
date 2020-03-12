import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { UpdateShopDto } from 'src/api/appService';
import { NgForm, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-shop-edit',
  templateUrl: './shop-edit.component.html',
  styles: [
    `
      .avatar {
        width: 128px;
        height: 128px;
      }
      .upload-icon {
        font-size: 32px;
        color: #999;
      }
      .ant-upload-text {
        margin-top: 8px;
        color: #666;
      }
    `
  ]
})
export class ShopEditComponent implements OnInit {
  @ViewChild('f', { static: true }) f: NgForm;

  @Input() title: string;

  @Input() id: string;

  @Input() form: UpdateShopDto;
  i: any = {};

  constructor() { }
  ngOnInit() {
  }
  beforeUpload(e: any) {
    console.log(e);
  }

  handleChange(e) {
    console.log(e);
  }

  onSubmit(f: NgForm) { }
}
