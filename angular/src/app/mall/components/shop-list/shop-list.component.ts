import { Component, OnInit } from '@angular/core';import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { ActivatedRoute } from '@angular/router';
import { MallShopProxyService, MallShopDto, WeixinProxyService } from 'src/api/appService';
import { ShopSelectComponent } from 'src/app/visitor/components/shop-select/shop-select.component';

@Component({
  selector: 'app-shop-list',
  templateUrl: './shop-list.component.html',
  styleUrls: ['./shop-list.component.scss']
})
export class ShopListComponent implements OnInit {

  formId: string;
  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 0,
    pageSize: 0,
    isTableLoading: false
  };
  constructor(
    private mallApi: MallShopProxyService,
    private weixinApi: WeixinProxyService,
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
    this.mallApi.getList().subscribe(res => {
      console.log(res);
      this.dataItems = res.items;
      this.pageingInfo.isTableLoading = false;
    })
  }

  addShop() {
    const modal = this.modalService.create({
      nzTitle: '添加商户',
      nzContent: ShopSelectComponent,
      nzComponentParams: {
        // form: {
        //   title: "",
        //   description: "",
        //   theme: FormTheme.red
        // }
      },
      nzFooter: [
        {
          label: '确定',
          onClick: instance => {
            if (instance.checkedList.length) {
              const shopIds = instance.checkedList.reduce((p, c) => { return [...p, c.id] }, [])
              this.mallApi.shopSync({
                body: {
                  shopIds
                }
              }).subscribe(() => {
                this.message.success("成功");
                this.refresh();
              })
            }
            modal.close();
          }
        }
      ]
    });
    modal.afterClose.subscribe(result => console.log('[afterClose] The result is:', result));
  }

  isVisible = false;
  qrSrc = "";
  qrTitle = "";

  getQr(shop: MallShopDto) {
    console.log(shop);
    this.qrSrc = "";
    this.qrTitle = `${shop.name} 小程序码`;
    this.weixinApi.getUnLimitQr({ scene: `${shop.id}` }).subscribe(res => {
      console.log(res);
      this.qrSrc = `http://${res.url}`;
      this.isVisible = true;
    })
  }

  handleCancel() { this.isVisible = false; }

}

