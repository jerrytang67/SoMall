import { Component, OnInit } from '@angular/core';
 import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { AddressProxyService } from 'src/api/appService';

@Component({
  selector: 'app-shop-list',
  templateUrl: './address-list.component.html'
})
export class AddressListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private addressApi: AddressProxyService,
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute
  ) {
  }
  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      //this.formId = params.params.formid
      this.refresh();
    });
  }
  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.addressApi.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }
}