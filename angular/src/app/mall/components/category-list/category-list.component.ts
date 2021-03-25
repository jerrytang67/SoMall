import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ProductCategoryProxyService, ProductCategoryDto } from 'src/api/appService';
import { CategoryEditComponent } from '../category-edit/category-edit.component';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html'
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
    private message: NzMessageService,
    private translate: TranslateService
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
      this.pageingInfo.totalItems = res.totalCount;
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

    this.api.getForEdit({ id: item.id }).subscribe(res => {

      const modal = this.modalService.create({
        nzTitle: '编辑分类',
        nzContent: CategoryEditComponent,
        nzComponentParams: {
          id: item.id,
          form: { ...res.data },
          apps: res.schema.apps.map(p => {
            return {
              label: this.translate.instant(p.value),
              value: p.value,
              checked: res.data.appProductCategories.filter(x => x.appName === p.value).length > 0
            }
          })
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                this.api.update({
                  id: instance.id,
                  body: Object.assign({}, instance.form, { apps: instance.apps })
                }).subscribe(res => {
                  this.message.success("修改成功");
                  this.refresh();
                  modal.destroy();
                })
              }
            }
          }
        ]
      });
    })

  }

  delete(item: ProductCategoryDto) {
    this.api.delete(item).subscribe(res => {
      this.message.success("删除成功");
      this.refresh();
    })
  }

  colorList: string[] = ["magenta", "green", "volcano", "blue", "orange", "#2db7f5", "#87d068", "#108ee9", "#f50",]
  appList: string[] = []

  getRndColor(str) {
    if (this.appList.indexOf(str) > -1) {
      return this.colorList[this.appList.indexOf(str)];
    }
    else {
      this.appList.push(str);
      return this.colorList[this.appList.indexOf(str)];
    }
  }
}
