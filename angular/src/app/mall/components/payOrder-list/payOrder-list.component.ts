import { Component, OnInit } from '@angular/core';import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { PayOrderProxyService } from 'src/api/appService';

@Component({
  selector: 'app-payOrder-list',
  templateUrl: './payOrder-list.component.html'
})
export class PayOrderListComponent implements OnInit {

  dataItems: any[] = [];

  shopId: string = ""
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false,
    sorting: "id desc"
  };
  constructor(
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute,
    private api: PayOrderProxyService
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


  view(item: any) {
    this.api.get({ billNo: item.billNo }).subscribe(res => {
      console.log(res)
    })
  }

}