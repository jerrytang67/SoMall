import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CKEditorComponent } from './ckeditor.component';
import { CKButtonDirective } from './ckbutton.directive';
import { CKGroupDirective } from './ckgroup.directive';

/**
 * CKEditorModule
 */
@NgModule({
  imports: [CommonModule],
  declarations: [CKEditorComponent, CKButtonDirective, CKGroupDirective],
  exports: [CKEditorComponent, CKButtonDirective, CKGroupDirective],
})
export class CKEditorModule {}
