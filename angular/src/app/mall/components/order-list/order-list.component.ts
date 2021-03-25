import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { ProductOrderProxyService, ProductOrderDto } from 'src/api/appService';
import { AuthQuery } from 'src/store/auth/auth.query';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {

  dataItems: any[] = [];
  shopId: string = "";
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
    private api: ProductOrderProxyService,
    private authQuery: AuthQuery
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      if (params.params.shopId) {
        this.shopId = params.params.shopId
      }
      this.refresh();
    });
  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList({
      maxResultCount: this.pageingInfo.pageSize,
      skipCount: (this.pageingInfo.pageNumber - 1) * this.pageingInfo.pageSize,
      shopId: this.shopId,
      sorting: "id desc"
    }).subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.totalItems = res.totalCount;
      this.pageingInfo.isTableLoading = false;
    })
  }

  onCurrentPageDataChange(event: any): void {
    console.log(event)

  }

  view(item: any) {

  }


  refund(item: ProductOrderDto) {
    this.api.refund({
      body: {
        orderId: item.id,
        refundPrice: 0.01,
        reason: this.authQuery.user.name + " 操作退款"
      }
    }).subscribe(res => {
      this.refresh();
    })
  }
}