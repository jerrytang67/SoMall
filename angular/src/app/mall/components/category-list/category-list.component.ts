import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ProductCategoryProxyService, ProductCategoryDto } from 'src/api/appService';
import { CategoryEditComponent } from '../category-edit/category-edit.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss']
})
export class CategoryListComponent implements OnInit {

  shopId: string = ""
  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false,
    sorting: "sort desc"
  };
  constructor(
    private api: ProductCategoryProxyService,
    private modalService: NzModalService,
    private message: NzMessageService
  ) {

  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList({
      shopId: this.shopId,
      maxResultCount: this.pageingInfo.pageSize,
      skipCount: (this.pageingInfo.pageNumber - 1) * this.pageingInfo.pageSize,
      sorting: this.pageingInfo.sorting
    }).subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }

  add() {
    const modal = this.modalService.create({
      nzTitle: '新建分类',
      nzContent: CategoryEditComponent,
      nzComponentParams: {
        form: {
          name: "",
          code: ""
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
              this.message.warning("表单错误")
            }
          }
        }
      ]
    });
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }

  edit(item: ProductCategoryDto) {
    const modal = this.modalService.create({
      nzTitle: '编辑分类',
      nzContent: CategoryEditComponent,
      nzComponentParams: {
        id: item.id,
        form: { ...item }
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

  delete(item: ProductCategoryDto) {
    this.api.delete(item).subscribe(res => {
      this.message.success("删除成功");
      this.refresh();
    })
  }
}
