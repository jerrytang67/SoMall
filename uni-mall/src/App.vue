<script lang="ts">
import Vue from "vue";
import { AppModule } from "./store/modules/app";
import { UserModule } from "./store/modules/user";
export default Vue.extend({
   mpType: "app",
   async onLaunch() {
      console.log("App Launch");
      UserModule.CheckLogin();
      try {
         const res = uni.getSystemInfoSync();
         // console.log(res.model);
         // console.log(res.pixelRatio);
         // console.log(res.windowWidth);
         // console.log(res.windowHeight);
         // console.log(res.language);
         // console.log(res.version);
         // console.log(res.platform);
         AppModule.Init({ SystemInfo: res });
      } catch (e) {
         // error
      }
   },
   onShow() {
      // console.log("App Show");
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
@import "./colorui/yticon.scss";
</style>