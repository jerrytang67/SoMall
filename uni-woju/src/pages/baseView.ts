import { Vue, Component, Prop } from "vue-property-decorator";
import { UserModule } from '@/store/modules/user';
import { Tips } from '@/utils/tips';

@Component
export class BaseView extends Vue {
    public modalName: string = "";

    public loginBtnTest: string = "登录";

    // get token() {
    //     return UserModule.getToken;
    // }

    get openid() {
        return UserModule.getOpenid;
    }

    get userinfo() {
        return UserModule.getUserInfo;
    }

    initUser() {
        // if (this.token) {
        // }
    }

    bindGetUserInfo(e: any, back: boolean = false) {
        console.log(e);
        if (e.mp.detail.rawData) {
            //用户按了允许授权按钮
            UserModule.Login()
                .then((res: any) => {
                    console.log("getUserInfo", res);
                    if (back) { uni.navigateBack() }
                })
                .catch(error => {
                    Tips.info(error);
                });
        } else {
            //用户按了拒绝按钮
            Tips.info("请先授权");
        }
    };

    toLogin() {
        uni.navigateTo({ url: "/pages/index/login" })
    }

    toOrders() {
        uni.switchTab({ url: "/pages/orders/index" });
    }

    toShop(shopId: string) {
        uni.navigateTo({ url: `/pages/mall/shop?shopid=${shopId}`, })
    }

    toSpu(id: string) {
        uni.navigateTo({ url: "/pages/mall/spu-detail?id=" + id });
    }

    toHome() {
        uni.switchTab({ url: "/pages/index/index" })
    }

    toAddress(source: string = "") {
        uni.navigateTo({ url: "/pages/address/address" });
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