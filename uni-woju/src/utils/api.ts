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
    init: (data: any) => request('POST', `/api/mall/client/init`, data),
    checkLogin: () => request("GET", `/api/app/weixin/checkLogin?dbCheck=true`),
    //user 
    weixin_miniAuth: (data: any) => request("POST", `/api/mall/client/miniAuth`, data),

    //mallShop
    mallShop_get: (id: string) => request("GET", `/api/mall/mallShop/get`, { id: id }),

    //mallspu
    spu_getList: (data: any) => request("GET", `/api/mall/productSpu/getList`, data),
};