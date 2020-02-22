import { Vue, Component, Prop } from "vue-property-decorator";
import { UserModule } from '@/store/modules/user';
import api from '@/utils/api';

@Component
export class BaseView extends Vue {
    get token() {
        return UserModule.getToken;
    }

    get shopMember() {
        return UserModule.getShopMember;
    }

    get addressList() {
        return UserModule.getAddressList;
    }

    initUser() {
        if (this.token) {
           api.userInit({}).then((res: any) => {
              if (res.success) UserModule.UserInit(res.data);
              else UserModule.Logout();
           });
        }
     }
}

export default {
    BaseView
}