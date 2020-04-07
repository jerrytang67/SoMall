import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

@Module({ dynamic: true, store, name: 'address' })
class Address extends VuexModule {

    @Action
    public GetAndSetUserAddressList() {
        api.mall_address_getList().then(res => {

        });
    }
}

export const AddressModule = getModule(Address)
