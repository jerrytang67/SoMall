import { Component, OnInit } from '@angular/core';
import { ProductSpuProxyService, ProductSpuDto } from 'src/api/appService';
import { NzMessageService } from 'ng-zorro-antd';
import { Router } from '@angular/router';

@Component({
  selector: 'app-spu-list',
  templateUrl: './spu-list.component.html',
  styleUrls: ['./spu-list.component.scss']
})
export class SpuListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
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
}
