import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuditFlowListComponent } from './components/auditFlow-list/auditFlow-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'auditFlows', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'auditFlows', component: AuditFlowListComponent, data: { title: '审核流程列表', permission: 'Pages' } },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuditManagementRoutingModule { }
