import { NgModule } from '@angular/core';

import { RouteRoutingModule } from './routes-routing.module';
// dashboard pages
import { DashboardAnalysisComponent } from './dashboard/analysis/analysis.component';
import { DashboardMonitorComponent } from './dashboard/monitor/monitor.component';
import { DashboardWorkplaceComponent } from './dashboard/workplace/workplace.component';

// single pages
import { UserLockComponent } from './passport/lock/lock.component';
import { Demo1Component } from './demo/demo1.component';
import { Exception404Component } from './exception/404.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { SharedModule } from '@shared/shared.module';

const COMPONENTS = [
  DashboardAnalysisComponent,
  DashboardMonitorComponent,
  DashboardWorkplaceComponent,

  // oidc_callback
  AuthCallbackComponent,

  // single pages
  UserLockComponent,
  Exception404Component,
  Demo1Component
];
const COMPONENTS_NOROUNT = [];

@NgModule({
  imports: [SharedModule, RouteRoutingModule],
  declarations: [...COMPONENTS, ...COMPONENTS_NOROUNT],
  entryComponents: COMPONENTS_NOROUNT,
})
export class RoutesModule { }
