import { Component, OnInit, ViewChildren, ViewChild, TemplateRef, ViewContainerRef, HostListener, QueryList, ElementRef } from '@angular/core';
import { ProductSpuProxyService, ProductSpuDto } from 'src/api/appService';
import {  NzModalService } from 'ng-zorro-antd/modal';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Router } from '@angular/router';
import { Overlay, CdkOverlayOrigin, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal, TemplatePortal } from '@angular/cdk/portal';

@Component({
  selector: 'app-spu-list',
  templateUrl: './spu-list.component.html',
  styleUrls: ['./spu-list.component.scss']
})
export class SpuListComponent implements OnInit {

  dataItems: any[] = [];
  pageingInfo = {
    totalItems: 0,
    pageNumber: 1,
    pageSize: 10,
    isTableLoading: false,
    sorting: "id desc"
  };
  constructor(
    private api: ProductSpuProxyService,
    private message: NzMessageService,
    private router: Router,
    public overlay: Overlay,
    private viewContainerRef: ViewContainerRef
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
      this.pageingInfo.totalItems = res.totalCount;
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

  colorList: string[] = ["magenta", "green", "volcano", "blue", "orange", "#2db7f5", "#87d068", "#108ee9", "#f50",]
  appList: string[] = []

  getRndColor(str) {
    if (this.appList.indexOf(str) > -1) {
      return this.colorList[this.appList.indexOf(str)];
    }
    else {
      this.appList.push(str);
      return this.colorList[this.appList.indexOf(str)];
    }
  }

  getQR(item: ProductSpuDto, appName: string, row: any) {
    this.api.getQr({
      body: {
        appName: appName,
        spuId: item.id
      }
    }).subscribe(res => {
      console.log(res);
      this.qrSrc = res.qrImageUrl;
      this.showOverlay(row);
    })
  }

  @ViewChild('overlay') overlayTemplate: TemplateRef<any>;
  // @ViewChildren('row') rows: QueryList<ElementRef>;
  qrSrc = "";

  overlayRef: OverlayRef;

  showOverlay(nzTag) {
    if (!this.overlayRef) {
      this.overlayRef = this.overlay.create({
        positionStrategy: this.overlay.position()
          .connectedTo(nzTag.elementRef,
            { originX: 'end', originY: 'bottom' },
            { overlayX: 'end', overlayY: 'top' }
          ),
        //.global().centerHorizontally().centerVertically(),
        scrollStrategy: this.overlay.scrollStrategies.reposition(),
        hasBackdrop: true
      });
      this.overlayRef.attach(new TemplatePortal(this.overlayTemplate, this.viewContainerRef));
      this.overlayRef.backdropClick().subscribe(() => { this.close() });
    }
  }

  close() {
    this.overlayRef.dispose();
    this.overlayRef = null;
  }

  @HostListener('window:resize')
  public onResize(): void {
    this.overlayRef.updatePosition();
  }
}
