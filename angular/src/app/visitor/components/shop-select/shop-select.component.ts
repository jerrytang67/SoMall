import { Component, OnInit } from '@angular/core';
import { ShopProxyService, ShopDto } from 'src/api/appService';

@Component({
  selector: 'app-shop-select',
  templateUrl: './shop-select.component.html'
})
export class ShopSelectComponent implements OnInit {

  constructor(private api: ShopProxyService) { }

  dataItems: ShopDto[] = [];
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

  listOfSelection = [
    {
      text: 'Select All Row',
      onSelect: () => {
        this.checkAll(true);
      }
    },
    {
      text: 'Select Odd Row',
      onSelect: () => {
        this.listOfDisplayData.forEach((data, index) => (this.mapOfCheckedId[data.id] = index % 2 !== 0));
        this.refreshStatus();
      }
    },
    {
      text: 'Select Even Row',
      onSelect: () => {
        this.listOfDisplayData.forEach((data, index) => (this.mapOfCheckedId[data.id] = index % 2 === 0));
        this.refreshStatus();
      }
    }
  ];
  isAllDisplayDataChecked = false;
  isIndeterminate = false;
  listOfDisplayData: ShopDto[] = [];
  listOfAllData: ShopDto[] = [];
  mapOfCheckedId: { [key: string]: boolean } = {};
  refreshStatus(): void {
    this.isAllDisplayDataChecked = this.listOfDisplayData.every(item => this.mapOfCheckedId[item.id]);
    this.isIndeterminate =
      this.listOfDisplayData.some(item => this.mapOfCheckedId[item.id]) && !this.isAllDisplayDataChecked;
  }

  checkAll(value: boolean): void {
    this.listOfDisplayData.forEach(item => (this.mapOfCheckedId[item.id] = value));
    this.refreshStatus();
  }
}
