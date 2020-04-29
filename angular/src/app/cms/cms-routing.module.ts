import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { CategoryListComponent } from './components/category-list/category-list.component';
const routes: Routes = [
  { path: '', redirectTo: 'categories', pathMatch: 'full' },
  {
    path: '',
    component: LayoutComponent,
    // canActivate: [AuthGuard],
    children: [
      { path: 'categories', component: CategoryListComponent, data: { title: '商铺', permission: 'Pages' } },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CmsRoutingModule { }
