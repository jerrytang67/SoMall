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
    num?: number;
    checked?: boolean;

}

@Module({ dynamic: true, store, name: 'shop' })
class Shop extends VuexModule {
    private shopList: IMallShop[] = [];

    private currentShop: IMallShop = { name: "", shortName: "" };

    private currentSpu: ISpu = {};

    private selectIndex: number = 0;

    private spuList: ISpu[] = []

    private categories: any[] = [];

    get shops() { return this.shopList }

    get getSelectIndex() { return this.selectIndex }

    get getCurrentShop(): IMallShop { return this.currentShop }

    get getCurrentSpu() { return this.currentSpu }

    get getCurrentSku(): ISku {
        return this.currentSpu.id ?
            this.currentSpu.skus![this.selectIndex]
            :
            { coverImageUrls: [] }
    }

    get getCategories() {
        return this.categories;
    }

    get getSpuList() { return this.spuList }

    @Mutation
    private SET_LIST(payload: IMallShop[]) {
        this.shopList = [...payload];
    }

    @Mutation
    private SET_CURRENT_SHOP(payload: IMallShop) {
        console.log("mutaction:SET_CURRENT_SHOP", payload)
        this.currentShop = payload;
    }

    @Mutation
    private SET_SPU_LIST(payload: ISpu[]) {
        console.log("mutaction:SET_SPU_LIST", payload)
        this.spuList = payload;
    }

    @Mutation
    private SET_CURRENT_SPU(payload: ISpu) {
        console.log("mutaction:SET_CURRENT_SPU", payload)
        this.currentSpu = payload;
    }
    @Mutation
    private SET_SELECT_INDEX(payload: number) {
        console.log("mutaction:SET_SELECT_INDEX", payload)
        this.selectIndex = payload;
    }

    @Mutation
    private SET_NUM(num: number, index: number | undefined) {
        index = index || this.selectIndex;
        let sku = this.currentSpu.skus![index];
        sku.num = num;
    }

    @Mutation
    private SET_CATEGORIES(payload: any[]) {
        this.categories = payload;
    }

    @Action({ commit: 'SET_LIST' })
    public SetList(shops: IMallShop[]) {
        return shops;
    }

    @Action
    public async GetAndSetCurrentShop(shopId: string) {
        await api.shop_get(shopId).then((res: any) => {
            this.SET_CURRENT_SHOP(res);
        })
    }

    @Action
    public async GetAndSetSpuList(shopId: string) {
        await api.spu_getList({ shopId }).then((res: any) => {
            this.SET_SPU_LIST(res.items);
        })
    }


    @Action
    public async GetAndSetCurrentSpu(id: string) {
        await api.spu_get({ id: id }).then((res: any) => {
            this.SET_CURRENT_SPU(res);
            this.SET_SELECT_INDEX(0);
        })
    }


    @Action
    public async SetSelectSkuIndex(index: number) {
        this.SET_SELECT_INDEX(index);
    }

    @Action
    public SetNum(num: number, index: number | undefined = undefined) {
        this.SET_NUM(num, index);
    }

    @Action
    public SetCategories(categories: any[]) {
        this.SET_CATEGORIES(categories)
    }

    private index_spus: any[] = []

    get getIndexSpus() { return this.index_spus }

    @Action
    public SetIndexSpus(spus: any[]) {
        this.SET_INDEX_SPUS(spus)
    }

    @Mutation
    private SET_INDEX_SPUS(payload: any[]) {
        this.index_spus = payload;
    }

}

export const ShopModule = getModule(Shop)
