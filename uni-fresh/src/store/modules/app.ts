import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

// export interface IAppState {
//   device: DeviceType
//   sidebar: {
//     opened: boolean
//     withoutAnimation: boolean
//   },
//   name: string,
//   version: string,
//   tenant: ITenantLoginInfoDto,
//   tenantId: number | string | undefined,
//   routers: RouteConfig[] | undefined
// }

export interface IShopItem {
    Id: number;
    Name: string;
    Desc: string;
    Price: number;
    PriceVip: number;
    Count: number;
    LogoUrl: string;
    CategoryId: number;
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

@Module({ dynamic: true, store, name: 'app' })
class App extends VuexModule {

    shop: any = {}
    shopItems: IShopItem[] = []

    category: ICategory[] = []
    cart: IShopItem[] = []
    currentCategory: ICategory = { Id: 0, Sort: 0 }

    get getShop() {
        return this.shop;
    }

    get getCategory() {
        return this.category;
    }

    get getCurrentCategory() {
        return this.currentCategory
    }
    get getShopItems() {
        return this.shopItems;
    }

    get getCart() {
        return this.cart;
    }

    get getCartTotal() {
        return this.cart.reduce((p, c) => p + (c.PriceVip * c.Count), 0);
    }

    @Mutation
    private SET_SHOP(shop: any) {
        this.shop = shop
    }

    @Mutation
    private SET_CATEGORY(cate: ICategory[]) {
        this.category = cate.sort((a, b) => b.Sort - a.Sort).filter(x => x.IsAppShow)
    }

    @Mutation
    private SET_CURRENT_CATEGORY(cate: ICategory) {
        this.currentCategory = cate
    }

    @Mutation
    private SET_SHOPITEMS(items: IShopItem[]) {
        this.shopItems = items
    }

    @Mutation
    private SET_CART(item: IShopItem) {
        if (this.cart.filter(x => x.Id == item.Id).length > 0) {
            let _item = this.cart.filter(x => x.Id === item.Id)[0];
            this.cart = [...this.cart.filter(x => x.Id !== item.Id), _item]
        }
        else {
            this.cart = [...this.cart, item]
        }
        this.cart = this.cart.filter(x => x.Count > 0).sort((a: IShopItem, b: IShopItem) => a.Id - b.Id);
    }

    @Action
    public SetShop(shop: any) {
        this.SET_SHOP(shop);
    }

    @Action
    public SetCategory(category: ICategory[]) {
        this.SET_CATEGORY(category);
        this.SET_CURRENT_CATEGORY(category[0])
    }

    @Action
    public setCurrentCategory(category: ICategory) {
        this.SET_CURRENT_CATEGORY(category);
    }

    @Action
    public SetShopItems(items: IShopItem[]) {
        this.SET_SHOPITEMS(items);
    }

    @Action
    public AddCart(item: IShopItem) {
        item.Count += 1;
        this.SET_CART(item);
    }
    @Action
    public RemoveCart(item: IShopItem) {
        if (item.Count > 0)
            item.Count -= 1;
        this.SET_CART(item);
    }

    @Action
    public Init() {
        api.init({}).then((res: any) => {
            console.log(res);
            AppModule.SetShopItems(res.data.itemList);
            AppModule.SetShop(res.data.shop);
            AppModule.SetCategory(res.data.categoryList);
        });
    }
}

export const AppModule = getModule(App)
