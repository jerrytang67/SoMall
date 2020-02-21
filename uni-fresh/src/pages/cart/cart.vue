
<template>
   <view class="appContainer">
      <view class="cardWrap">
         <view class="card__cell" @click="toMyAddress">
            <view class="_icon">
               <van-icon name="location-o" />
            </view>
            <view class="_main">
               <view class="_title">
                  东方花园小区33幢3单元1301
               </view>
               <view class="_desc">
                  <view>name</view>
                  <view>138868998</view>
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
      <van-submit-bar :price="total * 100" button-text="生成订单" @submit="onClickButton" :tip="true">
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
@Component({})
export default class Cart extends Vue {
   created() {
      uni.getLocation({
         type: "wgs84",
         success: res => {
            console.log("当前位置的经度：" + res.longitude);
            console.log("当前位置的纬度：" + res.latitude);
         }
      });
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

   onClickButton() {}

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
.cardWrap {
   margin: 40rpx 0;
   width: 710rpx;
   border-radius: 10rpx;
   box-shadow: 0 4rpx 6rpx #ddd, 0 4rpx 6rpx #ccc;
   &__header {
      height: 70rpx;
      display: flex;
      flex-direction: row;
      align-items: center;
      .__title {
         margin-left: 30rpx;
         font-size: 26rpx;
         font-weight: 600;
         color: $font-color-dark;
      }
      .__more {
         margin-right: 20rpx;
         font-size: 26rpx;
         font-weight: 600;
         color: $font-color-dark;
         display: flex;
         flex-direction: row;
      }
   }
}

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

.card__cell {
   display: flex;
   padding: 20rpx 0 20rpx 20rpx;
   flex-direction: row;
   align-items: center;
   ._icon {
      font-size: 40rpx;

      width: 60rpx;
   }
   ._main {
      flex: 1;
      ._title {
         font-size: 32rpx;
         font-weight: 800;
         color: $font-color-dark;
      }
      ._desc {
         color: $uni-text-color;
         display: flex;
         flex-direction: row;
      }
   }
   ._submain {
      display: flex;
      flex: 1;
      flex-direction: row;
      align-items: center;
      justify-content: space-around;
   }
   ._nav {
      font-size: 48rpx;
      color: $uni-text-color-grey;
   }
}
</style>