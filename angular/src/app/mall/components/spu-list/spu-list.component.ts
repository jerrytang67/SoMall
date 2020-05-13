import { Component, OnInit } from '@angular/core';
import { ProductSpuProxyService, ProductSpuDto } from 'src/api/appService';
import { NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';

@Component({
  selector: 'app-spu-list',
  templateUrl: './spu-list.component.html'
})
export class SpuListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false,
    sorting: "id desc"
  };
  constructor(
    private api: ProductSpuProxyService,
    private message: NzMessageService,
    private router: Router
  ) {

  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.totalItems = res.totalCount;
      this.pageingInfo.isTableLoading = false;
    })
  }

  delete(item: ProductSpuDto) {
    this.api.delete({ id: item.id }).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    })
  }

  add() {
    this.router.navigate(["/mall/spu-create", ""])
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

  getQR(item: ProductSpuDto, appName: string) {
    this.api.getQr({
      body: {
        appName: appName,
        spuId: item.id
      }
    }).subscribe(res => {
      console.log(res);
    })
  }
}
