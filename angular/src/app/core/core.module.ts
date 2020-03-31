import { NgModule, Optional, SkipSelf } from '@angular/core';

import { SettingsService } from './settings/settings.service';
import { ThemesService } from './themes/themes.service';
import { TranslatorService } from './translator/translator.service';
import { MenuService } from './menu/menu.service';

import { throwIfAlreadyLoaded } from './module-import-guard';

import { AuthGuard } from './auth-guard.service';
import { AuthService } from 'src/store/auth/auth.service';

@NgModule({
  imports: [
  ],
  providers: [
    SettingsService,
    ThemesService,
    TranslatorService,
    MenuService,
    AuthGuard,
    AuthService
  ],
  declarations: [
  ],
  exports: [
  ]
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
