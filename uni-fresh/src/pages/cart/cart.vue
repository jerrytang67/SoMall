
<template>
   <view class="appContainer">
      <view class="cardWrap">
         <view class="card__cell" @click="toMyAddress">
            <view class="_icon">
               <van-icon name="location-o" />
            </view>
            <view class="_main">
               <view class="_title">
                  {{defaultAddress.LocationLable}}
               </view>
               <view class="_desc">
                  <view class="mr-2">{{defaultAddress.RealName}}</view>
                  <view>{{defaultAddress.Phone}}</view>
               </view>
            </view>
            <view class="_nav">
               <van-icon name="arrow" />
            </view>
         </view>
         <view class="line1"></view>
         <view class="card__cell">
            <view class="_icon">
               <van-icon name="clock-o" />
            </view>
            <view class="_main" style="flex:2;">
               <view class="_title">
                  期望送达时间
               </view>
            </view>
            <view class="_submain" style="flex:3;">
               <van-tag plain round color="#fa436a">立即送出</van-tag>
               <view>今日 13:30-14:00</view>
            </view>
            <view class="_nav">
               <van-icon name="arrow" />
            </view>
         </view>
      </view>
      <view class="cardWrap" v-if="cart.length">
         <view class="cardWrap__header">
            <view class="__title">我的订单</view>
            <view class="fill"></view>
            <view class="__more" @click="clearCart">
               清空
               <van-icon name="delete" style="font-size:40rpx;" />
            </view>
         </view>
         <view class="line1"></view>
         <view class="cartItem" v-for="(x ,index) in cart" :key="index">
            <view class="cartItem__wrap">
               <view class="col1">
                  <image :src="x.LogoUrl" />
               </view>
               <view class="col2">
                  <view class="cartItem__title">{{x.Name}}</view>
                  <view v-if="x.Desc">
                     {{x.Desc}}
                  </view>
               </view>
               <view class="col3">
                  {{x.PriceVip | currency}}
                  / {{x.Unit}}
               </view>
            </view>
            <view class="cartItem__wrap align_center">
               <view class="col1">
               </view>
               <view class="col2">
                  <van-stepper :value="x.Count" input-width="40px" button-size="32px" :min="0" :disable-input="true" @plus="cartAdd(x)" @minus="cartRemove(x)" />
               </view>
               <view class="col3"> {{x.PriceVip * x.Count | currency}}</view>
            </view>
            <view class="line1"></view>
         </view>
      </view>
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
import { AppModule } from "@/store/modules/app";
import { UserModule } from "@/store/modules/user";
import { BaseView } from "../baseView";

@Component
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
      return UserModule.getAddressList.find(x => x.IsDefault) || {};
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

   cartAdd(x: any) {
      AppModule.AddCart(x);
   }

   cartRemove(x: any) {
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