import { Component, ChangeDetectionStrategy, OnInit, ChangeDetectorRef } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';
import { yuan } from '@shared';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard-analysis',
  templateUrl: './analysis.component.html',
  // styleUrls: ['./analysis.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardAnalysisComponent implements OnInit {
  constructor(
    private http: HttpClient,
    public msg: NzMessageService,
    private cdr: ChangeDetectorRef,
  ) { }
  data: any = {};
  loading = true;
  date_range: Date[] = [];
  rankingListData: any[] = Array(7)
    .fill({})
    .map((item, i) => {
      return {
        title: "app.analysis.test",
        total: 323234,
      };
    });
  titleMap = {
    y1: "app.analysis.traffic",
    y2: "app.analysis.payments"
  };

  salesType = 'all';
  salesPieData: any;
  salesTotal = 0;

  saleTabs: any[] = [{ key: 'sales', show: true }, { key: 'visits' }];

  offlineIdx = 0;

  ngOnInit() {

  }

  setDate(type: any) {
    setTimeout(() => this.cdr.detectChanges());
  }

  changeSaleType() {
    this.salesPieData =
      this.salesType === 'all'
        ? this.data.salesTypeData
        : this.salesType === 'online'
          ? this.data.salesTypeDataOnline
          : this.data.salesTypeDataOffline;
    if (this.salesPieData) {
      this.salesTotal = this.salesPieData.reduce((pre, now) => now.y + pre, 0);
    }
    this.cdr.detectChanges();
  }

  handlePieValueFormat(value: any) {
    return yuan(value);
  }
  salesChange(idx: number) {
    if (this.saleTabs[idx].show !== true) {
      this.saleTabs[idx].show = true;
      this.cdr.detectChanges();
    }
  }
  offlineChange(idx: number) {
    if (this.data.offlineData[idx].show !== true) {
      this.data.offlineData[idx].show = true;
      this.cdr.detectChanges();
    }
  }
}
