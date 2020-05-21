import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuditManagementRoutingModule } from './audit-management-routing.module';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { AuditFlowListComponent } from './components/auditFlow-list/auditFlow-list.component';
import { AuditFlowEditComponent } from './components/auditFlow-list/auditFlow-edit.component';


const COMPONENTS = [
  AuditFlowListComponent
]

const ENTRYCOMPONENTS = [
  AuditFlowEditComponent
]



@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    AuditManagementRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class AuditManagementModule { }
