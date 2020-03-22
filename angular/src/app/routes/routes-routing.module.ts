import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { environment } from '@env/environment';
// dashboard pages
import { DashboardAnalysisComponent } from './dashboard/analysis/analysis.component';
import { DashboardWorkplaceComponent } from './dashboard/workplace/workplace.component';
// single pages

import { UserLockComponent } from './passport/lock/lock.component';
import { Demo1Component } from './demo/demo1.component';
import { AuthGuard } from '@core/auth-guard.service';
import { Exception404Component } from './exception/404.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { LayoutComponent } from '../layout/layout.component';
import { MenuService } from '@core/menu/menu.service';
import { TranslatorService } from '@core/translator/translator.service';
import { menu } from './menu';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', redirectTo: 'dashboard/workplace', pathMatch: 'full' },
      { path: 'dashboard', redirectTo: 'dashboard/workplace', pathMatch: 'full' },
      // { path: 'dashboard/v1', component: DashboardV1Component },
      { path: 'dashboard/analysis', component: DashboardAnalysisComponent },
      // { path: 'dashboard/monitor', component: DashboardMonitorComponent },
      { path: 'dashboard/workplace', component: DashboardWorkplaceComponent }
    ],
  },
  { path: 'identity', loadChildren: () => import('../identity/identity.module').then(m => m.IdentityModule) },
  { path: 'shop-management', loadChildren: () => import('../shop-management/shop-management.module').then(m => m.ShopManagementModule) },
  { path: 'visitor', loadChildren: () => import('../visitor/visitor.module').then(m => m.VisitorModule) },
  {
    path: 'demo',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'demo1', component: Demo1Component, data: { title: 'demo1' },
      }
    ],
  },
  {
    path: 'exception',
    component: LayoutComponent,
    children: [
      {
        path: '404', component: Exception404Component, data: { title: '404' },
      }
    ],
  },
  // 单页不包裹Layout
  { path: 'auth-callback', component: AuthCallbackComponent },
  { path: 'lock', component: UserLockComponent, data: { title: '锁屏', titleI18n: 'app.lock' } },
  { path: '**', redirectTo: 'exception/404' },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: environment.useHash,
      // NOTICE: If you use `reuse-tab` component and turn on keepingScroll you can set to `disabled`
      // Pls refer to https://ng-alain.com/components/reuse-tab
      scrollPositionRestoration: 'top',
    }),
  ],
  exports: [RouterModule],
})
export class RouteRoutingModule {
  constructor(public menuService: MenuService, tr: TranslatorService) {
    menuService.addMenu(menu);
  }
}
