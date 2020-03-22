import { NgModule, Optional, SkipSelf, ModuleWithProviders } from '@angular/core';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { HttpClientModule } from '@angular/common/http';
import { AuthGuard } from './auth-guard.service';
import { AuthService } from 'src/store/auth.service';


@NgModule({
  imports: [
    HttpClientModule,
  ],
  entryComponents: [],
  declarations: [],
  exports: [],
  providers: [
    AuthService,
    AuthGuard,
  ],
})

export class CoreModule {
  static forRoot(): ModuleWithProviders<CoreModule> {
    return {
      ngModule: CoreModule,
      providers: [
      ]
    };
  }
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
