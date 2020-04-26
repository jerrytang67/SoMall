import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuthGuard } from '@core/auth-guard.service';
import { ShopListComponent } from './components/shop-list/shop-list.component';
import { SpuListComponent } from './components/spu-list/spu-list.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { SpuEditComponent } from './components/spu-edit/spu-edit.component';
import { AddressListComponent } from './components/addresses/address-list.component';
import { MallUserListComponent } from './components/users/user-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { CouponListComponent } from './components/coupon-list/coupon-list.component';
import { UserCouponListComponent } from './components/userCoupon-list/userCoupon-list.component';
import { PartnerListComponent } from './components/partner-list/partner-list.component';
import { RealNameInfoListComponent } from '../account-management/components/realNameInfo-list/realNameInfo-list.component';
import { PayOrderListComponent } from './components/payOrder-list/payOrder-list.component';
import { SwiperListComponent } from './components/swiper-list/swiper-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'shops', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'shops', component: ShopListComponent, data: { title: '商铺', permission: 'Pages' } },
      { path: 'categories', component: CategoryListComponent, data: { title: '商品分类', permission: 'Pages' } },
      { path: 'spus', component: SpuListComponent, data: { title: '商品列表', permission: 'Pages' } },
      { path: 'spu-edit/:id', component: SpuEditComponent, data: { title: '修改商品', permission: 'Pages' } },
      { path: 'spu-create/:categoryId', component: SpuEditComponent, data: { title: '添加商品', permission: 'Pages' } },
      { path: 'spu-create', component: SpuEditComponent, data: { title: '添加商品', permission: 'Pages' } },
      { path: 'addresses', component: AddressListComponent, data: { title: '用户地址列表', permission: 'Pages' } },
      { path: 'users', component: MallUserListComponent, data: { title: '商城用户列表', permission: 'Pages' } },
      { path: 'orders', component: OrderListComponent, data: { title: '订单列表', permission: 'Pages' } },
      { path: 'orders/:shopId', component: OrderListComponent, data: { title: '商家订单列表', permission: 'Pages' } },
      { path: 'coupons', component: CouponListComponent, data: { title: '优惠券列表', permission: 'Pages' } },
      { path: 'userCoupons', component: UserCouponListComponent, data: { title: '用户优惠券', permission: 'Pages' } },
      { path: 'userCoupons/:couponId', component: UserCouponListComponent, data: { title: '用户优惠券', permission: 'Pages' } },
      { path: 'partners', component: PartnerListComponent, data: { title: '用户优惠券', permission: 'Pages' } },
      { path: 'payOrders', component: PayOrderListComponent, data: { title: '支付请求列表', permission: 'Pages' } },
      { path: 'payOrders/:shopId', component: PayOrderListComponent, data: { title: '支付请求列表', permission: 'Pages' } },
      { path: 'swiper', component: SwiperListComponent, data: { title: '滚动广告', permission: 'Pages' } },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MallRoutingModule { }
