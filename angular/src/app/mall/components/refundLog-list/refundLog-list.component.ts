import { Component, OnInit } from '@angular/core';import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { RefundLogProxyService, RefundLogDto } from 'src/api/appService';

@Component({
  selector: 'app-refundLog-list',
  templateUrl: './refundLog-list.component.html'
})
export class RefundLogListComponent implements OnInit {

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
    private api: RefundLogProxyService
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

  view(item: RefundLogDto) {
    this.api.get({ id: item.id }).subscribe(res => {
      console.log(res);
    })
  }

  startAudit(item: RefundLogDto) {
    this.api.startAudit({
      body: {
        id: item.id
      }
    }).subscribe(() => {
      this.message.success("退款成功")
      this.refresh();
    })
  }


}