import { Component, OnInit } from '@angular/core';import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { PartnerProxyService } from 'src/api/appService';

import { MapOptions, Point, BCircle, BMarker, BMapInstance, MarkerOptions } from 'angular2-baidu-map';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html'
})
export class PartnerListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 20,
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

  markers: Array<{ point: Point; options?: MarkerOptions; info?: { title: string; content: string } }>

  options: MapOptions;

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

      this.markers = res.items.map(item => {
        return {
          point: {
            lat: item.lat,
            lng: item.lng
          },
          info: {
            title: `${item.realName} ${item.phone}`,
            content: `${item.locationAddress}
            <br/>${item.locationLabel}`
          }
        }
      })
      this.options = {
        centerAndZoom: {
          lat: res.items[0].lat,
          lng: res.items[0].lng,
          zoom: 16
        },
        enableKeyboard: true
      }
    })
  }


  create(item: any) {

  }
  edit(item: any) {

  }
  delete(item: any) {

  }

}