import utils from "./utils"; // 此处，引入存放对promise处理的文件
import Tips from "./Tips";
//自定义设置
const STOREID = 6;
const APPID = "wx20963173630db476"; //小程序 appid

const host = 'http://192.168.1.181:8088/api' // 后台的ip地址

const getRequest = utils.httpsPromisify(wx.request);
const request = (method, url, data = {}) => {
  // method为请求方法，url为接口路径，data为传参
  Tips.loading();
  return getRequest({
    url: (url.startsWith("http") ? url : host + url),
    data: data,
    method: method,
    header: {
      "content-type": "application/json",
      Authorization: `Bearer ${wx.getStorageSync("token")||''}`
    }
  });
};

export default {
  postUserInfo: data => request("post", `WoJu/postUserInfo`, data),
};
