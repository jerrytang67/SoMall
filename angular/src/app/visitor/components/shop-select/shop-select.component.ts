import { Component, OnInit } from '@angular/core';
import { ShopProxyService, ShopDto } from 'src/api/appService';

@Component({
  selector: 'app-shop-select',
  templateUrl: './shop-select.component.html'
})
export class ShopSelectComponent implements OnInit {

  constructor(private api: ShopProxyService) { }

  dataItems: ShopDto[] = [];
  checkedList: ShopDto[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false
  };

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.api.getList(
      {
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

  isIndeterminate = false;
  listOfDisplayData: ShopDto[] = [];

  mapOfCheckedId: { [key: string]: boolean } = {};

  checked(item, event) {
    console.log(item, event);

    item.checked = event;
    //@ts-ignore
    this.checkedList = this.dataItems.filter(x => x.checked === true);
  }

}
