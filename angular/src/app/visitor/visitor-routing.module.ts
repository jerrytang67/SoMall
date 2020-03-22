import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '@core';
import { FormsComponent } from './components/forms/forms.component';
import { ShopFormsComponent } from './components/shopForms/shopForms.component';
import { VisitorlogListComponent } from './components/visitorlog-list/visitorlog-list.component';
import { LayoutComponent } from '../layout/layout.component';


const routes: Routes = [
  { path: '', redirectTo: 'forms', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'forms', component: FormsComponent, data: { title: '表单列表', permission: 'Pages' } },
      { path: 'shopForms/:formid', component: ShopFormsComponent, data: { title: '商家列表', permission: 'Pages' } },
      { path: 'visitorlog/:formid/:shopid', component: VisitorlogListComponent, data: { title: '访客记录', permission: 'Pages' } },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VisitorRoutingModule { }
