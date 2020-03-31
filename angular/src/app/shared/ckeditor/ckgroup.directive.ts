import { Directive, Input, AfterContentInit, ContentChildren, QueryList } from '@angular/core';
import { CKEditorComponent } from './ckeditor.component';
import { CKButtonDirective } from './ckbutton.directive';

/**
 * CKGroup component
 * Usage :
 *  <ckeditor [(ngModel)]="data" [config]="{...}" debounce="500">
 *      <ckgroup [name]="'exampleGroup2'" [previous]="'1'" [subgroupOf]="'exampleGroup1'">
 *          .
 *          .
 *      </ckgroup>
 *   </ckeditor>
 */
@Directive({
  selector: 'ckgroup',
})
export class CKGroupDirective implements AfterContentInit {
  @Input() name: string;
  @Input() previous: any;
  @Input() subgroupOf: string;
  @ContentChildren(CKButtonDirective) toolbarButtons: QueryList<CKButtonDirective>;

  ngAfterContentInit() {
    // Reconfigure each button's toolbar property within ckgroup to hold its parent's name
    this.toolbarButtons.forEach(button => (button.toolbar = this.name));
  }

  public initialize(editor: CKEditorComponent) {
    editor.instance.ui.addToolbarGroup(this.name, this.previous, this.subgroupOf);
    // Initialize each button within ckgroup
    this.toolbarButtons.forEach(button => {
      button.initialize(editor);
    });
  }
}
