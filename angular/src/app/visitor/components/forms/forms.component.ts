import { Component, OnInit, } from '@angular/core';
import { FormProxyService, FormDto, FormTheme } from 'src/api/appService';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { FormEditComponent } from '../form-edit/form-edit.component';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html'
})
export class FormsComponent implements OnInit {
  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private api: FormProxyService,
    private modalService: NzModalService,
    private message: NzMessageService
  ) {

  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }

  create() {
    const modal = this.modalService.create({
      nzTitle: '新建表单',
      nzContent: FormEditComponent,
      nzComponentParams: {
        form: {
          title: "",
          description: "",
          theme: 0
        }
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.api.create({ body: instance.form }).subscribe(res => {
                this.message.success("新建成功");
                this.refresh();
                modal.destroy();
              })
            }
            else {
              instance.f.ngSubmit.emit(null)
              this.message.error("表单错误")
            }
          }
        }
      ]
    });
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }

  edit(form: FormDto) {
    const modal = this.modalService.create({
      nzTitle: '编辑表单',
      nzContent: FormEditComponent,
      nzComponentParams: {
        id: form.id!,
        form: { ...form }
      },
      nzFooter: [
        {
          label: '确定',
          type: "primary",
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.api.update({ id: instance.id, body: instance.form }).subscribe(res => {
                this.message.success("修改成功");
                this.refresh();
                modal.destroy();
              })
            }
          }
        }
      ]
    });
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }

  delete(shop: FormDto) {
    this.api.delete(shop).subscribe(res => {
      this.message.success("删除成功");
      this.refresh();
    })
  }
}
