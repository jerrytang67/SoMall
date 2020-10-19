<template>
   <div class="margin-lg flex-direction justify-center text-center text-grey" style="font-size:26upx;">
      <div>SoMall Fresh</div>
      <div class="flex align-center  justify-center margin-tb-xs">
         Powered by <text class="margin-left-xs text-red">SoMall</text>
      </div>
      <div>版本号:{{version}}</div>
   </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";

@Component
export default class Copyright extends Vue {
   version = "0.1.0";
}
</script>

// <style lang="scss">
// .copyright {
//    margin: 40rpx 25rpx;
//    border-top: 1px #f1f1f1 dashed;
//    height: 120rpx;
//    display: flex;
//    flex-direction: column;
//    align-items: center;
//    justify-content: space-around;
//    font-size: 24rpx;
//    color: #999;
//    .link {
//       margin-left: 10rpx;
//    }
// }
//
</style>
