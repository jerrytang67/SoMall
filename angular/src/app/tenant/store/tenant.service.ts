import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { TenantStore, TenantManagement } from './tenant.store';
import { tap } from 'rxjs/operators';




@Injectable({ providedIn: 'root' })
export class TenantService {
    constructor(
        private tenantStore: TenantStore,
        private http: HttpClient
    ) {
    }

    getTenants(params = {}): Observable<TenantManagement.Response> {
        return this.http.request<TenantManagement.Response>('get', "/api/multi-tenancy/tenants", { params })
            .pipe(
                tap(res => {
                    this.tenantStore.update(
                        { tenants: res.items, totalCount: res.totalCount }
                    );
                }));
    }
} 