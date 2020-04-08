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

export interface ISpu {
    id?: string;
    category?: string;
    shop?: IMallShop;
    skus?: ISku[];
    name?: string;
    code?: string;
    descCommon?: string;
    purchaseNotesCommon?: string;
    dateTimeStart?: Date;
    dateTimeEnd?: Date;
    stockCount?: number;
    soldCount?: number;
    limitBuyCount?: number;
}
export interface ISku {
    id?: string;
    coverImageUrls?: string[];
    spuId?: string;
    name?: string;
    code?: string;
    price?: number;
    desc?: string;
    purchaseNotes?: string;
    originPrice?: number;
    vipPrice?: number;
    dateTimeStart?: Date;
    dateTimeEnd?: Date;
    stockCount?: number;
    soldCount?: number;
    limitBuyCount?: number;
    unit?: string;
}

@Module({ dynamic: true, store, name: 'shop' })
class Shop extends VuexModule {

    shopList: IMallShop[] = [];

    currentShop: IMallShop = { name: "", shortName: "" };
    currentSpu: ISpu = {};

    selectIndex: number = 0;

    spuList: ISpu[] = []

    get shops() { return this.shopList }

    get getCurrentShop() { return this.currentShop }

    get getCurrentSpu() { return this.currentSpu }

    get getCurrentSku() { return this.currentSpu.id ? this.currentSpu.skus![this.selectIndex] : { coverImageUrls: [] } }

    get getSpuList() { return this.spuList }

    @Mutation
    SET_LIST(payload: IMallShop[]) {
        this.shopList = [...payload];
    }

    @Mutation
    SET_CURRENT_SHOP(payload: IMallShop) {
        console.log("mutaction:SET_CURRENT_SHOP", payload)
        this.currentShop = payload;
    }

    @Mutation
    SET_SPU_LIST(payload: ISpu[]) {
        console.log("mutaction:SET_SPU_LIST", payload)
        this.spuList = payload;
    }

    @Mutation
    SET_CURRENT_SPU(payload: ISpu) {
        console.log("mutaction:SET_CURRENT_SPU", payload)
        this.currentSpu = payload;
    }
    @Mutation
    SET_SELECT_INDEX(payload: number) {
        console.log("mutaction:SET_SELECT_INDEX", payload)
        this.selectIndex = payload;
    }

    @Action({ commit: 'SET_LIST' })
    SetList(shops: IMallShop[]) {
        return shops;
    }

    @Action
    async GetAndSetCurrentShop(shopId: string) {
        await api.shop_get(shopId).then((res: any) => {
            this.SET_CURRENT_SHOP(res);
        })
    }

    @Action
    async GetAndSetSpuList(shopId: string) {
        await api.spu_getList({ shopId }).then((res: any) => {
            this.SET_SPU_LIST(res.items);
        })
    }


    @Action
    async GetAndSetCurrentSpu(id: string) {
        await api.spu_get({ id: id }).then((res: any) => {
            this.SET_CURRENT_SPU(res);
            this.SET_SELECT_INDEX(0);
        })
    }


    @Action
    async SetSelectSkuIndex(index: number) {
        this.SET_SELECT_INDEX(index);
    }

}

export const ShopModule = getModule(Shop)
