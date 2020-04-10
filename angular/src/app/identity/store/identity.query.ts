import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { Identity } from '../models/identity';
import { IdentityStore } from './identity.store';

@Injectable({ providedIn: 'root' })
export class IdentityQuery extends Query<Identity.State> {
    constructor(protected store: IdentityStore) {
        super(store);
    }
}