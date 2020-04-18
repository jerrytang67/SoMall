import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';



export namespace TenantManagement {
    export interface State {
        tenants?: Item[];
        totalCount?: number;
    }

    export type PagedResponse<T> = {
        totalCount: number;
    } & PagedItemsResponse<T>;

    export interface PagedItemsResponse<T> {
        items: T[];
    }

    export type Response = PagedResponse<Item>;

    export interface Item {
        id?: string;
        name?: string;
    }

    export interface CreateOrUpdateDto {
        id?: string;
        adminEmailAddress?: string;
        adminPassword?: string;
        name?: string;
    }


    export interface DefaultConnectionStringRequest {
        id: string;
        defaultConnectionString: string;
    }
}



export function createInitialState(): TenantManagement.State {
    return {
        tenants: [],
        totalCount: 0
    };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'tenant' })
export class TenantStore extends Store<TenantManagement.State> {
    constructor() {
        super(createInitialState());
    }
}