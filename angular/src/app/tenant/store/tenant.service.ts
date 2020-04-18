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


    getTenant(id: string): Observable<TenantManagement.Item> {
        return this.http.request<TenantManagement.Item>('get', `/api/multi-tenancy/tenants/${id}`)
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

    createTenant(params: TenantManagement.CreateOrUpdateDto): Observable<void> {
        return this.http.request<void>('post', `/api/multi-tenancy/tenants`, { body: params })
    }

    updateTenant(id: string, params: TenantManagement.CreateOrUpdateDto): Observable<void> {
        return this.http.request<void>('put', `/api/multi-tenancy/tenants/${id}`, { body: params })
    }

    deleteTenant(id: string): Observable<void> {
        return this.http.request<void>('delete', `/api/multi-tenancy/tenants/${id}`)
    }

    deleteTenantConn(id: string): Observable<void> {
        return this.http.request<void>('delete', `/api/multi-tenancy/tenants/${id}/default-connection-string`)
    }
} 