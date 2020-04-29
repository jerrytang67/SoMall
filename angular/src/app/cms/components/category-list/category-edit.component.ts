import { Component, OnInit, ViewChild, Input, Injector } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CategoryCreateOrUpdateDto } from 'src/api/appService';

@Component({
    selector: 'app-category-edit',
    template: `
  <form nz-form #f="ngForm" (ngSubmit)="onSubmit(f)" se-container="1" labelWidth="100">
    <se label="name">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" >
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
