import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuthGuard } from '@core/auth-guard.service';
import { AuditLogListComponent } from './components/auditLog-list/auditLog-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'auditLogs', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'auditLogs', component: AuditLogListComponent, data: { title: '审计日志', permission: 'Pages' } },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuditLogRoutingModule { }
