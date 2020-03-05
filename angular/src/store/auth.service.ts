import { Injectable } from '@angular/core';
import { setStore } from '@shared';
import { AuthStore } from './auth.store';
import { UserManagerSettings, WebStorageStateStore, User, UserManager } from 'oidc-client';
import { Router } from '@angular/router';

export function getClientSettings(): UserManagerSettings {
    return {
        authority: 'https://localhost:44380',
        client_id: 'SoMall_App',
        userStore: new WebStorageStateStore({ store: window.localStorage }),
        redirect_uri: window.location.origin + '/callback.html',
        // redirect_uri: window.location.origin + '/auth-callback',
        post_logout_redirect_uri: window.location.origin + '/signout-callback.html',
        response_type: 'id_token token',
        scope: "address email openid phone profile role SoMall",
        accessTokenExpiringNotificationTime: 20,
        automaticSilentRenew: false,
        filterProtocolClaims: true,
        loadUserInfo: true,
        checkSessionInterval: 200000
    };
}

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private manager = new UserManager(getClientSettings());
    private user: User = null;

    constructor(private authStore: AuthStore,
        private router: Router
    ) {
        this.manager.getUser().then(user => {
            this.user = user;
            setStore("auth", user);
            this.authStore.update({ auth: user })
        });
    }
    isLoggedIn(): boolean {
        console.log("isLoggedIn:", this.user != null && !this.user.expired);
        return this.user != null && !this.user.expired;
    }

    getClaims(): any {
        console.log("getClaims");
        return this.user.profile;
    }

    getAuthorizationHeaderValue(): string {
        return `${this.user.token_type} ${this.user.access_token}`;
    }

    startAuthentication(): Promise<void> {
        return this.manager.signinRedirect();
    }

    getUser(): Promise<User> {
        return this.manager.getUser()
    }


    completeAuthentication(): Promise<void> {
        return this.manager.signinRedirectCallback().then(user => {
            this.authStore.update({ auth: user })
            setStore("auth", user);
            this.router.navigate([""]);
        });
    }



}