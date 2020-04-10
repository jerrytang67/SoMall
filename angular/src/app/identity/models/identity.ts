
export namespace ABP {
    export type PagedResponse<T> = {
        totalCount: number;
    } & PagedItemsResponse<T>;

    export interface PagedItemsResponse<T> {
        items: T[];
    }

    export interface PageQueryParams {
        filter?: string;
        sorting?: string;
        skipCount?: number;
        maxResultCount?: number;
    }

    export interface BasicItem {
        id: string;
        name: string;
    }

    export interface Dictionary<T = any> {
        [key: string]: T;
    }
}

export namespace Identity {
    export interface State {
        roles?: RoleItem[];
        users?: UserItem[];
        userTotalCount?: number;
        userCurrentPage?: number;
        selectedRole?: RoleItem;
        selectedUser?: UserItem;
        selectedUserRoles?: RoleItem[];
    }
    export type RoleResponse = ABP.PagedResponse<RoleItem>;

    export interface RoleSaveRequest {
        name: string;
        isDefault: boolean;
        isPublic: boolean;
    }

    export interface RoleItem extends RoleSaveRequest {
        isStatic: boolean;
        concurrencyStamp: string;
        id: string;
    }
    export type UserResponse = ABP.PagedResponse<UserItem>;

    export interface UserItem extends User {
        tenantId: string;
        emailConfirmed: boolean;
        phoneNumberConfirmed: boolean;
        isLockedOut: boolean;
        concurrencyStamp: string;
        id: string;
    }

    export interface User {
        userName: string;
        name: string;
        surname: string;
        email: string;
        phoneNumber: string;
        twoFactorEnabled: true;
        lockoutEnabled: true;
    }

    export interface UserSaveRequest extends User {
        password: string;
        roleNames: string[];
    }
}


