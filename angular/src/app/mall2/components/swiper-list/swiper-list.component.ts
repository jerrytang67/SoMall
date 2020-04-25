import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { SwiperProxyService } from 'src/api/appService';

@Component({
  selector: 'app-swiper-list',
  templateUrl: './swiper-list.component.html'
})
export class SwiperListComponent implements OnInit {

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
    private api: SwiperProxyService
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

  guid = '00000000-0000-0000-0000-000000000000';
  create(item:any){
    this.api.getForEdit({ id: this.guid }).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '新建',
        nzContent: SwiperEditComponent,
        nzComponentParams: {
          form: { ...res.data }
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                this.api.create({
                  body: instance.form
                }).subscribe(res => {
                  this.message.success("新建成功");
                  this.refresh();
                  modal.destroy();
                })
              }
            }
          }
        ]
      });
    })
  }

  edit(item:any){
    this.api.getForEdit({ id: item.id }).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '编辑',
        nzContent: SwiperEditComponent,
        nzComponentParams: {
          id: item.id,
          form: { ...res.data }
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                this.api.update({
                  id: instance.id,
                  body: instance.form
                }).subscribe(res => {
                  this.message.success("编辑成功");
                  this.refresh();
                  modal.destroy();
                })
              }
            }
          }
        ]
      });
    })
  }
  delete(item:any){
    this.api.delete({ id: item.id }).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    })
  }
}