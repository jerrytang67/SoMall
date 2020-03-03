import { SessionStore } from './session.store';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { setStore } from '@shared';


@Injectable({
    providedIn: 'root'
})
export class SessionService {

    constructor(private sessionStore: SessionStore,
        private http: HttpClient) { }

    login(creds) {
        const data = { token: creds, name: creds };
        setStore("token", data)
        this.sessionStore.update({ name: "123" });
    }
}