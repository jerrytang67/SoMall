import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'


@Module({ dynamic: true, store, name: 'orders' })
class Orders extends VuexModule {

    private currentOrder: any = {}

    get getCurrentOrder() { return this.currentOrder }


    @Mutation
    public SET_ORDER(order: any) {
        this.currentOrder = order;
    }

    @Action
    public GetAndSetCurrentOrder(orderId: string) {
        api.order_get(orderId).then(res => {
            this.SET_ORDER(res);
        })
    }
}

export const OrderModule = getModule(Orders)
