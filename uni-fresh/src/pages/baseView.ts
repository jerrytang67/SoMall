import { Vue, Component, Prop } from "vue-property-decorator";
import { UserModule } from '@/store/modules/user';
import api from '@/utils/api';

@Component
export class BaseView extends Vue {

    public modalName: string = "";

    get token() {
        return UserModule.getToken;
    }

    get userInfo() {
        return UserModule.getUserInfo;
    }

    get shopMember() {
        return UserModule.getShopMember;
    }

    get addressList() {
        return UserModule.getAddressList;
    }

    get openid() {
        return UserModule.getOpenid;
    }

    initUser() {
        if (this.token) {
            api.userInit({}).then((res: any) => {
                if (res.success) UserModule.UserInit(res.data);
                else UserModule.Logout();
            });
        }
    }

    toLogin() {
        uni.navigateTo({ url: "/pages/index/login" })
    }

    toOrders() {
        uni.switchTab({ url: "/pages/orders/index" });
    }

    toHome() {
        uni.switchTab({ url: "/pages/index/index" })
    }

    showModal(e: any) {
        console.log(e);

        this.modalName = e.currentTarget.dataset.target
    }

    hideModal() {
        this.modalName = ""
    }
}

export default {
    BaseView
}