import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuthGuard } from '@core/auth-guard.service';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { SpuListComponent } from './components/spu-list/spu-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'shops', pathMatch: 'full', data: { breadcrumb: "商城" } },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'shops', component: ShopListComponent, data: { title: '商铺', permission: 'Pages' } },
      { path: 'spus', component: SpuListComponent, data: { title: '商品列表', permission: 'Pages' } },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MallRoutingModule { }
