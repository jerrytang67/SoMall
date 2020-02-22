import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'


@Module({ dynamic: true, store, name: 'system' })
class SystemInfo extends VuexModule {

    info: any = {}

    get getInfo() {
        return this.info;
    }

    @Mutation
    private SET_INFO(info: any) {
        this.info = info
    }

    @Action
    public Set_Info(info: any) {
        this.SET_INFO(info);
    }
}

export const SystemModule = getModule(SystemInfo)
