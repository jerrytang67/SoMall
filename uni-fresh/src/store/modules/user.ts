import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
export interface IUserInfo {
    avatarUrl?: string;
    city?: string;
    country?: string;
    gender?: number;
    language?: string;
    nickName?: string;
    openid?: string;
    province?: string;
    unionid?: string;
}

export interface IShopMember {
    Id?: number;
    Balance?: number;
    DateTimeCreate?: Date;
    Name?: string;
    OrderCount?: number;
    StoreId?: number;
    Telphone?: string;
    nickname?: string;
    openid?: string;
    unionid?: string;
}

export interface IAddress {
    Id?: number;
    MemberId?: number;
    IsDefault?: boolean;
    DateTimeCreate?: Date;
    DateTimeLat?: Date;
    IsUserDelete?: boolean;
    Lat?: number;
    Lng?: number;
    LocationLable?: string;
    NickName?: string;
    Phone?: string;
    RealName?: string;
    StoreId?: number;
}


@Module({ dynamic: true, store, name: 'user' })
class User extends VuexModule {

    shopMember: IShopMember = {}

    addressList: IAddress[] = []

    userInfo: IUserInfo = uni.getStorageSync("userInfo") || {};

    token: string = uni.getStorageSync("token") || "";

    get getUserInfo() {
        return this.userInfo;
    }

    get getToken() {
        return this.token;
    }

    get getOpenid() {
        return this.userInfo.openid;
    }

    get getShopMember() {
        return this.shopMember;
    }

    get getAddressList() {
        return this.addressList;
    }

    @Mutation
    private SET_USERINFO(userInfo: IUserInfo) {
        console.log("Mutation:SET_USERINFO", userInfo);
        this.userInfo = userInfo
        uni.setStorageSync("userInfo", userInfo);
    }

    @Mutation
    private SET_TOKEN(token: string) {
        console.log("Mutation:SET_TOKEN", token);
        this.token = token;
        uni.setStorageSync("token", token);
    }

    @Action
    public Set_UserInfo(userInfo: IUserInfo) {
        this.SET_USERINFO(userInfo);
    }

    @Action
    public Set_Token(token: string) {
        this.SET_TOKEN(token);
    }

    @Action
    public UserInit(input: { addressList: IAddress[], shopMember: IShopMember }) {
        this.SET_ADDRESSLIST(input.addressList);
        this.SET_SHOPMEMBER(input.shopMember);
    }

    @Mutation
    private SET_ADDRESSLIST(addressList: IAddress[]) {
        console.log("Mutation:SET_ADDRESSLIST", addressList);
        this.addressList = addressList;
    }

    @Mutation
    private SET_SHOPMEMBER(shopMember: IShopMember) {
        console.log("Mutation:SET_SHOPMEMBER", shopMember);
        this.shopMember = shopMember;
    }


    // Logout
    @Action
    public Logout() {
        this.SET_TOKEN("");
        this.SET_USERINFO({});
        this.SET_SHOPMEMBER({});
        this.SET_ADDRESSLIST([]);
    }


}

export const UserModule = getModule(User)
