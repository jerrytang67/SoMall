import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ActivatedRoute } from '@angular/router';
import { AddressProxyService } from 'src/api/appService';

@Component({
  selector: 'app-shop-list',
  templateUrl: './address-list.component.html'
})
export class AddressListComponent implements OnInit {

  formId: string;
  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private addressApi: AddressProxyService,
    private modalService: NzModalService,
    private message: NzMessageService,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe((params: any) => {
      console.log(params)
      this.formId = params.params.formid
      this.refresh();
    });

  }

  refresh() {
    this.pageingInfo.isTableLoading = true;
    this.addressApi.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }


  create() {
    const modal = this.modalService.create({
      nzTitle: '新建商家',
      nzWidth: 920,

      nzContent: AddressEditComponent,
      nzComponentParams: {
        form: {
          name: "",
          shortName: "",
          logoImage: "",
          coverImage: "",
          description: ""
        }
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            console.log("componentInstance", instance);
            if (instance.f.valid) {
              this.api.create({ body: instance.form }).subscribe(res => {
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
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }

}