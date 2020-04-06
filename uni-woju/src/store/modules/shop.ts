import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

@Module({ dynamic: true, store, name: 'shop' })
class Shop extends VuexModule {

    shopList: any[] = [];

    get shops() { return this.shopList }

    @Mutation
    SET_LIST(payload: any[]) {
        this.shopList = [...payload];
    }

    @Action({ commit: 'SET_LIST' })
    public SetList(shops: any[]) {
        return shops;
    }

}

export const ShopModule = getModule(Shop)
