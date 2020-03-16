import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VisitorRoutingModule } from './visitor-routing.module';
import { FormsComponent } from './components/forms/forms.component';
import { SharedModule } from '@shared';
import { LayoutModule } from '../layout/layout.module';
import { FormEditComponent } from './components/form-edit/form-edit.component';
import { ShopFormsComponent } from './components/shopForms/shopForms.component';


const COMPONENTS = [FormsComponent, ShopFormsComponent, FormEditComponent]

const ENTRYCOMPONENTS = [FormEditComponent]


@NgModule({
  declarations: [...COMPONENTS, ...ENTRYCOMPONENTS],
  imports: [
    CommonModule,
    VisitorRoutingModule,
    SharedModule,
    LayoutModule
  ],
  entryComponents: [...ENTRYCOMPONENTS]
})
export class VisitorModule { }
