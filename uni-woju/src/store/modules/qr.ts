import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'


export interface IQrDetail {
    eventName?: string;
    params?: {
        spuId?: string;
        keywords?: string;
    };
    creationTime?: Date;
    path?: string;

}


@Module({ dynamic: true, store, name: 'qr' })
class Qr extends VuexModule {

    private current_qrDetail: IQrDetail = {};

    get get_Current_QrDtail() { return this.current_qrDetail }

    @Mutation
    private SET_CURRENT_QRDETAIL(payload: IQrDetail) {
        console.log("Mutation:SET_CURRENT_QRDETAIL", payload)
        this.current_qrDetail = payload;
    }

    @Action
    public GetQrDetail(scene: string) {
        api.getQrDetail(scene).then((res: any) => {
            this.SET_CURRENT_QRDETAIL(res);
        })
    }


    @Action
    public Init(data: any = {}) {
    }
}

export const QrModule = getModule(Qr)
