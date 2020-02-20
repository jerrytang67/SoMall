import Vue from 'vue'
import Vuex from 'vuex'
// import { IAppState } from './modules/app'
// import { IUserState } from './modules/user'

Vue.use(Vuex)

interface StoreType {
  app: any
  user: any
  permission: any
  settings: any
}

// Declare empty store first, dynamically register all modules later.
export default new Vuex.Store<StoreType>({})
