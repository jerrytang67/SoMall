// https://vuex.vuejs.org/zh-cn/intro.html
// make sure to call Vue.use(Vuex) if using a module system
import Vue from "vue";
import Vuex from "vuex";

import mutations from "./mutactions";
import actions from "./actions";
import getters from "./getters";

Vue.use(Vuex);

const state = {
  openid: wx.getStorageSync("openid"),
  unionid: wx.getStorageSync("unionid")
};

export default new Vuex.Store({
  state,
  getters,
  mutations,
  actions
});
