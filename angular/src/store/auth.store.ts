import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { User } from 'oidc-client';

export interface AuthState {
    auth: User;

}

export function createInitialState(): AuthState {
    return { auth: undefined };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'auth' })
export class AuthStore extends Store<AuthState> {
    constructor() {
        super(createInitialState());
    }
}