<template>
   <view class="content">
      <image class="logo" src="../../static/logo.png"></image>
      <view>
         <text class="title">{{title}}</text>
         <button @click="click">About</button>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
@Component({})
export default class About extends Vue {
   get title() {
      return "Hello";
   }

   created() {
   }

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
