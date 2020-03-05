import { Injectable } from '@angular/core';
import { IdentityStore } from './identity.store';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { UserProxyService } from 'src/api/appService';

@Injectable({ providedIn: 'root' })
export class IdentityService {
    constructor(private identityStore: IdentityStore
        , private userApi: UserProxyService

    ) {

    }

    getUsers(params = {}): Observable<any> {
        return this.userApi.users3(params);
    }

} 