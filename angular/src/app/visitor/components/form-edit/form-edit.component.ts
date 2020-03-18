import { Component, OnInit, Input, ViewChild, Injector } from '@angular/core';
import { UpdateShopDto, OssProxyService, FormCreateOrEditDto } from 'src/api/appService';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-form-edit',
    templateUrl: './form-edit.component.html',
    styles: [
        `
    `
    ]
})
export class FormEditComponent implements OnInit {

    ngOnInit(): void {
    }
    @ViewChild('f', { static: true }) f: NgForm;


    @Input() title: string;

    @Input() id: string;

    @Input() form: FormCreateOrEditDto;

    i: any = {};

    constructor() {
    }


    onSubmit(f: NgForm) { }
}
