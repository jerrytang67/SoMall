import { QueryEntity } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { AppsState, AppsStore } from './apps.store';

@Injectable({ providedIn: 'root' })
export class AppsQuery extends QueryEntity<AppsState> {
    constructor(protected store: AppsStore) {
        super(store);
    }
}
