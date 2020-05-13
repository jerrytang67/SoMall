import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AppsStore } from './apps.store';
import { AppDtoPagedResultDto } from 'src/api/appService';
import { delay, tap, map, debounceTime } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class AppsService {
    constructor(
        private appsStore: AppsStore,
        private http: HttpClient
    ) {
    }

    getAll(params = {}) {
        this.http.request<AppDtoPagedResultDto>('get', "/api/app/app/getList", params).pipe(
            debounceTime(500)
        ).subscribe(res => {
            this.appsStore.set(res.items)
        })
            ;
    }

    updateFilter(filter) {
        this.appsStore.update({
            filter: 'COMPLETED'
        });
    }
} 