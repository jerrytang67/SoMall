import { Component, OnInit, ViewChild, Input, Injector } from '@angular/core';
import {  SwiperCreateOrUpdateDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-swiper-edit',
    template: `
  <form nz-form #f="ngForm" (ngSubmit)="onSubmit(f)" se-container="1" labelWidth="100">
    <se label="展示APP">
         <nz-select [(ngModel)]="form.appName"  nzPlaceHolder="请选择App" name="appName">
            <nz-option *ngFor="let option of apps" [nzValue]="option.value" [nzLabel]="option.label"></nz-option>
        </nz-select>
    </se>
    <se label="groupName" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.groupName" name="groupName" required>
    </se>
    <se label="coverImageUrl" error="请填写">
        <tt-upload [(ngModel)]="form.coverImageUrl" name="coverImageUrl" [length]="1"></tt-upload>
    </se>
    <se label="name">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" >
    </se>
    <se label="sort" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.sort" name="sort" required>
    </se>
</form>
`
})
export class SwiperEditComponent implements OnInit {

    @ViewChild('f', { static: true }) f: NgForm;

    @Input() title: string;

    @Input() id: string;

    @Input() apps: any[];

    @Input() form: SwiperCreateOrUpdateDto;

    i: any = {};

    constructor(private http: HttpClient) {
    }

    ngOnInit() {

    }

    onSubmit(f: NgForm) { }

    ngOnDestroy(): void {
    };


    updateSingleChecked(event) {
        console.log(event)
    }

}
