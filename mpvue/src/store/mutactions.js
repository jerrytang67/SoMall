export const mutations = {
  SET_OPENID: (state, v) => {
    state.openid = v.openid;
    state.unionid = v.unionid;
    wx.setStorageSync("openid", v.openid);
    if (v.unionid) wx.setStorageSync("unionid", v.unionid);
  },
  USER_INFO: (state, v) => {
    wx.setStorageSync("userInfo", v);
    state.userInfo = v;
  }
};
export default mutations;
