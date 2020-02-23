<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
// api 
import api from "@/utils/api";
// pageBase
import { BaseView } from "@/pages/baseView.ts";
// store
import { AppModule } from "./store/modules/app";
import { SystemModule } from "./store/modules/system";
import { UserModule } from "@/store/modules/user";


@Component
export default class extends BaseView {
   @Watch("token")
   onTokenChange(token: string) {
      console.log("token changed;");
      this.initUser();
   }
   onLaunch() {
      console.log("App Launch");
      AppModule.Init();
      SystemModule.Set_Info(uni.getSystemInfoSync());
      this.initUser();
   }
   onShow() {
      console.log("App Show");
   }
   onHide() {
      console.log("App Hide");
   }
}
</script>

<style lang="scss">
@import "./styles/main.scss";
@import "./colorui/main.css";
@import "./colorui/icon.css";
</style>