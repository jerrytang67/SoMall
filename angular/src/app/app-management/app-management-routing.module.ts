import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuthGuard } from '@core/auth-guard.service';
import { AppListComponent } from './components/app-list/app-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'apps', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'apps', component: AppListComponent, data: { title: '应用列表', permission: 'Pages' } }
    ],
  },
]



@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AppManagementRoutingModule { }
