import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { PermissionsState, PermissionsStore } from './permissions.store';

@Injectable({ providedIn: 'root' })
export class PermissionsQuery extends Query<PermissionsState> {


    groups$ = this.select(state => state.groups);

    constructor(protected store: PermissionsStore) {
        super(store);
    }
}
