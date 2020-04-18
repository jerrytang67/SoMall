import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';
import { TenantManagement } from '../../store/tenant.store';
import { TenantQuery } from '../../store/tenant.query';
import { TenantService } from '../../store/tenant.service';

@Component({
    selector: 'tt-TenantEdit',
    template: `
<form nz-form #f="ngForm" se-container="1" labelWidth="100">
    <se label="adminEmailAddress" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.adminEmailAddress" name="name" required>
    </se>
    <se label="adminPassword" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.adminPassword" name="name" required>
    </se>
    <se label="名称" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" required>
    </se>
</form>
    `
})

export class CreateTenantComponent implements OnInit {
    @ViewChild('f', { static: true }) f: NgForm;

    @Input() id: string;

    selectedIndex = 0;

    updateList: any[] = [];

    roles$: Observable<TenantManagement.Item[]>

    form: TenantManagement.CreateOrUpdateDto = {};

    constructor(
        private identityQuery: TenantQuery,
        private identityService: TenantService) { }

    ngOnInit(): void {
    }
}