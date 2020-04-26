import { Component, OnInit, ViewChild, Input, Injector } from '@angular/core';
import { CategoryCreateOrUpdateDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-category-edit',
    template: `
  <form nz-form #f="ngForm" (ngSubmit)="onSubmit(f)" se-container="1" labelWidth="100">
    <se label="logoImageUrl">
        <tt-upload [(ngModel)]="form.logoImageUrl" name="logoImageUrl" [length]="1"></tt-upload>
    </se>
    <se label="名称" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" required>
    </se>
    <se label="Code" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.code" name="code" required>
    </se>
    <se label="sort">
        <input type="text" nz-input [(ngModel)]="form.sort" name="sort" required>
    </se>
    <se label="redirectUrl">
        <input type="text" nz-input [(ngModel)]="form.redirectUrl" name="redirectUrl">
    </se>
    <se label="isGlobal">
        <nz-switch [(ngModel)]="form.isGlobal" name="isGlobal"></nz-switch>
    </se>
    <se label="展示APP">
        <nz-checkbox-group [(ngModel)]="apps" name="apps" (ngModelChange)="updateSingleChecked($event)">
        </nz-checkbox-group>
    </se>
</form>
`
})
export class CategoryEditComponent implements OnInit {

    @ViewChild('f', { static: true }) f: NgForm;

    @Input() title: string;

    @Input() id: string;

    @Input() apps: any[];

    @Input() form: CategoryCreateOrUpdateDto;

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
