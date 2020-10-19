import utils from "./utils";
import { UserModule, IAddress } from '@/store/modules/user';

let host = process.env.VUE_APP_BASE_API;
//host = "http://localhost:8088"
//host = "https://www.lovewujiang.com"
const TenantId = 2;

const getRequest = utils.httpsPromisify(uni.request);

const request = (
    method: 'OPTIONS' | 'GET' | 'HEAD' | 'POST' | 'PUT' | 'DELETE' | 'TRACE' | 'CONNECT',
    url: string,
    data: string | object | ArrayBuffer) => {


    uni.showLoading({});
    uni.showNavigationBarLoading();

    let _url = (url.startsWith("http") ? url : host + url);

    // method为请求方法，url为接口路径，data为传参
    return getRequest({
        url: _url,
        data: data,
        method: method,
        header: {
            "content-type": "application/json",
            "Authorization": `Bearer ${UserModule.getToken || ''}`,
            "Abp.TenantId": `${TenantId}`,
        }
    });
};

export default {
    init: (data: any) => request('GET', `/Wx/getShopInit?appId=wx1dfe7106c7a40821`, data),
    userInit: (data: any) => request('GET', `/Wx/UserInit`, data),
    postUserInfo: (data: any) => request('POST', `/api/WoJu/postUserInfo2`, data),
    pay: (data: any) => request('POST', `/Api/V1/SomePostWithToken`, data),

    postNewAddress: (data: IAddress) => request('POST', `/Wx/PostNewAddress`, { address: data }),
    AddressDelete: (data: IAddress) => request('POST', `/Api/V1/AddressDeleteWithToken`, data),
    AddressEdit: (data: IAddress) => request('POST', `/Api/V1/AddressEdit`, data),
    SetAddressDefault: (data: { Id: number }) => request('POST', `/Api/V1/SetAddressDefault`, data),

    GetOrders: (data: any = {}) => request('POST', `/Api/V1/GetOrders`, data),
    GetPhone: (data: any) => request('POST', `/Api/WoJu/GetPhone`, data)

};