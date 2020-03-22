import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ToastrModule } from 'ngx-toastr';
import { ColorsService } from './colors/colors.service';

// #region third libs
import { NgZorroAntdModule } from 'ng-zorro-antd';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';

// ngx-bootstrap
import { TooltipModule } from 'ngx-bootstrap/tooltip';


const BSMODULES = [TooltipModule.forRoot(), ToastrModule.forRoot()]

const THIRDMODULES = [NgZorroAntdModule, CKEditorModule];
// #endregion

// #region your componets & directives
const COMPONENTS = [];
const DIRECTIVES = [];
// #endregion

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    // third libs
    ...THIRDMODULES,
    ...BSMODULES
  ],
  providers: [
    ColorsService
  ],
  declarations: [
    // your components
    ...COMPONENTS,
    ...DIRECTIVES,
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    // i18n
    TranslateModule,
    // third libs
    ...THIRDMODULES,
    // your components
    ...COMPONENTS,
    ...DIRECTIVES,
  ],
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule
    };
  }
}
