<template>
  <view class="item-wrap">
    <image src="http://img.wjhaomama.com/6/img/2019-05/14_30_56_860.png!wh500" class="item"></image>
    <text class="info">全场新款满500减20</text>
    <image src="http://img.wjhaomama.com/6/img/2019-05/14_36_13_322.png" class="txt-bg"></image>
    <text class="title">英伦风时尚男款外套</text>
    <view class="origin-price-wrap">
      <text class="counter-price">专柜价：</text>
      <text class="origin-price">¥666666.00</text>
    </view>
    <view class="block">
      <image src="http://img.wjhaomama.com/6/img/2019-05/14_38_00_566.png" class="logo"></image>
      <view class="money-wrap">
        <text class="rmb">¥</text>
        <text class="money">666666.00</text>
      </view>
    </view>
    <view class="grid">
      <view class="col-1">
        <text class="voucher">券</text>
        <image src="http://img.wjhaomama.com/6/img/2019-05/14_36_59_865.png" class="vertical-line"></image>
        <text class="price">¥1000</text>
      </view>
      <view class="col-2">
        <text class="tag">立即购买</text>
      </view>
    </view>
  </view>
</template>
<script>
export default {
  onReady() {},
  props: [],
  computed: {
  },
  data() {
    return {
    };
  },
  methods: {}
}
</script>
<style scoped>
.item-wrap {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  background-color: #ffffff;
  width: 348rpx;
  height: 610rpx;
  overflow: hidden;
}
.item {
  width: 348rpx;
  height: 348rpx;
}
.info {
  margin-top: 11rpx;
  margin-left: 15rpx;
  max-width: 306rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ff0036;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.txt-bg {
  margin-top: 10rpx;
  width: 348rpx;
  height: 2rpx;
}
.title {
  margin-top: 9rpx;
  margin-left: 15rpx;
  max-width: 306rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 37rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 400;
}
.origin-price-wrap {
  display: flex;
  flex-direction: row;
  margin-top: 1rpx;
  margin-left: 15rpx;
  height: 28rpx;
}
.counter-price {
  text-align: left;
  line-height: 28rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 20rpx;
  font-weight: 400;
}
.origin-price {
  max-width: 226rpx;
  overflow: hidden;
  text-align: left;
  text-decoration: line-through;
  text-overflow: ellipsis;
  line-height: 28rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 20rpx;
  font-weight: 400;
}
.block {
  display: flex;
  flex-direction: row;
  width: 348rpx;
  height: 41rpx;
}
.logo {
  margin-top: 7rpx;
  margin-left: 16rpx;
  width: 90rpx;
  height: 24rpx;
}
.money-wrap {
  display: flex;
  flex-direction: row;
  margin-left: 10rpx;
  height: 42rpx;
}
.rmb {
  text-align: left;
  line-height: 42rpx;
  white-space: nowrap;
  color: #FF0036;
  font-family: PingFangSC;
  font-size: 20rpx;
  font-weight: 400;
}
.money {
  margin-left: 7rpx;
  max-width: 201rpx;
  overflow: hidden;
  text-align: left;
  text-overflow: ellipsis;
  line-height: 42rpx;
  white-space: nowrap;
  color: #FF0036;
  font-family: PingFangSC;
  font-size: 30rpx;
  font-weight: 600;
}
.grid {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 7rpx;
  padding-right: 15rpx;
  padding-left: 16rpx;
  width: 348rpx;
  height: 62rpx;
}
.col-1 {
  box-sizing: border-box;
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  justify-content: space-between;
  border-width: 1rpx;
  border-style: solid;
  border-radius: 4rpx;
  border-color: #FF0036;
  background-color: rgba(255,0,54,0.10);
  padding-right: 15rpx;
  padding-left: 15rpx;
  width: 153rpx;
  height: 60rpx;
}
.voucher {
  margin-top: 14rpx;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ff0036;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.vertical-line {
  margin-top: 5rpx;
  width: 2rpx;
  height: 54rpx;
}
.price {
  margin-top: 14rpx;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ff0036;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.col-2 {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  justify-content: center;
  border-radius: 4rpx;
  background-color: #ff0036;
  width: 153rpx;
  height: 60rpx;
}
.tag {
  margin-top: 15rpx;
  max-width: 141rpx;
  overflow: hidden;
  text-align: center;
  text-overflow: ellipsis;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
</style>
