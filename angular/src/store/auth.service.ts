import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { setStore } from '@shared';
import { AuthStore } from './auth.store';


@Injectable({
    providedIn: 'root'
})
export class AuthService {

    constructor(private authStore: AuthStore,
        // private http: HttpClient
    ) { }

    // login(creds) {
    //     const data = { token: creds, name: creds };
    //     setStore("token", data)
    //     this.sessionStore.update({ name: "123" });
    // }

    setToken(token: string) {
        const data = { token };
        setStore("token", data)
        this.authStore.update({ token });
    }
}