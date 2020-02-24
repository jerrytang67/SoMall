import Vue from 'vue'
import App from './App.vue'

import filter from '@/utils/filter'

Vue.config.productionTip = false
Vue.filter('formatDate', filter.formatDate)
Vue.filter('currency', filter.currency)
new App().$mount()
