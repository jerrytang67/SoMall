import { NgModule, Optional, SkipSelf, ModuleWithProviders } from '@angular/core';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { OAuthStorage, OAuthModule, AuthConfig, OAuthModuleConfig, ValidationHandler, JwksValidationHandler } from 'angular-oauth2-oidc';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './auth.service';
import { authConfig } from './authConfig';
import { AuthGuard } from './auth-guard.service';
import { AuthGuardWithForcedLogin } from './auth-guard-with-forced-login.service';

// We need a factory since localStorage is not available at AOT build time
export function storageFactory(): OAuthStorage {
  return localStorage
}

export const authModuleConfig: OAuthModuleConfig = {
  resourceServer: {
    allowedUrls: ['https://demo.identityserver.io/api'],
    sendAccessToken: true,
  }
};



@NgModule({
  imports: [
    HttpClientModule,
    OAuthModule.forRoot(),
  ],
  providers: [
    AuthService,
    AuthGuard,
    AuthGuardWithForcedLogin,
  ],
})

export class CoreModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: CoreModule,
      providers: [
        { provide: AuthConfig, useValue: authConfig },
        { provide: OAuthModuleConfig, useValue: authModuleConfig },
        { provide: ValidationHandler, useClass: JwksValidationHandler },
        { provide: OAuthStorage, useFactory: storageFactory },
      ]
    };
  }
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    throwIfAlreadyLoaded(parentModule, 'CoreModule');
  }
}
