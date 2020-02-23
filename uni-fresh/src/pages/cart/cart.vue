
<template>
   <view>
      <view class="cu-list menu  card-menu margin-top">
         <view class="cu-item arrow" @click="toMyAddress">
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
         </view>
         <view class="cu-item arrow">
            <view class="content">
               <text class="cuIcon-time text-red"></text>
               <text class="text-black  text-bold text-lg">期望送达</text>
            </view>
            <view class="action" style="flex:1;">
               <view class="cu-tag line-red round light">立即送出</view>
               <text>今日 13:30</text>
            </view>
         </view>
      </view>

      <view class="cu-list menu card-menu margin-top">
         <view class="cu-item" style="padding:20rpx 0 20rpx 10rpx;" v-for="(x ,index) in cart" :key="index">
            <view class="cu-avatar round lg" :style="`background-image:url(${x.LogoUrl}!w300w);`"></view>
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
      <van-submit-bar :price="total * 100" button-text="生成订单" @submit="pay" :tip="true">
         <!-- <van-tag type="primary">标签</van-tag> -->
         <!-- <view slot="tip">
            您的收货地址不支持同城送, <text>修改地址</text>
         </view> -->
      </van-submit-bar>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { AppModule, IShopItem } from "@/store/modules/app";
import { UserModule } from "@/store/modules/user";
import { BaseView } from "../baseView";

import copyright from "@/components/copyright/index.vue";

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
      api.pay({
         address: this.defaultAddress,
         carts: this.cart,
         payType: "later",
         comment: "",
         totalPrice: this.total
      }).then((res: any) => {
         if (res.success) {
            uni.showToast({ title: "下单成功" });
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
.cartItem {
   padding: 30rpx 0;
   display: flex;
   flex-direction: column;
   &__wrap {
      display: flex;
      flex-direction: row;

      .col1 {
         width: 140rpx;
         text-align: center;
         image {
            width: 96rpx;
            height: 96rpx;
            border-radius: 50%;
         }
      }
      .col2 {
         flex: 1;
      }
      .col3 {
         width: 180rpx;
         font-size: 26rpx;
         color: #000;
         font-weight: 800;
      }
   }

   &__title {
      height: 75rpx;
      font-size: 26rpx;
      color: #000;
      font-weight: 800;
   }
}
</style>