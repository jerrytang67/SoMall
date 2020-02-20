<template>
   <view class="box" :class="'animated fadeIn'">
      <view class="bd">
         <image :src="item.LogoUrl" class="item" />
      </view>
      <text class="main">{{itemitem.Desc}}</text>
      <text class="submain">{{item.Name}}</text>
      <view class="row">
         <text class="custom-price">会员价:</text>
         <text class="rmb">¥</text>
         <text class="price">{{item.PriceVip.toFixed(2)}}</text>
      </view>
      <view v-if="cartNum>0" class="stepper">
         <van-stepper :value="cartNum" input-width="40px" button-size="32px" :min="0" :disable-input="true" @plus="cartAdd" @minus="cartRemove" />
      </view>
      <view class="ft" @click="cartAdd" v-else>
         <text class="buy-now">加入购物车</text>
         <image src="/static/temp/cb3a958053bd11eaa96f8f9f95bf0b87.png" class="img" />
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Prop, Watch } from "vue-property-decorator";
import api from "@/utils/api";
import { AppModule } from "../../store/modules/app";
@Component
export default class Style1 extends Vue {
   @Prop({ required: true }) item: any;

   get cartNum() {
      let inCart = AppModule.getCart.filter(x => x.Id === this.item.Id)[0] || {
         Count: 0
      };
      console.log("inCart", inCart.Count);
      return inCart.Count;
   }

   cartAdd() {
      AppModule.AddCart(this.item);
   }

   cartRemove() {
      AppModule.RemoveCart(this.item);
   }
}
</script>

<style lang="scss" scoped>
.box {
   display: flex;
   align-items: flex-start;
   flex-direction: column;
   background-color: #ffffff;
   width: 272rpx;
   height: 460rpx;
   overflow: hidden;
   margin-bottom: 18rpx;
   box-shadow: 2upx 2upx 4upx rgba(20, 20, 20, 0.3);
}
.bd {
   display: flex;
   align-items: flex-start;
   flex-direction: row;
   background-color: #e2e2e2;
   width: 272rpx;
   height: 301rpx;
   overflow: hidden;
}
.item {
   margin-top: 3rpx;
   width: 272rpx;
   height: 298rpx;
}
.main {
   margin-top: 14rpx;
   margin-left: 11rpx;
   max-width: 261rpx;
   height: 20rpx;
   overflow: hidden;
   text-align: left;
   text-decoration: none;
   text-overflow: ellipsis;
   line-height: 20rpx;
   letter-spacing: 0rpx;
   white-space: nowrap;
   color: $uni-text-color;
   font-size: 19rpx;
}
.submain {
   margin-top: 9rpx;
   margin-left: 11rpx;
   max-width: 261rpx;
   height: 30rpx;
   overflow: hidden;
   text-align: left;
   line-height: 28rpx;
   color: $uni-text-color;
   font-size: 28rpx;
}
.row {
   display: flex;
   align-items: center;
   flex-direction: row;
   margin-top: 12rpx;
   height: 34rpx;
}
.custom-price {
   display: flex;
   flex-direction: row;
   justify-content: center;
   margin-left: 12rpx;
   color: $base-color;
   font-size: 20rpx;
}
.rmb {
   margin-left: 12rpx;
   height: 24rpx;
   white-space: nowrap;
   color: $base-color;
   font-size: 22rpx;
}
.price {
   margin-left: 8rpx;
   height: 34rpx;
   overflow: hidden;
   text-decoration: none;
   text-overflow: ellipsis;
   white-space: nowrap;
   color: $base-color;
   font-size: 32rpx;
}
.ft {
   margin-top: 10rpx;
   display: flex;
   align-items: center;
   flex-direction: row;
   justify-content: center;
   background-color: $base-color;
   width: 100%;
   height: 60rpx;
}
.buy-now {
   height: 28rpx;
   text-decoration: none;
   line-height: 28rpx;
   white-space: nowrap;
   color: #ffffff;
   font-size: 26rpx;
}
.img {
   margin-left: 18rpx;
   width: 8rpx;
   height: 14rpx;
   overflow: hidden;
}

.stepper {
   display: flex;
   justify-content: center;
   text-align: center;
   width: 100%;
}
</style>