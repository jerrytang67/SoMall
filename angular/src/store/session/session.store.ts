import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { getStore } from '@shared';

export interface SessionState {
    token: string;
    name: string;
}

export function createInitialState(): SessionState {
    return getStore<SessionState>("token") || {
        token: '',
        name: ''
    };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'session' })
export class SessionStore extends Store<SessionState> {
    constructor() {
        super(createInitialState());
    }
}