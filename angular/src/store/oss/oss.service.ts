import { Injectable } from '@angular/core';
import { OssStore } from './oss.store';
import { OssProxyService } from 'src/api/appService';
import base64 from '@core/utils/base64';

@Injectable({ providedIn: 'root' })
export class OssService {

    sigLoaded: boolean;
    constructor(private ossStore: OssStore,
        private ossApi: OssProxyService) {
        this.sigLoaded = false;
        this.init();
    }
    init() {
        this.ossApi.getConfig().subscribe(res => {
            this.ossStore.update(res);
            let bucketName = res.bucketName;
            let accessId = res.accessId;
            // @ts-ignore
            let date = new Date().toGMTString();
            let opts = {
                "save-key": `/${accessId}/{year}/{mon}/{day}/{random32}{.suffix}`,
                bucket: bucketName,
                expiration: Math.round(new Date().getTime() / 1000) + 36000,
                date: date
            };
            let policy = base64.encode(JSON.stringify(opts));
            let data = ["POST", "/" + opts.bucket, date, policy].join("&");
            this.ossApi.getSignature({ data: data }).subscribe(res => {
                let signature = res.signature;
                this.ossStore.update({ policy, signature })
            });
        })
    }
}