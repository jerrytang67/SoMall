import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

export interface IMallShop {
    id?: string;
    name: string;
    shortName: string;
    coverImage?: string;
    logoImage?: string;
    description?: string;
}



@Module({ dynamic: true, store, name: 'shop' })
class Shop extends VuexModule {

    shopList: any[] = [];

    currentShop: IMallShop = { name: "", shortName: "" };

    get shops() { return this.shopList }

    get getCurrentShop() { return this.currentShop }

    @Mutation
    SET_LIST(payload: any[]) {
        this.shopList = [...payload];
    }

    @Mutation
    SET_CURRENT_SHOP(payload: IMallShop) {
        console.log("mutaction:SET_CURRENT_SHOP", payload)
        this.currentShop = payload;
    }

    @Action({ commit: 'SET_LIST' })
    public SetList(shops: any[]) {
        return shops;
    }

    @Action
    public async GetAndSetCurrentShop(shopId: string) {
        await api.mallShop_get(shopId).then((res: any) => {
            this.SET_CURRENT_SHOP(res);
        })
    }

}

export const ShopModule = getModule(Shop)
