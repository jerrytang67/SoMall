import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { IdentityQuery } from '../store/identity.query';
import { IdentityService } from '../store/identity.service';
import { Identity } from '../models/identity';
import { Observable } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'tt-RoleEdit',
    template: `
<form nz-form #f="ngForm" se-container="1" labelWidth="100">
    <se label="名称" error="请填写">
        <input type="text" nz-input [(ngModel)]="form.name" name="name" required>
    </se>
    <se label="isPublic">
    <nz-switch [(ngModel)]="form.isPublic" name="isPublic" ></nz-switch>
    </se>
    <se label="isDefault">
    <nz-switch [(ngModel)]="form.isDefault" name="isDefault" ></nz-switch>
    </se>
</form>
    `
})

export class EditRoleComponent implements OnInit {
    @ViewChild('f', { static: true }) f: NgForm;

    @Input() id: string;

    selectedIndex = 0;

    updateList: any[] = [];

    roles$: Observable<Identity.RoleItem[]>

    form: Identity.RoleItem = { name: "", isDefault: false, isPublic: false };
    constructor(
        private identityQuery: IdentityQuery,
        private identityService: IdentityService) { }

    ngOnInit(): void {
    }
}