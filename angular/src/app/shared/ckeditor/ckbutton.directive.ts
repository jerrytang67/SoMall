import { Directive, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { CKEditorComponent } from './ckeditor.component';

/**
 * CKGroup component
 * Usage :
 *  <ckeditor [(ngModel)]="data" [config]="{...}" debounce="500">
 *      <ckbutton [name]="'SaveButton'" [command]="'saveCommand'" (click)="save($event)"
 *                [icon]="'/save.png'" [toolbar]="'customGroup,1'" [label]="'Save'">
 *      </ckbutton>
 *   </ckeditor>
 */
@Directive({
  selector: 'ckbutton',
})
export class CKButtonDirective implements OnInit {
  @Output() click = new EventEmitter();
  @Input() label: string;
  @Input() command: string;
  @Input() toolbar: string;
  @Input() name: string;
  @Input() icon: string;

  initialize(editor: CKEditorComponent) {
    editor.instance.addCommand(this.command, {
      exec: (evt: any) => {
        this.click.emit(evt);
      },
    });

    editor.instance.ui.addButton(this.name, {
      label: this.label,
      command: this.command,
      toolbar: this.toolbar,
      icon: this.icon,
    });
  }

  ngOnInit(): void {
    if (!this.name) throw new Error('Attribute "name" is required on <ckbutton>');
    if (!this.command) throw new Error('Attribute "command" is required on <ckbutton>');
  }
}
