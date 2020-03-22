import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '@core';

import { ShopListComponent } from './components/shops/shop-list.component';
import { LayoutComponent } from '../layout/layout.component';

const routes: Routes = [
  { path: '', redirectTo: 'shop-list', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'shop-list', component: ShopListComponent, data: { title: '商家列表', permission: 'Pages' } }
    ]
  }
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShopManagementRoutingModule { }
