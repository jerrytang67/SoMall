import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';

export interface AuditLogState {

}

export function createInitialState(): AuditLogState {
    return {  };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'auditLog' })
export class AuditLogStore extends Store<AuditLogState> {
    constructor() {
        super(createInitialState());
    }
}