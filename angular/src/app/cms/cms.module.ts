import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CmsRoutingModule } from './cms-routing.module';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { CategoryListComponent } from './components/category-list/category-list.component';
import { CategoryEditComponent } from './components/category-list/category-edit.component';

const COMPONENTS = [CategoryListComponent
]

const ENTRYCOMPONENTS = [
  CategoryEditComponent
]

@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    CmsRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class CmsModule { }

