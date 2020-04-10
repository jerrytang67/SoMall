import { Injectable } from '@angular/core';
import { IdentityStore } from './identity.store';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Identity } from '../models/identity';
import { tap } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class IdentityService {
    constructor(
        private identityStore: IdentityStore,
        private http: HttpClient
    ) {
    }


    getRoles(params = {}): Observable<Identity.RoleResponse> {
        return this.http.request<Identity.RoleResponse>('get', "/api/identity/roles/all", { params })
            .pipe(
                tap(res => {
                    this.identityStore.update(
                        { roles: res.items }
                    );
                }));
    }


    getUsers(params = {}): Observable<Identity.UserResponse> {
        return this.http.request<Identity.UserResponse>('get', "/api/identity/users", { params })
            .pipe(
                tap(res => {
                    this.identityStore.update(
                        { users: res.items, userTotalCount: res.totalCount }
                    );
                }));
    }

    getUserById(id: string): Observable<Identity.UserItem> {
        return this.http.request<Identity.UserItem>('get', `/api/identity/users/${id}`)
            .pipe(
                tap(user => {
                    this.identityStore.update({ selectedUser: user });
                })
            );
    }

    GetUserRoles(id: string): Observable<Identity.RoleResponse> {
        return this.http.request<Identity.RoleResponse>('get', `/api/identity/users/${id}/roles`)
            .pipe(
                tap(res => {
                    this.identityStore.update({ selectedUserRoles: res.items });
                })
            );
    }

    getRoleById(id: string): Observable<Identity.RoleItem> {
        return this.http.request<Identity.RoleItem>('get', `/api/identity/roles/${id}`)
            .pipe(
                tap(role => {
                    this.identityStore.update({ selectedRole: role });
                })
            );
    }
} 