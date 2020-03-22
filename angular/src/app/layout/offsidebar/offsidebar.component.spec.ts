/* tslint:disable:no-unused-variable */

import { ElementRef } from '@angular/core';
import { TestBed, async, inject } from '@angular/core/testing';
import { OffsidebarComponent } from './offsidebar.component';
import { TranslateService, TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

import { SettingsService } from '../../core/settings/settings.service';
import { ThemesService } from '../../core/themes/themes.service';
import { TranslatorService } from '../../core/translator/translator.service';
import { SharedModule } from '../../shared/shared.module';
import { createTranslateLoader } from '../../app.module';

export class MockElementRef extends ElementRef {
    constructor() { super(null); }
}

describe('Component: Offsidebar', () => {

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                TranslateModule.forRoot({
                    loader: {
                        provide: TranslateLoader,
                        useFactory: (createTranslateLoader),
                        deps: [HttpClient]
                    }
                }),
                HttpClientModule,
                SharedModule
            ],
            providers: [SettingsService, ThemesService, TranslatorService, MockElementRef]
        }).compileComponents();
    });

    it('should create an instance', async(inject([SettingsService, ThemesService, TranslatorService, MockElementRef],
        (settingsService, themesService, translatorService, mockElementRef) => {
            let component = new OffsidebarComponent(settingsService, themesService, translatorService, mockElementRef);
            expect(component).toBeTruthy();
        })));
});
