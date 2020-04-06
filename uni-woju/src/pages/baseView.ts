import { Vue, Component, Prop } from "vue-property-decorator";
import { UserModule } from '@/store/modules/user';
import api from '@/utils/api';
import { Tips } from '@/utils/tips';

@Component
export class BaseView extends Vue {

    public modalName: string = "";
    public loginBtnTest: string = "登录";

    get token() {
        return UserModule.getToken;
    }

    get openid() {
        return UserModule.getOpenid;
    }

    bindGetUserInfo(e: any) {
        console.log(e);
        if (e.mp.detail.rawData) {
            //用户按了允许授权按钮
            UserModule.Login()
                .then((res: any) => {
                    console.log("getUserInfo", res);
                })
                .catch(error => {
                    Tips.info(error);
                });
        } else {
            //用户按了拒绝按钮
            Tips.info("请先授权");
        }
    };

    initUser() {
        if (this.token) {
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