import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import store from '@/store'
import api from '@/utils/api'
import { ShopModule } from './shop';

@Module({ dynamic: true, store, name: 'app' })
class App extends VuexModule {

    @Action
    public Init(data: any = {}) {
        api.init(data).then((res: any) => {
            //console.log(res);
            ShopModule.SetList(res.shops);
            ShopModule.SetCategories(res.categories);
            ShopModule.SetIndexSpus(res.spus);
        });
    }
}

export const AppModule = getModule(App)
