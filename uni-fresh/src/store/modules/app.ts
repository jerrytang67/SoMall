import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'

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

interface IShopItem {
    Id: number;
    Name: string;
    Desc: string;
    Price: number;
    PriceVip: number;
    Count: number;
    LogoUrl: string;
    CategoryId: number;
}

@Module({ dynamic: true, store, name: 'app' })
class App extends VuexModule {

    shop: any = {}
    shopItems: IShopItem[] = []

    cart: IShopItem[] = []

    get getShop() {
        return this.shop;
    }

    get getShopItems() {
        return this.shopItems;
    }

    get getCart() {
        return this.cart;
    }

    get getCartTotal() {

uni.getLocation()

        return this.cart.reduce((p, c) => p + (c.PriceVip * c.Count), 0);
    }

    @Mutation
    private SET_SHOP(shop: any) {
        this.shop = shop
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
}

export const AppModule = getModule(App)
