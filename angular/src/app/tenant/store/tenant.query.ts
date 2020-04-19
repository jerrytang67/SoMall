import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { TenantStore, TenantManagement } from './tenant.store';

@Injectable({ providedIn: 'root' })
export class TenantQuery extends Query<TenantManagement.State> {

    constructor(protected store: TenantStore) {
        super(store);
    }
}