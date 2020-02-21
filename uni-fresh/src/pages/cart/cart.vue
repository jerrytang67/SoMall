
<template>
   <view>
      <view class="cartWrap">
         <view v-for="(x ,index) in cart" :key="index">
            <van-card :price="x.PriceVip" :desc="x.Desc" :title="x.Name" :thumb="x.LogoUrl">
               <view slot="bottom" style="display:flex;justify-items: flex-end;">
                  <van-stepper :value="x.Count" input-width="40px" button-size="32px" :min="0" :disable-input="true" @plus="cartAdd(x)" @minus="cartRemove(x)" />
               </view>
            </van-card>
         </view>
      </view>
      <van-submit-bar :price="total * 100" button-text="提交订单" @submit="onClickButton" :tip="true">
         <van-tag type="primary">标签</van-tag>
         <view slot="tip">
            您的收货地址不支持同城送, <text>修改地址</text>
         </view>
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
}
</script>

<style lang="scss" scoped>
.cartWrap {
   margin: 40rpx;
}
</style>