import utils from "./utils";

let host = process.env.VUE_APP_BASE_API;

const getRequest = utils.httpsPromisify(uni.request);

const request = (
    method: 'OPTIONS' | 'GET' | 'HEAD' | 'POST' | 'PUT' | 'DELETE' | 'TRACE' | 'CONNECT',
    url: string,
    data?: string | object | ArrayBuffer | undefined) => {

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
            "Authorization": `Bearer ${uni.getStorageSync("token") || ''}`,
        }
    });
};

export default {
    // default
    init: (data: any) => request('POST', `/api/mall/client/init`, data),
    checkLogin: () => request("GET", `/api/app/weixin/checkLogin?dbCheck=true`),
    getPhone: (data: any) => request("GET", `/api/app/weixin/getPhone`),

    // auth
    client_miniAuth: (data: any) => request("POST", `/api/mall/client/miniAuth`, data),

    //user 
    client_getUserAddressList: () => request("GET", `/api/mall/client/getUserAddressList`),

    //shop
    shop_get: (id: string) => request("GET", `/api/mall/mallShop/get`, { id: id }),

    //mallspu
    spu_getList: (data: any) => request("GET", `/api/mall/productSpu/getList`, data),
    spu_get: (data: any) => request("GET", `/api/mall/productSpu/get`, data),


    //address
    address_delete: (data: any) => request("DELETE", `/api/mall/address/delete`, data),
    address_create: (data: any) => request("POST", `/api/mall/productSpu/create`, data),
    address_update: (data: any) => request("PUT", `/api/mall/productSpu/update`, data),
    address_setDefault: (data: any) => request("POST", `/api/mall/productSpu/setDefault`, data)
};