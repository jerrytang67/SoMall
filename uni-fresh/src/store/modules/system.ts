import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

export interface IShopItem {
    Id: number;
    Name: string;
    Desc: string;
    Price: number;
    PriceVip: number;
    Count: number;
    LogoUrl: string;
    CategoryId: number;
    Unit: string;
}

export interface ICategory {
    Id?: number;
    Name?: string;
    ParentId?: number | undefined;
    Sort: number;
    StoreId?: number;
    Level?: number;
    IsAppShow?: boolean;
}

export enum IListStyle {
    Card = 0,
    List = 1
}

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
