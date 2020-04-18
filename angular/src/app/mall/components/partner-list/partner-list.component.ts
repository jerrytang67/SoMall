import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { PartnerProxyService } from 'src/api/appService';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html'
})
export class PartnerListComponent implements OnInit {

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
    private api: PartnerProxyService
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


  create(item: any) {

  }
  edit(item: any) {

  }
  delete(item: any) {

  }

}