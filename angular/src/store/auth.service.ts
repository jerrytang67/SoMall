import { Injectable } from '@angular/core';
import { setStore, removeStore } from '@shared';
import { AuthStore } from './auth.store';
import { UserManagerSettings, WebStorageStateStore, User, UserManager } from 'oidc-client';
import { Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { environment } from '@env/environment';

export function getClientSettings(): UserManagerSettings {
    return {
        authority: environment.oAuthConfig.issuer,
        client_id: 'SoMall_App',
        userStore: new WebStorageStateStore({ store: window.localStorage }),
        redirect_uri: window.location.origin + environment.SERVER_URL + '/callback.html',
        post_logout_redirect_uri: window.location.origin + environment.SERVER_URL + '/signout-callback.html',
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

    private currentUser: User;

    get user(): User {
        return this.currentUser;
    }

    userLoaded$ = new ReplaySubject<boolean>(1);

    constructor(private authStore: AuthStore,
        private router: Router
    ) {

        this.manager.getUser().then(user => {
            if (user) {
                this.currentUser = user;
                setStore("auth", user);
                this.authStore.update({ auth: user })
                this.userLoaded$.next(true);
            } else {
                this.currentUser = undefined;
                removeStore("auth");
                this.authStore.update({ auth: undefined })
                this.userLoaded$.next(false);
            }
        }).catch(err => {
            this.currentUser = undefined;
            removeStore("auth");
            this.authStore.update({ auth: undefined })
            this.userLoaded$.next(false);
        });

        this.manager.events.addUserLoaded(user => {
            console.log("user loaed:", user);
            this.currentUser = user;
            setStore("auth", user);
            this.authStore.update({ auth: user })
            this.userLoaded$.next(true);
        })

        this.manager.events.addUserUnloaded(() => {
            console.log("UserUnloaded");
            this.currentUser = undefined;
            removeStore("auth");
            this.authStore.update({ auth: undefined })
            this.userLoaded$.next(false);
        })

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

    logout() {
        this.manager.signoutRedirect().then(res => {
            console.log("signoutRedirect");
        });
    }


    completeAuthentication(): Promise<void> {
        return this.manager.signinRedirectCallback().then(user => {
            this.authStore.update({ auth: user })
            setStore("auth", user);
            this.router.navigate([""]);
        });
    }



}