import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ShopProxyService, VisitorShopDto } from 'src/api/appService';
import { ShopEditComponent } from '../shop-edit/shop-edit.component';

@Component({
  selector: 'app-users',
  templateUrl: './shop-list.component.html'
})
export class ShopListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private api: ShopProxyService,
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
      this.dataItems = res.items;
      this.pageingInfo.totalItems = res.totalCount;
      this.pageingInfo.isTableLoading = false;
    })
  }

  create() {
    const modal = this.modalService.create({
      nzTitle: '新建商家',
      nzWidth: 920,

      nzContent: ShopEditComponent,
      nzComponentParams: {
        form: {
          name: "",
          shortName: "",
          logoImage: "",
          coverImage: "",
          description: ""
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

  edit(shop: VisitorShopDto) {
    const modal = this.modalService.create({
      nzTitle: '编辑商家',
      nzWidth: '80vw',
      nzContent: ShopEditComponent,
      nzComponentParams: {
        id: shop.id!,
        form: { ...shop }
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
  delete(shop: VisitorShopDto) {
    this.api.delete(shop).subscribe(res => {
      this.message.success("删除成功");
      this.refresh();
    })
  }
}
