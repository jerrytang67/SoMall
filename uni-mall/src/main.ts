import Vue from 'vue'
import App from './App.vue'

Vue.config.productionTip = false
new App().$mount()
// #ifdef H5  
import wechat from './utils/wechat'
if (wechat.isWechat()) {
    Vue.prototype.$wechat = wechat;
    wechat.initJssdk(() => {

    });
}
// #endif