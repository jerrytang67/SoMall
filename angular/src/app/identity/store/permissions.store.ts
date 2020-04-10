import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';


export interface PermissionResponse {
    entityDisplayName: string;
    groups: Group[];
}

export interface Group {
    name: string;
    displayName: string;
    permissions: Permission[];
}

export interface MinimumPermission {
    name: string;
    isGranted: boolean;
}

export interface Permission extends MinimumPermission {
    displayName: string;
    parentName: string;
    allowedProviders: string[];
    grantedProviders: GrantedProvider[];
}

export interface GrantedProvider {
    providerName: string;
    providerKey: string;
}

export interface UpdateRequest {
    permissions: MinimumPermission[];
}


export interface PermissionsState {
    groups: Group[];
}

export function createInitialState(): PermissionsState {
    return { groups: [] };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'permissions' })
export class PermissionsStore extends Store<PermissionsState> {
    constructor() {
        super(createInitialState());
    }
}