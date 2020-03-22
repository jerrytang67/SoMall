import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { zip } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NzIconService } from 'ng-zorro-antd';
import { TranslateService } from '@ngx-translate/core';

/**
 * 用于应用启动时
 * 一般用来获取应用所需要的基础数据等
 */
@Injectable()
export class StartupService {
  constructor(
    iconSrv: NzIconService,
    private httpClient: HttpClient,
    private translate: TranslateService,

  ) {
  }

  load(): Promise<any> {
    // only works with promises
    // https://github.com/angular/angular/issues/15088
    return new Promise(resolve => {
      zip(
        this.httpClient.get('assets/tmp/app-data.json'),
      )
        .pipe(
          // 接收其他拦截器后产生的异常消息
          catchError(([appData]) => {
            resolve(null);
            return [appData];
          }),
        )
        .subscribe(
          ([appData]) => {
            // setting language data
            this.translate.use('zh-CN');
            // application data
            const res: any = appData;
          },
          () => { },
          () => {
            resolve(null);
          },
        );
    });
  }
}
