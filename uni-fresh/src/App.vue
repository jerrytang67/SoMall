<script lang="ts">
import Vue from "vue";
import { AppModule } from "./store/modules/app";
import { SystemModule } from "./store/modules/system";
export default Vue.extend({
   mpType: "app",
   onLaunch() {
      console.log("App Launch");
      AppModule.Init();
      SystemModule.Set_Info(uni.getSystemInfoSync());
   },
   onShow() {
      console.log("App Show");
   },
   onHide() {
      console.log("App Hide");
   }
});
</script>

<style lang="scss">
@import "./graceUI/graceUI.css";
@import "./colorui/main.css";
@import "./colorui/icon.css";
</style>