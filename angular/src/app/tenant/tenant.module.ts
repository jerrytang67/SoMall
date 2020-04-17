import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TenantRoutingModule } from './tenant-routing.module';
import { TenantListComponent } from './components/tenant-list/tenant-list.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';


const COMPONENTS = [TenantListComponent]
const ENTRYCOMPONENTS = []

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    TenantRoutingModule
  ]
  , entryComponents: [...ENTRYCOMPONENTS]
})
export class TenantModule { }
