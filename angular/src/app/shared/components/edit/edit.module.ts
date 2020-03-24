import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';

import { SEContainerComponent } from './edit-container.component';
import { SEErrorComponent } from './edit-error.component';
import { SETitleComponent } from './edit-title.component';
import { SEComponent } from './edit.component';
import { StringTemplateOutletDirective } from '@shared/directives/string_template_outlet';

const COMPONENTS = [SEContainerComponent, SEComponent, SEErrorComponent, SETitleComponent];





@NgModule({
    imports: [CommonModule, NzToolTipModule, NzIconModule],
    declarations: [...COMPONENTS, StringTemplateOutletDirective],
    exports: [...COMPONENTS, StringTemplateOutletDirective],
})
export class SEModule { }
