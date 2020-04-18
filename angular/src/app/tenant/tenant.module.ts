import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TenantRoutingModule } from './tenant-routing.module';
import { TenantListComponent } from './components/tenant-list/tenant-list.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { CreateTenantComponent } from './components/tenant-list/create-tenant.component';
import { EditTenantComponent } from './components/tenant-list/edit-tenant.component';


const COMPONENTS = [TenantListComponent]
const ENTRYCOMPONENTS = [
  CreateTenantComponent,
  EditTenantComponent
]

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
