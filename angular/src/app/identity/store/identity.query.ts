import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { Identity } from '../models/identity';
import { IdentityStore } from './identity.store';

@Injectable({ providedIn: 'root' })
export class IdentityQuery extends Query<Identity.State> {

    users$ = this.select(state => state.users);
    roles$ = this.select(state => state.roles);

    constructor(protected store: IdentityStore) {
        super(store);
    }
}