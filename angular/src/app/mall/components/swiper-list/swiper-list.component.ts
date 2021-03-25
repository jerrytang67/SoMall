import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';

import { ActivatedRoute } from '@angular/router';
import { SwiperProxyService } from 'src/api/appService';
import { SwiperEditComponent } from './swiper-edit.component';
import { getRndAppColor } from '@core/utils/radomAppColor';
@Component({
  selector: 'app-swiper-list',
  templateUrl: './swiper-list.component.html'
})
export class SwiperListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false,
    sorting: "sort desc"
  };
  constructor(
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute,
    private api: SwiperProxyService
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
      sorting: this.pageingInfo.sorting,
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
        nzContent: SwiperEditComponent,
        nzComponentParams: {
          form: { ...res.data },
          apps: res.schema.apps
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
        nzContent: SwiperEditComponent,
        nzComponentParams: {
          id: item.id,
          form: { ...res.data },
          apps: res.schema.apps
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