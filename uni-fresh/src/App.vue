<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { UserModule } from "@/store/modules/user";
import api from "@/utils/api";
import { AppModule } from "./store/modules/app";
import { SystemModule } from "./store/modules/system";

import { BaseView } from "@/pages/baseView.ts";

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
@import "./graceUI/graceUI.css";
@import "./colorui/icon.css";
</style>