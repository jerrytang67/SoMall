import { Component, OnInit } from '@angular/core';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { TenantService } from '../../store/tenant.service';
import { CreateTenantComponent } from './create-tenant.component';
import { EditTenantComponent } from './edit-tenant.component';

@Component({
  selector: 'app-tenant-list',
  templateUrl: './tenant-list.component.html'
})
export class TenantListComponent implements OnInit {

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
    private tenantService: TenantService
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
    this.tenantService.getTenants({
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
    const modal = this.modalService.create({
      nzTitle: '新建租户',
      nzWidth: '40vw',
      nzContent: CreateTenantComponent,
      nzComponentParams: {
        form: {}
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.tenantService.createTenant(instance.form).subscribe(res => {
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
    this.tenantService.getTenant(item.id).subscribe(res => {
      const modal = this.modalService.create({
        nzTitle: '编辑租户',
        nzWidth: '40vw',
        nzContent: EditTenantComponent,
        nzComponentParams: {
          form: res
        },
        nzFooter: [
          {
            label: '确定',
            onClick: instance => {
              console.log("componentInstance", instance);
              if (instance.f.valid) {
                this.tenantService.updateTenant(item.id, instance.form).subscribe(res => {
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
    })
  }
  delete(item: any) {
    this.tenantService.deleteTenant(item.id).subscribe(() => {
      this.message.success("删除成功");
      this.refresh();
    })
  }

}