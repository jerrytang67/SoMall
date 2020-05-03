import { Store, StoreConfig, HashMap, EntityState, EntityStore } from '@datorama/akita';
import { Injectable } from '@angular/core';

import { AppDto } from 'src/api/appService';

export interface AppsState extends EntityState<AppDto, string> { }

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'apps' })
export class AppsStore extends EntityStore<AppsState> {
    constructor() {
        super({ filter: 'ALL' });
    }
}