import Vue from 'vue'
import App from './App'
import store from './store'
import api from './utils/api'

Vue.config.productionTip = false
App.mpType = 'app'
Vue.prototype.$store = store
Vue.prototype.$api = api
const app = new Vue(App)
app.$mount()
