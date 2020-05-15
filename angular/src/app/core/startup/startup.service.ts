
//startup.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { NzIconService } from 'ng-zorro-antd';
import { Observable } from 'rxjs';

export interface Configuration {
  api: string;
}

@Injectable()
export class StartupService {
  constructor(
    private httpClient: HttpClient,
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
