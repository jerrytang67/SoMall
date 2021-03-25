import { Component, OnInit } from '@angular/core';
import { VisitorLogProxyService, VisitorLogDto } from 'src/api/appService';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-visitorlog-list',
  templateUrl: './visitorlog-list.component.html'
})
export class VisitorlogListComponent implements OnInit {

  formId: string;
  shopId: string;
  dataItems: VisitorLogDto[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false
  };
  constructor(
    private api: VisitorLogProxyService,
    private message: NzMessageService,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.formId = params.params.formid
      this.shopId = params.params.shopid
      this.refresh();
    });

  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList(
      {
        shopId: this.shopId,
        formId: this.formId,
        maxResultCount: this.pageingInfo.pageSize,
        skipCount: (this.pageingInfo.pageNumber - 1) * this.pageingInfo.pageSize
      }
    ).subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.totalItems = res.totalCount;
      this.pageingInfo.isTableLoading = false;
    })
  }


  delete(item: VisitorLogDto) {
    this.message.error("不支付删除操作")
  }

  parseJson(str: string) { return JSON.parse(str) }
}
