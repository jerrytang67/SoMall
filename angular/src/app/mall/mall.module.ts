import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MallRoutingModule } from './mall-routing.module';
import { ShopListComponent } from '../mall/components/shop-list/shop-list.component';
import { SpuListComponent } from '../mall/components/spu-list/spu-list.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { ShopSelectComponent } from '../visitor/components/shop-select/shop-select.component';


const COMPONENTS = [ShopListComponent]

const ENTRYCOMPONENTS = [ShopSelectComponent]

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS, SpuListComponent],
  imports: [
    CommonModule,
    MallRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class MallModule { }
