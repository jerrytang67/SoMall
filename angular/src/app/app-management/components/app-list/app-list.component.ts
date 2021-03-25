import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { AppProxyService } from 'src/api/appService';
import { EditAppComponent } from './edit-app.component';
import { AppsService } from '../../store/apps.service';
import { AppsQuery } from '../../store/apps.query';

@Component({
  selector: 'app-app-list',
  templateUrl: './app-list.component.html'
})
export class AppListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false
  };

  apps$ = this.appsQuery.selectAll();

  constructor(
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute,
    private api: AppProxyService,
    private appService: AppsService,
    private appsQuery: AppsQuery
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
    this.appService.getAll();
    this.pageingInfo.isTableLoading = false;
  }


  create(item: any) {
    const modal = this.modalService.create({
      nzTitle: '新建应用',
      // nzWidth: '40vw',
      nzContent: EditAppComponent,
      nzComponentParams: {
        form: {}
      },
      nzFooter: [
        {
          label: '确定',
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
            else {
              instance.f.ngSubmit.emit(null)
              this.message.error("表单错误")
            }
          }
        }
      ]
    });
  }
  edit(item: any) {
    const modal = this.modalService.create({
      nzTitle: '编辑应用',
      // nzWidth: '40vw',
      nzContent: EditAppComponent,
      nzComponentParams: {
        form: Object.assign({}, item)
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.api.update({
                id: item.id,
                body: instance.form
              }).subscribe(res => {
                this.message.success("修改成功");
                this.refresh();
                modal.destroy();
              })
            }
            else {
              instance.f.ngSubmit.emit(null)
              this.message.error("表单错误")
            }
          }
        }
      ]
    });
  }
  delete(item: any) {
    this.api.delete({ id: item.id }).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    });
  }

}