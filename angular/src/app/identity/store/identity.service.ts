import { Injectable } from '@angular/core';
import { IdentityStore } from './identity.store';

@Injectable({
    providedIn: 'root'
})
export class IdentityService {
    constructor(private authStore: IdentityStore
    ) {
    }
} 