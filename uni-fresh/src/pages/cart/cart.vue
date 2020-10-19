
<template>
   <view>
      <view class="cu-list menu  card-menu margin-top">
         <view class="cu-item">
            <view class="content padding-tb-sm">
               <view class="content">
                  <text class="cuIcon-location text-red"></text>
                  <text class="text-black text-bold text-lg">{{defaultAddress.LocationLable}}</text>
               </view>
               <view class="text-black flex  " style="margin-left:calc(1.6em + 10rpx)">
                  <view>{{defaultAddress.RealName}}</view>
                  <view>{{defaultAddress.Phone}}</view>
               </view>
            </view>
            <view class="action">
               <button class="cu-btn round bg-white shadow sm" @click="toMyAddress">
                  重新选择</button>
            </view>
         </view>
         <view class="cu-item arrow">
            <view class="content">
               <text class="cuIcon-time text-red"></text>
               <text class="text-black  text-bold text-lg">期望送达</text>
            </view>
            <view class="action" style="flex:1;">
               <view class="cu-tag line-red round light">立即送出</view>
               <!-- <text>今日 13:30</text> -->
            </view>
         </view>
      </view>

      <view class="cu-list menu card-menu margin-top">
         <view class="cu-item" style="padding:20rpx 0 20rpx 10rpx;" v-for="(x ,index) in cart" :key="index">
            <view class="cu-avatar radius lg margin-right" :style="'background-image:url('+x.LogoUrl+'!w300w);'"></view>
            <view class="content">
               <view class="text-grey">{{x.Name}}</view>
               <view class="text-gray text-sm flex">
                  <text class="text-cut">
                     <text class="cuIcon-moneybag text-red margin-right-xs"></text>
                     <text class="text-red text-lg margin-right-xs">
                        {{x.PriceVip}}元
                     </text>/{{x.Unit}}
                  </text> </view>
            </view>
            <view class="action" style="width:140rpx;">
               <view class="flex justify-end align-center ">
                  <button v-show="x.Count>0" @click="cartRemove(x)" class="cu-btn" style="background:none;padding:0">
                     <text class="cuIcon-move text-green" style="font-size:50rpx;"></text></button>
                  <text v-show="x.Count>0" class="text-red text-xl margin-lr text-bold">
                     {{x.Count}}
                  </text>
                  <button @click="cartAdd(x)" class="cu-btn" style="background:none;padding:0">
                     <text class="cuIcon-add text-green" style="font-size:50rpx;"></text></button>
               </view>
            </view>
         </view>
      </view>
      <copyright />
      <view style="height:100rpx;"></view>
      <view class="cu-bar bg-white tabbar border shop fix-bottom ">
         <button class="action" open-type="contact">
            <view class="cuIcon-service text-green">
            </view>
            <text class="text-green">客服</text>
         </button>
         <view class="submit" :class="[total>miniPay?'bg-red':'bg-grey']" @tap="pay">生成订单 {{ totalText  }}</view>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { AppModule, IShopItem } from "@/store/modules/app";
import { UserModule } from "@/store/modules/user";
import { BaseView } from "../baseView";

import copyright from "@/components/copyright/index.vue";
import { Tips } from "@/utils/tips";

@Component({ components: { copyright } })
export default class Cart extends BaseView {
   created() {
      // uni.getLocation({
      //    type: "wgs84",
      //    success: res => {
      //       console.log("当前位置的经度：" + res.longitude);
      //       console.log("当前位置的纬度：" + res.latitude);
      //    }
      // });
   }

   get miniPay() {
      return AppModule.shop.Setting.MinOutPrice || 100;
   }

   get defaultAddress() {
      return (
         UserModule.getAddressList.find(x => x.IsDefault) || {
            LocationLable: "请选择地址",
            RealName: "",
            Phone: ""
         }
      );
   }

   get total() {
      return AppModule.getCartTotal;
   }

   get totalText() {
      return `￥${this.total.toFixed(2)}`;
   }

   get cart() {
      return AppModule.getCart;
   }

   async getProduct() {
      uni.navigateTo({ url: "/pages/orders/index" });
   }

   onShow() {
      if (!this.openid) this.toLogin();
      //this.initUser();
   }

   pay() {
      if (this.cart.length <= 0) {
         uni.showToast({ title: "购物车为空" });
         return;
      }

      if (this.total < this.miniPay) {
         Tips.info(`最低满 ${this.miniPay}元开始配送`, 2000);
         return;
      }
      api.pay({
         address: this.defaultAddress,
         carts: this.cart,
         payType: "later",
         comment: "",
         totalPrice: this.total
      }).then((res: any) => {
         if (res.success) {
            Tips.info("下单成功,请等待配货", 1500);
            AppModule.ClearCart();
            setTimeout(() => {
               this.toOrders();
            }, 1500);
         }
      });
   }

   cartAdd(x: IShopItem) {
      AppModule.AddCart(x);
   }

   cartRemove(x: IShopItem) {
      AppModule.RemoveCart(x);
   }

   async clearCart() {
      await AppModule.ClearCart();
      setTimeout(() => {
         uni.switchTab({ url: "/pages/index/index" });
      }, 500);
   }

   toMyAddress() {
      uni.navigateTo({ url: "/pages/user/myAddress" });
   }
}
</script>

<style lang="scss" scoped>
</style>