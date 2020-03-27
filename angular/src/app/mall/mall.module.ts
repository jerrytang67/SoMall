import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MallRoutingModule } from './mall-routing.module';
import { ShopListComponent } from '../mall/components/shop-list/shop-list.component';
import { SpuListComponent } from '../mall/components/spu-list/spu-list.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { ShopSelectComponent } from '../visitor/components/shop-select/shop-select.component';
import { CategoryListComponent } from '../mall/components/category-list/category-list.component';
import { CategoryEditComponent } from '../mall/components/category-edit/category-edit.component';


const COMPONENTS = [ShopListComponent]

const ENTRYCOMPONENTS = [ShopSelectComponent, CategoryEditComponent]

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS, SpuListComponent, CategoryListComponent, CategoryEditComponent],
  imports: [
    CommonModule,
    MallRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class MallModule { }
