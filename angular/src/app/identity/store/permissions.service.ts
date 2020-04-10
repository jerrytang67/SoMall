import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { PermissionsStore, PermissionResponse } from './permissions.store';
import { Identity } from '../models/identity';
import { tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class PermissionsService {
    constructor(
        private permissionsStore: PermissionsStore,
        private http: HttpClient
    ) {
    }

    getPermissions(params = {}): Observable<PermissionResponse> {
        return this.http.request<PermissionResponse>('get', "/api/abp/permissions/get", { params })
            .pipe(
                tap(res => {
                    console.log(res.groups)
                    this.permissionsStore.update(
                        { groups: res.groups }
                    );
                }));
    }

    update(params: { providerKey: string, providerName: string, body: { permissions: any[] } }): Observable<any> {
        let options: any = {
            params: { providerKey: params.providerKey, providerName: params.providerName },
            body: params.body
        };
        return this.http.request<any>('put', "/api/abp/permissions/update", options);
    }
}