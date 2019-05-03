import api from '../utils/api';

export const actions = {
  setUserInfo: (context, v) => {
    context.commit("USER_INFO", v);
    if (v) {
       api.postUserInfo(v).then(res => {
         wx.setStorageSync("token", res.token);
         context.commit("SET_OPENID", res);
       });
    }
  }
}
export default actions;
