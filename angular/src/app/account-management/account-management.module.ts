import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountManagementRoutingModule } from './account-management-routing.module';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { WechatUserinfoListComponent } from './components/wechatUserinfo-list.component';

const COMPONENTS = [WechatUserinfoListComponent]
const ENTRYCOMPONENTS = []

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    SharedModule,
    LayoutModule,
    AccountManagementRoutingModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class AccountManagementModule { }
