<template>
   <view class="content">
      <view class="cu-card" v-for="(x,idx) in shops" :key="idx">
         <view class="cu-item shadow" @tap="toShop(x.id)">
            <view class="title">
               <view class="text-cut">{{x.name}}</view>
            </view>
            <view class="content">
               <image :src="x.logoImage" mode="widthFix" style="width:150upx;"></image>
               <!-- <view class="desc">
                  <view class="text-content" v-html="x.description">
                  </view>
               </view> -->
            </view>
         </view>
      </view>
      <view class="padding-xl">
         <button v-if="!openid" class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" open-type="getUserInfo" @getuserinfo="bindGetUserInfo">
            {{loginBtnTest}}</button>
         <button v-else class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" @tap.stop="submit">
            <text class="cuIcon-loading2 cuIconfont-spin" v-if="loadding"></text>
            提交</button>
      </view>
      <navigator url="plugin-private://wx2b03c6e691cd7370/pages/live-player-plugin?room_id=2">
         <image class="logo" src="../../static/head.jpg"></image>
         <view>
            <text class="title">{{title}}</text>
         </view>
      </navigator>

   </view>
</template>
<script lang="ts">
// pageBase
import { BaseView } from "@/pages/baseView.ts";

import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { ShopModule } from "@/store/modules/shop";
import api from "@/utils/api";
@Component
export default class About extends BaseView {
   theme = "black";
   get title() {
      return "TT的直播间";
   }

   get roomId() {
      return 2;
   }

   get shops() {
      return ShopModule.shops;
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
   /* height: 400upx; */
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
