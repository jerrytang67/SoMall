<script lang="ts">
import Vue from "vue";
import { AppModule } from "./store/modules/app";
import { UserModule } from './store/modules/user';
export default Vue.extend({
   mpType: "app",
   async onLaunch() {
      console.log("App Launch");
      UserModule.CheckLogin();
      AppModule.Init();
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
@import "./styles/main.scss";
@import "./colorui/main.css";
@import "./colorui/icon.css";
</style>