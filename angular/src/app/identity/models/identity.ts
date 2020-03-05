
export namespace Identity {
    export interface State {
        roles: UserItem[];
        users: RoleItem[];
        selectedRole?: RoleItem;
        selectedUser?: UserItem;
    }

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
