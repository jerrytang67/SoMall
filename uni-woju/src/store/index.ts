import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

interface StoreType {
    app: any;
    user: any;
    shop: any;
    address: any;
    permission: any;
    settings: any;
}

// Declare empty store first, dynamically register all modules later.
export default new Vuex.Store<StoreType>({})
