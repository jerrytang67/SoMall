import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { Identity } from '../models/identity';


export function createInitialState(): Identity.State {
    return { roles: [], users: [] };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'identity' })
export class IdentityStore extends Store<Identity.State> {
    constructor() {
        super(createInitialState());
    }
}