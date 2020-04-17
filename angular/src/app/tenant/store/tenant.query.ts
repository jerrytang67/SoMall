import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { TenantState, TenantStore } from './tenant.store';

@Injectable({ providedIn: 'root' })
export class TenantQuery extends Query<TenantState> {
    
    constructor(protected store: TenantStore) {
        super(store);
    }
}