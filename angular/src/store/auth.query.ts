import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { AuthState, AuthStore } from './auth.store';


@Injectable({ providedIn: 'root' })
export class AuthQuery extends Query<AuthState> {
    isLogin$ = this.select(state => !!state.token);
    token$ = this.select(state => state.token);

    constructor(protected store: AuthStore) {
        super(store);
    }
}