import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { AppCreateOrUpdateDto } from 'src/api/appService';

@Component({
    selector: 'tt-AppEdit',
    template: `
<form nz-form #f="ngForm" se-container="1" labelWidth="100">
    <se label="名称" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" required>
    </se>
    <se label="客户端名" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.clientName" name="clientName" required>
    </se>
    <se label="ProviderName" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.providerName" name="providerName" required>
    </se>
    <se label="ProviderKey" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.providerKey" name="providerKey">
    </se>
</form>
    `
})

export class EditAppComponent implements OnInit {
    @ViewChild('f', { static: true }) f: NgForm;

    @Input() id: string;

    selectedIndex = 0;

    form: AppCreateOrUpdateDto = {};

    constructor() { }

    ngOnInit(): void {
    }
}