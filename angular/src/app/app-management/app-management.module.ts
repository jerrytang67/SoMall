import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppManagementRoutingModule } from './app-management-routing.module';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { AppListComponent } from './components/app-list/app-list.component';
import { EditAppComponent } from './components/app-list/edit-app.component';


const COMPONENTS = [AppListComponent]
const ENTRYCOMPONENTS = [EditAppComponent]

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    AppManagementRoutingModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class AppManagementModule { }
