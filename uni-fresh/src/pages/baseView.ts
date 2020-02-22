import { Vue, Component, Prop } from "vue-property-decorator";
import { UserModule } from '@/store/modules/user';

export abstract class BaseView extends Vue {
    get token() {
        return UserModule.getToken;
    }

    get shopMember() {
        return UserModule.getShopMember;
    }

    get addressList() {
        return UserModule.getAddressList;
    }
}

export default {
    BaseView
}