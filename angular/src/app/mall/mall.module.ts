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
import { SpuCreateComponent } from '../mall/components/spu-create/spu-create.component';


const COMPONENTS = [ShopListComponent, CategoryListComponent, SpuListComponent, SpuEditComponent, SpuCreateComponent]

const ENTRYCOMPONENTS = [CategoryEditComponent]

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
