<template>
   <view class="content">
      <navigator url="plugin-private://wx2b03c6e691cd7370/pages/live-player-plugin?room_id=1">
         <image class="logo" src="../../static/head.jpg"></image>
         <view>
            <text class="title">{{title}}</text>
         </view>
      </navigator>

   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
@Component({})
export default class About extends Vue {
   get title() {
      return "TT的直播间";
   }

   get roomId() {
      return 1;
   }

   created() {}

   async click() {
      uni.navigateTo({
         url: "/pages/index/about"
      });
      await api.init({ s: 123 }).then(res => {});
   }
}
</script>
<style>
.content {
   text-align: center;
   height: 400upx;
}

.logo {
   height: 200upx;
   width: 200upx;
   margin-top: 200upx;
}

.title {
   font-size: 36upx;
   color: #8f8f94;
}
</style>
