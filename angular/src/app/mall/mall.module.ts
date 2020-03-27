import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MallRoutingModule } from './mall-routing.module';
import { ShopListComponent } from '../mall/components/shop-list/shop-list.component';
import { SpuListComponent } from '../mall/components/spu-list/spu-list.component';


const COMPONENTS = [ShopListComponent]

const ENTRYCOMPONENTS = []

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS, SpuListComponent],
  imports: [
    CommonModule,
    MallRoutingModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class MallModule { }
