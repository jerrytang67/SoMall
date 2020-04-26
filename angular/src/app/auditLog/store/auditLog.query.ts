import { Query } from '@datorama/akita';
import { Injectable } from '@angular/core';
import { AuditLogState, AuditLogStore } from './auditLog.store';

@Injectable({ providedIn: 'root' })
export class AuditLogQuery extends Query<AuditLogState> {
    
    constructor(protected store: AuditLogStore) {
        super(store);
    }
}