import { NgModule, ModuleWithProviders, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { ToastrModule } from 'ngx-toastr';
import { ColorsService } from './colors/colors.service';

// #region third libs
// import { NgZorroAntdModule } from 'ng-zorro-antd';
import { NzAffixModule } from 'ng-zorro-antd/affix';
import { NzAlertModule } from 'ng-zorro-antd/alert';
import { NzAnchorModule } from 'ng-zorro-antd/anchor';
import { NzAutocompleteModule } from 'ng-zorro-antd/auto-complete';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzBackTopModule } from 'ng-zorro-antd/back-top';
import { NzBadgeModule } from 'ng-zorro-antd/badge';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzCalendarModule } from 'ng-zorro-antd/calendar';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzCarouselModule } from 'ng-zorro-antd/carousel';
import { NzCascaderModule } from 'ng-zorro-antd/cascader';
import { NzCheckboxModule } from 'ng-zorro-antd/checkbox';
import { NzCollapseModule } from 'ng-zorro-antd/collapse';
import { NzCommentModule } from 'ng-zorro-antd/comment';
import { warnDeprecation } from 'ng-zorro-antd/core/logger';
import { NzNoAnimationModule } from 'ng-zorro-antd/core/no-animation';
import { NzTransButtonModule } from 'ng-zorro-antd/core/trans-button';
import { NzWaveModule } from 'ng-zorro-antd/core/wave';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzDescriptionsModule } from 'ng-zorro-antd/descriptions';
import { NzDividerModule } from 'ng-zorro-antd/divider';
import { NzDrawerModule } from 'ng-zorro-antd/drawer';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzEmptyModule } from 'ng-zorro-antd/empty';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzI18nModule } from 'ng-zorro-antd/i18n';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzListModule } from 'ng-zorro-antd/list';
import { NzMentionModule } from 'ng-zorro-antd/mention';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzNotificationModule } from 'ng-zorro-antd/notification';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzPopoverModule } from 'ng-zorro-antd/popover';
import { NzProgressModule } from 'ng-zorro-antd/progress';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzRateModule } from 'ng-zorro-antd/rate';
import { NzResultModule } from 'ng-zorro-antd/result';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzSkeletonModule } from 'ng-zorro-antd/skeleton';
import { NzSliderModule } from 'ng-zorro-antd/slider';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzStatisticModule } from 'ng-zorro-antd/statistic';
import { NzStepsModule } from 'ng-zorro-antd/steps';
import { NzSwitchModule } from 'ng-zorro-antd/switch';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzTagModule } from 'ng-zorro-antd/tag';
import { NzTimePickerModule } from 'ng-zorro-antd/time-picker';
import { NzTimelineModule } from 'ng-zorro-antd/timeline';
import { NzToolTipModule } from 'ng-zorro-antd/tooltip';
import { NzTransferModule } from 'ng-zorro-antd/transfer';
import { NzTreeModule } from 'ng-zorro-antd/tree';
import { NzTreeSelectModule } from 'ng-zorro-antd/tree-select';
import { NzTypographyModule } from 'ng-zorro-antd/typography';
import { NzUploadModule } from 'ng-zorro-antd/upload';


// ngx-bootstrap
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { DatepickerModule, BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import {DragDropModule} from '@angular/cdk/drag-drop';


import { ExceptionComponent } from './components/exception/exception.component';
import { SEModule } from './components/edit/edit.module';
import { ShopSelectComponent } from '../visitor/components/shop-select/shop-select.component';
import { CKEditorModule } from './ckeditor';
import { TtTooltip } from './components/tt-tooltip/tt-tooltip.component';
import { TtUploadComponent } from './components/tt-upload/tt-upload.component';
import { UtilsModule } from './utils/utils.module';

import { BaiduMapModule } from 'angular2-baidu-map'
import { TtMapComponent } from './components/tt-map/tt-map.component';
import { OverlayModule } from '@angular/cdk/overlay';

const BSMODULES = [
  TooltipModule.forRoot(),
  TabsModule.forRoot(),
  DatepickerModule.forRoot(),
  BsDatepickerModule.forRoot(),
  ToastrModule.forRoot()
]

const NZMODULES = [
  NzAffixModule,
  NzAlertModule,
  NzAnchorModule,
  NzAutocompleteModule,
  NzAvatarModule,
  NzBackTopModule,
  NzBadgeModule,
  NzButtonModule,
  NzBreadCrumbModule,
  NzCalendarModule,
  NzCardModule,
  NzCarouselModule,
  NzCascaderModule,
  NzCheckboxModule,
  NzCollapseModule,
  NzCommentModule,
  NzDatePickerModule,
  NzDescriptionsModule,
  NzDividerModule,
  NzDrawerModule,
  NzDropDownModule,
  NzEmptyModule,
  NzFormModule,
  NzGridModule,
  NzI18nModule,
  NzIconModule,
  NzInputModule,
  NzInputNumberModule,
  NzLayoutModule,
  NzListModule,
  NzMentionModule,
  NzMenuModule,
  NzMessageModule,
  NzModalModule,
  NzNoAnimationModule,
  NzNotificationModule,
  NzPageHeaderModule,
  NzPaginationModule,
  NzPopconfirmModule,
  NzPopoverModule,
  NzProgressModule,
  NzRadioModule,
  NzRateModule,
  NzResultModule,
  NzSelectModule,
  NzSkeletonModule,
  NzSliderModule,
  NzSpinModule,
  NzStatisticModule,
  NzStepsModule,
  NzSwitchModule,
  NzTableModule,
  NzTabsModule,
  NzTagModule,
  NzTimePickerModule,
  NzTimelineModule,
  NzToolTipModule,
  NzTransButtonModule,
  NzTransferModule,
  NzTreeModule,
  NzTreeSelectModule,
  NzTypographyModule,
  NzUploadModule,
  NzWaveModule]

const THIRDMODULES = [
  ...NZMODULES,
  ...BSMODULES,
  // NgZorroAntdModule, 
  CKEditorModule,
  SEModule,
  UtilsModule,
  DragDropModule,
  OverlayModule,
  BaiduMapModule.forRoot({ ak: 'hLA0PXEzz7VxhiwpUtAWZknyzOqh1zGf' })
];
// #endregion

// #region your componets & directives

const COMPONENTS = [ExceptionComponent, ShopSelectComponent];
const MyCOMPONENTS = [TtTooltip, TtUploadComponent, TtMapComponent];
const DIRECTIVES = [];
// #endregion

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    // third libs
    ...THIRDMODULES
  ],
  providers: [
    ColorsService
  ],
  declarations: [
    // your components
    ...COMPONENTS,
    ...MyCOMPONENTS,
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
    ...MyCOMPONENTS,
    ...DIRECTIVES
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ]
})
export class SharedModule {
  //static forRoot(): ModuleWithProviders {
  static forRoot() {
    return {
      ngModule: SharedModule
    };
  }
}
