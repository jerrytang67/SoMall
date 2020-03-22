import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutModule } from '../layout/layout.module';

import { ShopManagementRoutingModule } from './shop-management-routing.module';
import { ShopListComponent } from './components/shops/shop-list.component';
import { ShopEditComponent } from './components/shop-edit/shop-edit.component';
import { SharedModule } from '@shared/shared.module';

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
