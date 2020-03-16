import { Component, OnInit } from '@angular/core';
import { FormProxyService, FormDto, WeixinProxyService } from 'src/api/appService';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { FormEditComponent } from '../form-edit/form-edit.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-shop-forms',
  templateUrl: './shopForms.component.html'
})
export class ShopFormsComponent implements OnInit {
  formId: string;
  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private api: FormProxyService,
    private weixinApi: WeixinProxyService,
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.formId = params.params.id
      this.refresh();
    });

  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getShops({ id: this.formId }).subscribe(res => {
      console.log(res);
      this.dataItems = res;
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
  getQr(shop: FormDto) {
    this.weixinApi.getUnLimitQr({ scene: `${shop.id}` }).subscribe(res => {
      console.log(res);

    })
  }
}
