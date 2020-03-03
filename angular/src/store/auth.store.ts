import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { getStore } from '@shared';

export interface AuthState {
    token: string;
}

export function createInitialState(): AuthState {
    return getStore<AuthState>("token") || {
        token: ''
    };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'session' })
export class AuthStore extends Store<AuthState> {
    constructor() {
        super(createInitialState());
    }
}