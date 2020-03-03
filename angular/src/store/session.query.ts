import { Query } from '@datorama/akita';
import { SessionState, SessionStore } from './session.store';
import { Injectable } from '@angular/core';


@Injectable({ providedIn: 'root' })
export class SessionQuery extends Query<SessionState> {
    isLogin$ = this.select(state => !!state.token);
    selectName$ = this.select('name');

    constructor(protected store: SessionStore) {
        super(store);
    }
}