import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { CategoryEditComponent } from './category-edit.component';
import { CmsCategoryProxyService, CategoryDto } from 'src/api/appService';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html'
})
export class CategoryListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false
  };
  constructor(
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute,
    private api: CmsCategoryProxyService
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.refresh();
    });

  }
  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList({
      maxResultCount: this.pageingInfo.pageSize,
      skipCount: (this.pageingInfo.pageNumber - 1) * this.pageingInfo.pageSize
    }).subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.totalItems = res.totalCount;
      this.pageingInfo.isTableLoading = false;
    })
  }

  guid = '00000000-0000-0000-0000-000000000000';
  create(item: any) {
    this.api.getForEdit({ id: this.guid }).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '新建',
        nzContent: CategoryEditComponent,
        nzComponentParams: {
          form: { ...res.data }
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                this.api.create({
                  body: instance.form
                }).subscribe(res => {
                  this.message.success("新建成功");
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

  edit(item: any) {
    this.api.getForEdit({ id: item.id }).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '编辑',
        nzContent: CategoryEditComponent,
        nzComponentParams: {
          id: item.id,
          form: { ...res.data }
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
                  body: instance.form
                }).subscribe(res => {
                  this.message.success("编辑成功");
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
  delete(item: any) {
    this.api.delete({ id: item.id }).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    })
  }

  zan(item: CategoryDto) {
    this.api.dianZan({ id: item.id }).subscribe(() => {

      this.refresh();
    });


  }
}