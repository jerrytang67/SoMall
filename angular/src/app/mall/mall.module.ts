import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MallRoutingModule } from './mall-routing.module';
import { ShopListComponent } from '../mall/components/shop-list/shop-list.component';
import { SpuListComponent } from '../mall/components/spu-list/spu-list.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { CategoryListComponent } from '../mall/components/category-list/category-list.component';
import { CategoryEditComponent } from '../mall/components/category-edit/category-edit.component';
import { SpuEditComponent } from '../mall/components/spu-edit/spu-edit.component';
import { AddressListComponent } from './components/addresses/address-list.component';
import { MallUserListComponent } from './components/users/user-list.component';
import { OrderListComponent } from './components/order-list/order-list.component';
import { CouponListComponent } from './components/coupon-list/coupon-list.component';
import { UserCouponListComponent } from './components/userCoupon-list/userCoupon-list.component';
import { PartnerListComponent } from './components/partner-list/partner-list.component';
import { PayOrderListComponent } from './components/payOrder-list/payOrder-list.component';
import { SwiperListComponent } from './components/swiper-list/swiper-list.component';
import { SwiperEditComponent } from './components/swiper-list/swiper-edit.component';


const COMPONENTS = [
  ShopListComponent,
  CategoryListComponent,
  SpuListComponent,
  SpuEditComponent,
  AddressListComponent,
  MallUserListComponent,
  OrderListComponent,
  CouponListComponent,
  UserCouponListComponent,
  PartnerListComponent,
  PayOrderListComponent,
  SwiperListComponent

]

const ENTRYCOMPONENTS = [CategoryEditComponent, SwiperEditComponent]

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    MallRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class MallModule { }
