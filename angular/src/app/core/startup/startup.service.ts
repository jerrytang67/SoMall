
//startup.service.ts
import { Injectable } from '@angular/core';
import { NzIconService } from 'ng-zorro-antd/icon';

export interface Configuration {
  api: string;
}

@Injectable()
export class StartupService {
  constructor(
    private iconSrv: NzIconService
  ) { }

  private _startupData: Configuration;

  load(): void {
    this.iconSrv.fetchFromIconfont({
      scriptUrl: '//at.alicdn.com/t/font_1821047_73t7ldovkio.js'
    });
  }

  get startupData(): Configuration {
    return this._startupData;
  }
}
