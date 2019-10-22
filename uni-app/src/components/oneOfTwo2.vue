<template>
<view class="box">
  <view class="hd">
    <text class="info">一人宴专业中式美食</text>
    <image src="http://img.wjhaomama.com/6/img/2019-05/14_49_25_532.png" class="icon"></image>
  </view>
  <view class="bd">
    <image src="http://img.wjhaomama.com/6/img/2019-05/14_46_43_127.png!wh500" class="item"></image>
    <view class="want-buy-popular-hotels-near-wrap">
      <text class="want-buy-popular-hotels-near">想买人气28888</text>
    </view>
  </view>
  <text class="main">意大利纯牛肉饭</text>
  <view class="submain">
    <text class="price">价格：</text>
    <text class="origin-price">¥12345678</text>
  </view>
  <view class="row">
    <image src="http://img.wjhaomama.com/6/img/2019-05/14_49_58_601.png" class="price-icon"></image>
    <text class="yuan">￥</text>
    <text class="money">6.00</text>
  </view>
  <view class="ft">
    <view class="tag-wrap">
      <text class="tag">进店抢红包</text>
    </view>
    <view class="tag-wrap-2">
      <text class="tag-2">加购物车</text>
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
.box {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  background-color: #ffffff;
  width: 342rpx;
  height: 618rpx;
}
.hd {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  border-top-left-radius: 20rpx;
  border-top-right-radius: 20rpx;
  background-color: #f5f5f5;
  width: 342rpx;
  height: 56rpx;
}
.info {
  margin-top: 15rpx;
  margin-left: 20rpx;
  line-height: 24rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.icon {
  margin-top: 15rpx;
  margin-left: 11rpx;
  width: 16rpx;
  height: 26rpx;
}
.bd {
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: row;
  justify-content: flex-end;
  width: 342rpx;
  height: 342rpx;
}
.item {
  position: relative;
  width: 342rpx;
  height: 342rpx;
}
.want-buy-popular-hotels-near-wrap {
  box-sizing: border-box;
  display: flex;
  position: absolute;
  right: 0rpx;
  bottom: 0rpx;
  align-items: flex-start;
  flex-direction: row;
  background-color: rgba(51,51,51,0.60);
  padding-right: 10rpx;
  padding-left: 11rpx;
  height: 32rpx;
}
.want-buy-popular-hotels-near {
  margin-top: 4rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.main {
  margin-top: 20rpx;
  margin-left: 20rpx;
  max-width: 290rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 26rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 400;
}
.submain {
  display: flex;
  flex-direction: row;
  margin-top: 9rpx;
  margin-left: 20rpx;
  height: 24rpx;
}
.price {
  text-align: left;
  line-height: 24rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.origin-price {
  max-width: 224rpx;
  overflow: hidden;
  text-align: left;
  text-decoration: line-through;
  text-overflow: ellipsis;
  line-height: 24rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.row {
  display: flex;
  flex-direction: row;
  margin-top: 13rpx;
  width: 342rpx;
  height: 27rpx;
}
.price-icon {
  margin-top: 1rpx;
  margin-left: 21rpx;
  width: 72rpx;
  height: 24rpx;
}
.yuan {
  margin-top: 4rpx;
  margin-left: 5rpx;
  line-height: 20rpx;
  white-space: nowrap;
  color: #ff5000;
  font-family: PingFangSC;
  font-size: 20rpx;
  font-weight: 500;
}
.money {
  max-width: 212rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 24rpx;
  white-space: nowrap;
  color: #ff5000;
  font-family: PingFangSC;
  font-size: 30rpx;
  font-weight: 500;
}
.ft {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 18rpx;
  padding-right: 19rpx;
  padding-left: 20rpx;
  width: 342rpx;
  height: 62rpx;
}
.tag-wrap {
  box-sizing: border-box;
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  border-width: 1rpx;
  border-style: solid;
  border-radius: 50rpx;
  border-color: #FF5000;
  background-color: #ffffff;
  padding-right: 13rpx;
  padding-left: 13rpx;
  height: 60rpx;
}
.tag {
  margin-top: 14rpx;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ff5000;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.tag-wrap-2 {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  justify-content: center;
  border-radius: 50rpx;
  background-color: #ff5000;
  width: 146rpx;
  height: 60rpx;
}
.tag-2 {
  margin-top: 14rpx;
  max-width: 134rpx;
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
