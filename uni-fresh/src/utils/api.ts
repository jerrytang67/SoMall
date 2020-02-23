import utils from "./utils";
import { UserModule, IAddress } from '@/store/modules/user';

let host = process.env.VUE_APP_BASE_API;

const TenantId = 2;

const getRequest = utils.httpsPromisify(uni.request);

const request = (
    method: 'OPTIONS' | 'GET' | 'HEAD' | 'POST' | 'PUT' | 'DELETE' | 'TRACE' | 'CONNECT',
    url: string,
    data: string | object | ArrayBuffer) => {

    uni.showLoading();
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
    init: (data: any) => request('GET', `https://www.lovewujiang.com/Wx/getShopInit?appId=wx1dfe7106c7a40821`, data),
    userInit: (data: any) => request('GET', `https://www.lovewujiang.com/Wx/UserInit`, data),
    postUserInfo: (data: any) => request('POST', `https://www.lovewujiang.com/api/WoJu/postUserInfo2`, data),
    pay: (data: any) => request('POST', `https://www.lovewujiang.com/Api/V1/SomePostWithToken`, data),

    postNewAddress: (data: IAddress) => request('POST', `https://www.lovewujiang.com/Wx/PostNewAddress`, { address: data }),
    SetAddressDefault: (data: { Id: number }) => request('POST', `https://www.lovewujiang.com/Api/V1/SetAddressDefault`, data),

    GetOrders: (data: any = {}) => request('POST', `https://www.lovewujiang.com/Api/V1/GetOrders`, data),

};