import { Store, StoreConfig } from '@datorama/akita';
import { Injectable } from '@angular/core';

export interface OssState {
    uploadHost: string,
    bucketName: string,
    domainHost: string,
    accessId: string,

    signature: string,
    policy: string,
}

export function createInitialState(): OssState {
    return {
        uploadHost: "",
        bucketName: "",
        domainHost: "",
        accessId: "",

        signature: "",
        policy: "",
    };
}

@Injectable({ providedIn: 'root' })
@StoreConfig({ name: 'oss' })
export class OssStore extends Store<OssState> {
    constructor() {
        super(createInitialState());
    }
}