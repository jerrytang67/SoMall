import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { AuthState, AuthStore } from './auth.store';


@Injectable({ providedIn: 'root' })
export class AuthQuery extends Query<AuthState> {
    isLogin$ = this.select(state => {
        return state.auth && !state.auth.expired
    });

    get user() {
        return this.getValue().auth.profile;
    }


    token$ = this.select(state => state.auth.access_token);
    profile$ = this.select(state => state.auth.profile)
    auth$ = this.select(state => state.auth)

    constructor(protected store: AuthStore) {
        super(store);
    } 
}