import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';

import { ShopManagementRoutingModule } from './shop-management-routing.module';
import { ShopListComponent } from './components/shops/shop-list.component';
import { ShopEditComponent } from './components/shop-edit/shop-edit.component';

const COMPONENTS = [ShopListComponent, ShopEditComponent]

const ENTRYCOMPONENTS = [ShopEditComponent]

@NgModule({
  declarations: [...COMPONENTS],
  imports: [
    CommonModule,
    ShopManagementRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class ShopManagementModule { }
