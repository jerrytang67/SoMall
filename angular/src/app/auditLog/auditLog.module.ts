import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuditLogRoutingModule } from './auditLog-routing.module';
import { LayoutModule } from '../layout/layout.module';
import { SharedModule } from '@shared';
import { AuditLogListComponent } from './components/auditLog-list/auditLog-list.component';

const COMPONENTS = [AuditLogListComponent]
const ENTRYCOMPONENTS = []
@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    AuditLogRoutingModule,
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class AuditLogModule { }
