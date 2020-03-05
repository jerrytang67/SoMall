import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { zip } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MenuService, SettingsService, TitleService, ALAIN_I18N_TOKEN } from '@delon/theme';
import { ACLService } from '@delon/acl';
import { NzIconService } from 'ng-zorro-antd';
import { ICONS_AUTO } from '../../../style-icons-auto';
import { ICONS } from '../../../style-icons';
import { TranslateService } from '@ngx-translate/core';

/**
 * 用于应用启动时
 * 一般用来获取应用所需要的基础数据等
 */
@Injectable()
export class StartupService {
  constructor(
    iconSrv: NzIconService,
    private menuService: MenuService,
    private settingService: SettingsService,
    private titleService: TitleService,
    private httpClient: HttpClient,
    private translate: TranslateService,

  ) {
    iconSrv.addIcon(...ICONS_AUTO, ...ICONS);

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
            // 应用信息：包括站点名、描述、年份
            this.settingService.setApp(res.app);
            // 用户信息：包括姓名、头像、邮箱地址
            this.settingService.setUser(res.user);
            // 初始化菜单
            this.menuService.add(res.menu);
            // 设置页面标题的后缀
            this.titleService.default = '';
            this.titleService.suffix = res.app.name;
          },
          () => { },
          () => {
            resolve(null);
          },
        );
    });
  }
}
