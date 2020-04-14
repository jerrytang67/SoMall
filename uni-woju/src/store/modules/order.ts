import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'


@Module({ dynamic: true, store, name: 'orders' })
class Orders extends VuexModule {

    private currentOrderId: string = "1dfc93f4-56ab-242f-da0a-39f489957e08"

    @Mutation
    public SET_ORDERID(orderId: string) {
        this.currentOrderId = orderId;
    }

    @Action
    public GetAndSetCurrentOrder(orderId: string) {
        if (orderId) {
            this
        }
    }
}

export const OrderModule = getModule(Orders)
