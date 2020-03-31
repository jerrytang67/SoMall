import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { OssState, OssStore } from './oss.store';

@Injectable({ providedIn: 'root' })
export class OssQuery extends Query<OssState> {
    signature = this.getValue().signature;
    policy = this.getValue().policy;
    operator = this.getValue().accessId;

    constructor(protected store: OssStore) {
        super(store);
    }
}