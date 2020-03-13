import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '@core';

import { LayoutDefaultComponent } from '../layout/default/default.component';
import { ShopListComponent } from './components/shops/shop-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'shop-list', pathMatch: 'full' },
  {
    path: '',
    component: LayoutDefaultComponent,
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
