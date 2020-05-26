// declare module "*.vue" {
//     import Vue from 'vue'
//     export default Vue
// }
import Vue from 'vue'
declare module 'vue/types/vue' {
    // 可以使用 `VueConstructor` 接口
    // 来声明全局 property
    interface VueConstructor {
        $wechat: any
    }
}