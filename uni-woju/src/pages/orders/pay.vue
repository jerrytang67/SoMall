<template>
   <view class="app">
      <view class="price-box">
         <text>支付金额</text>
         <text class="price">38.88</text>
      </view>
      <view class="pay-type-list">
         <view class="type-item b-b" @click="changePayType(1)">
            <text class="icon yticon icon-weixinzhifu"></text>
            <view class="con">
               <text class="tit">微信支付</text>
               <text>推荐使用微信支付</text>
            </view>
            <label class="radio">
               <radio value="" color="#fa436a" :checked='payType == 1'></radio>
            </label>
         </view>
         <!-- <view class="type-item b-b" @click="changePayType(2)">
            <text class="icon yticon icon-alipay"></text>
            <view class="con">
               <text class="tit">支付宝支付</text>
            </view>
            <label class="radio">
               <radio value="" color="#fa436a" :checked='payType == 2'></radio>
            </label>
         </view> -->
         <view class="type-item" @click="changePayType(3)">
            <text class="icon yticon icon-erjiye-yucunkuan"></text>
            <view class="con">
               <text class="tit">预存款支付</text>
               <text>可用余额 ¥198.5</text>
            </view>
            <label class="radio">
               <radio value="" color="#fa436a" :checked='payType == 3'></radio>
            </label>
         </view>
      </view>

      <text class="mix-btn" @click="confirm">确认支付</text>
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { BaseView } from "../baseView"

@Component
export default class Pay extends BaseView {
   async onLoad(options: any) {
      if (options.orderId) {
         this.orderId = options.orderId;
      }


   }
   orderId: string = "1dfc93f4-56ab-242f-da0a-39f489957e08";
   payType = 1;
   orderInfo = {};

   changePayType(type: any) {
      this.payType = type;
   }

   //确认支付
   async confirm() {
       if(this.payType === 1)
       {

       }
       else{
      uni.redirectTo({
         url: "/pages/orders/paySuccess"
      });}
   }
}
</script>

<style lang='scss'>
.app {
   width: 100%;
}

.price-box {
   background-color: #fff;
   height: 265upx;
   display: flex;
   flex-direction: column;
   justify-content: center;
   align-items: center;
   font-size: 28upx;
   color: #909399;

   .price {
      font-size: 50upx;
      color: #303133;
      margin-top: 12upx;
      &:before {
         content: "￥";
         font-size: 40upx;
      }
   }
}

.pay-type-list {
   margin-top: 20upx;
   background-color: #fff;
   padding-left: 60upx;

   .type-item {
      height: 120upx;
      padding: 20upx 0;
      display: flex;
      justify-content: space-between;
      align-items: center;
      padding-right: 60upx;
      font-size: 30upx;
      position: relative;
   }

   .icon {
      width: 100upx;
      font-size: 52upx;
   }
   .icon-erjiye-yucunkuan {
      color: #fe8e2e;
   }
   .icon-weixinzhifu {
      color: #36cb59;
   }
   .icon-alipay {
      color: #01aaef;
   }
   .tit {
      font-size: $font-lg;
      color: $font-color-dark;
      margin-bottom: 4upx;
   }
   .con {
      flex: 1;
      display: flex;
      flex-direction: column;
      font-size: $font-sm;
      color: $font-color-light;
   }
}
.mix-btn {
   display: flex;
   align-items: center;
   justify-content: center;
   width: 630upx;
   height: 80upx;
   margin: 80upx auto 30upx;
   font-size: $font-lg;
   color: #fff;
   background-color: $base-color;
   border-radius: 10upx;
   box-shadow: 1px 2px 5px rgba(219, 63, 96, 0.4);
}
</style>
