import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { ProductOrderProxyService } from 'src/api/appService';

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
    private api: ProductOrderProxyService
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
      sorting:"id desc"
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
  create(item: any) {

  }

  edit(item: any) {

  }

  delete(item: any) {

  }
}