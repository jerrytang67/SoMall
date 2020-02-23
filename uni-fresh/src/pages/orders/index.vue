<template>
   <view>
      <scroll-view scroll-x class="bg-white nav">
         <view class="flex text-center">
            <view class="cu-item flex-sub" :class="index==TabCur?'text-orange cur':''" v-for="(item,index) in tabs" :key="index" @tap="tabSelect" :data-id="index">
               {{item}}
            </view>
         </view>
      </scroll-view>
      <!-- 
      <view class="cu-bar bg-white solid-bottom margin-top">
         <view class="action">
            <text class="cuIcon-title text-orange"></text> 菜单列表
         </view>
      </view> -->
      <view v-for="(x,index) in orders" :key="index" class="cu-list menu" :class="['sm-border','card-menu margin-top']">
         <view class="cu-item">
            <view class="content flex">
               <text class="text-grey">订单编号 #{{x.Id}}
               </text>
               <view class="cu-tag round bg-green light margin-left">{{x.State}}</view>
            </view>
            <view class="action">
               <text class="text-grey text-sm">
                  {{x.DateTimeCreate | formatDate}}
               </text>
            </view>
         </view>
         <view class="cu-item">
            <view class="content">
               <text class="text-grey">送货方式</text>
            </view>
            <view class="action">
               <text class="text-red text-lg">
                  {{x.Type}}
               </text>
            </view>
         </view>
         <template v-if="x.Type ==='外送'">
            <view class="cu-item">
               <view class="content">
                  <text class="cuIcon-profile text-olive"></text>
                  <text class="text-grey">收货人</text>
               </view>
               <view class="action">
                  <text class="text-grey text-sm">
                     {{x.AddressRealName}}
                  </text>
               </view>
            </view>
            <view class="cu-item">
               <view class="content">
                  <text class="cuIcon-phone text-olive"></text>
                  <text class="text-grey">手机号</text>
               </view>
               <view class="action">
                  <text class="text-grey text-sm">
                     {{x.AddressPhone}}
                  </text>
               </view>
            </view>
            <view class="cu-item">
               <view class="content">
                  <text class="cuIcon-location text-olive"></text>
                  <text class="text-grey">地址</text>
               </view>
               <view class="action">
                  <text class="text-grey text-sm">
                     {{x.AddressLocationLable}}
                  </text>
               </view>
            </view>
         </template>
         <view class="cu-item">
            <view class="content">
               <text class="cuIcon-recharge text-olive"></text>
               <text class="text-grey">预计应收</text>
            </view>
            <view class="action">
               <text class="text-olive text-sm">
                  {{x.PriceOriginal | currency}}
               </text>
            </view>
         </view>
         <view class="cu-item" v-if="x.State === '已完成'">
            <view class="content">
               <text class="cuIcon-recharge text-olive"></text>
               <text class="text-grey">实收</text>
            </view>
            <view class="action">
               <text class="text-red text-lg">
                  {{x.PricePaidIn | currency}}
               </text>
            </view>
         </view>

         <view class="cu-item">
            <view class="content padding-tb-sm">
               <view class="content">
                  <text class="cuIcon-goods text-olive"></text>
                  <text class="text-grey">商品明细</text>
               </view>
               <view class="text-gray text-sm">
                  <view v-for="(c,index2) in x.ShopCarts" :key="index2" class="flex">
                     <view style="flex:1;">
                        {{c.ShopItemName}} [{{c.ShopItemPrice | currency}}]
                     </view>
                     <view style="width:80rpx;">
                        x
                     </view>
                     <view style="width:150rpx;">
                        {{c.Count}} {{c.ShopItemUnit}}
                     </view>
                  </view>
               </view>
            </view>
         </view>
      </view>
      <copyright />
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { BaseView } from "../baseView";
import dayjs from "dayjs";

import copyright from "@/components/copyright/index.vue";

@Component({ components: { copyright } })
export default class About extends BaseView {
   get name() {
      return "TT";
   }

   TabCur = 0;
   scrollLeft = 0;
   menuBorder = true;
   menuCard = true;
   menuArrow = false;

   tabs: string[] = ["待配送", "配送中", "已完成"];

   title(v: any) {
      const date = dayjs(v.DateTimeCreate).format("YYYY-MM-DD HH:mm");
      return `#${v.Id} 时间:${date}`;
   }

   desc(v: any) {}

   orders: any[] = [];

   async onShow() {
      if (!this.openid) this.toLogin();
      await api.GetOrders().then((res: any) => {
         if (res.success) {
            this.orders = res.data;
         }
      });
   }

   tabSelect(e: any) {
      this.TabCur = e.currentTarget.dataset.id;
      this.scrollLeft = (e.currentTarget.dataset.id - 1) * 60;
   }

   created() {}
}
</script>

<style lang="scss">
.panel {
   margin: 20rpx 0;
}
.van-cell__title {
   flex: 2;
}
.van-cell__value {
   flex: auto !important;
}
</style>

