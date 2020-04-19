import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'
import { ISku } from './shop'


@Module({ dynamic: true, store, name: 'orders' })
class Orders extends VuexModule {

    private currentOrder: any = {}

    private cart: ISku[] = []

    get getCurrentOrder() { return this.currentOrder }

    get getCart(): ISku[] {
        return this.cart
    }

    @Mutation
    private SET_ORDER(order: any) {
        this.currentOrder = order;
    }

    @Mutation
    private SET_CART(item: ISku) {
        if (this.cart.filter(x => x.id == item.id).length > 0) {
            let _item = this.cart.filter(x => x.id === item.id)[0];
            this.cart = [...this.cart.filter(x => x.id !== item.id), _item]
        }
        else {
            this.cart = [...this.cart, item]
        }
        this.cart = this.cart.filter(x => x.num! > 0)
        // .sort((a: ISku, b: ISku) => a.Id! - b.Id!)
        //uni.setStorageSync("cart", this.cart)
    }

    @Action
    public GetAndSetCurrentOrder(orderId: string) {
        api.order_get(orderId).then(res => {
            this.SET_ORDER(res);
        })
    }

    @Action
    public AddCart(item: ISku) {
        item.num! += 1;
        this.SET_CART(item);
    }

    @Action
    public RemoveCart(item: ISku) {
        if (item.num! > 0)
            item.num! -= 1;
        this.SET_CART(item);
    }
}

export const OrderModule = getModule(Orders)
