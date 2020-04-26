import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuditLogStore } from './auditLog.store';

@Injectable({ providedIn: 'root' })
export class AuditLogService {
    constructor(
        private AuditLogStore: AuditLogStore,
        private http: HttpClient
    ) {
    }
} 