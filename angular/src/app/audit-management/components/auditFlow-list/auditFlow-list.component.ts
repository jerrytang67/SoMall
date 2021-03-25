import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { AuditFlowProxyService } from 'src/api/appService';
import { AuditFlowEditComponent } from './auditFlow-edit.component';

@Component({
  selector: 'app-auditFlow-list',
  templateUrl: './auditFlow-list.component.html'
})
export class AuditFlowListComponent implements OnInit {

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
    private api: AuditFlowProxyService
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
  create(item: any) {
    this.api.getForEdit({ id: this.guid }).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '新建',
        nzContent: AuditFlowEditComponent,
        nzComponentParams: {
          form: { ...res.data },
          audits: res.schema.audits
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {

              console.log("componentInstance", instance);
              if (instance.f.valid) {
                instance.form.auditNodes = instance.lists.filter(x => x.length > 0).reduce((acc, cur, idx) => {
                  cur.forEach((_item: any) => {
                    acc.push(Object.assign({}, _item, { index: idx }))
                  })
                  return acc;
                }, [])

                if (!instance.form.auditNodes.length) {
                  this.message.error("审核节点不能为空")
                  return;
                }

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

  edit(item: any) {
    this.api.getForEdit({ id: item.id }).subscribe(res => {

      let _list = [];
      res.data!.auditNodes.forEach(r => {
        if (!_list[r.index]) { _list[r.index] = []; }
        _list[r.index].push(r);
      })

      const modal = this.modalService.create({
        nzTitle: '编辑',
        nzContent: AuditFlowEditComponent,
        nzWidth: 1200,
        nzComponentParams: {
          id: item.id,
          form: { ...res.data },
          audits: res.schema.audits,
          lists: _list
        },
        nzFooter: [
          {
            label: '确定',
            type: "primary",
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                instance.form.auditNodes = instance.lists.filter(x => x.length > 0).reduce((acc, cur, idx) => {
                  cur.forEach((_item: any) => {
                    acc.push(Object.assign({}, _item, { index: idx }))
                  })
                  return acc;
                }, [])
                if (!instance.form.auditNodes.length) {
                  this.message.error("审核节点不能为空")
                  return;
                }
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

  delete(item: any) {
    this.api.delete({ id: item.id }).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    })
  }
}