import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'

export interface IAddress {
    id?: string;
    /**  */
    realName?: string;
    /**  */
    phone?: string;

    isDefault?: boolean;
    /**  */
    locationLable?: string;
    /**  */
    locationAddress?: string;
    /**  */
    nickName?: string;
    /**  */
    lat?: number;
    /**  */
    lng?: number;
    /**  */
    locationType?: "bd09" | "gcj02" | "wgs84";
}

@Module({ dynamic: true, store, name: 'address' })
class Address extends VuexModule {
    selectAddress: IAddress = { realName: "", phone: "", locationLable: "", locationAddress: "" }

    addressList: IAddress[] = []

    get getAddressList() {
        return this.addressList;
    }
    get getSelectAddress() {
        if (this.selectAddress.realName)
            return this.selectAddress;
        else if (this.addressList.length) {
            return this.addressList.filter(x => x.isDefault)[0]
        }
        else {
            return null;
        }
    }

    @Mutation
    public SET_SELECT(address: IAddress) { this.selectAddress = address; }

    @Mutation
    private SET_ADDRESSLIST(payload: IAddress[]) { this.addressList = payload }



    @Action
    public async SelectAddress(address: IAddress) {
        await api.address_setDefault({ id: address.id! }).then(() => {
            this.SET_SELECT(address);
        });
    }

    @Action
    public GetAndSetUserAddressList() {
        api.client_getUserAddressList().then((res: any) => {
            this.SET_ADDRESSLIST(res.items);
        });
    }
}

export const AddressModule = getModule(Address)
