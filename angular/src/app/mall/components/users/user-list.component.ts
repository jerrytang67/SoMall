import { Component, OnInit } from '@angular/core'; 
import { NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { MallUserProxyService } from 'src/api/appService';

@Component({
  selector: 'app-shop-list',
  templateUrl: './user-list.component.html'
})
export class MallUserListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute,
    private userApi: MallUserProxyService
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      // this.formId = params.params.formid
      this.refresh();
    });

  }
  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.userApi.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }
}