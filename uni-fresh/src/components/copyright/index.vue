<template>
   <div class="copyright">
      <div class="">盛泽非常水果</div>
      <div class="flex-r-ac">
         Powered by <text class="link">SoMall</text>
         <!-- <img style="width:124rpx;height:42rpx;margin-left:24rpx;" class="img" src="/static/logo_copyright.png" /> -->
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

<style lang="scss">
.copyright {
   margin: 40rpx 25rpx;
   border-top: 1px #f1f1f1 dashed;
   height: 120rpx;
   display: flex;
   flex-direction: column;
   align-items: center;
   justify-content: space-around;
   font-size: 24rpx;
   color: #999;
   .link {
      margin-left: 10rpx;
      color: $base-color;
   }
}
</style>
