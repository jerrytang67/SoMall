<script lang="ts">
import Vue from "vue";
export default Vue.extend({
   mpType: "app",
   onLaunch() {
      console.log("App Launch");
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