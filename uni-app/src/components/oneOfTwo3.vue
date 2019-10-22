<template>
    <view class="block-2">
  <view class="box">
    <image src="https://img.alicdn.com/tfs/TB1UfjFCxTpK1RjSZR0XXbEwXXa-684-1236.png" class="layer"></image>
    <view class="hd">
      <text class="organization">更多好宝贝</text>
      <image src="https://img.alicdn.com/tfs/TB1.PDJCAPoK1RjSZKbXXX1IXXa-74-74.png" class="icon"></image>
    </view>
    <text class="bd">惊喜马上等你来揭晓</text>
    <view class="main">
      <view class="col-1">
        <view class="wrap">
          <image src="https://img.alicdn.com/tfs/TB1NQrACBLoK1RjSZFuXXXn0XXa-256-226.png" class="logo"></image>
        </view>
        <text class="info">口味极佳</text>
      </view>
      <view class="col-2">
        <view class="block">
          <image src="https://img.alicdn.com/tfs/TB1waYGCrrpK1RjSZTEXXcWAVXa-256-200.png" class="logo-2"></image>
        </view>
        <text class="info-2">肉多汁少</text>
      </view>
    </view>
    <view class="ft">
      <view class="col-12">
        <view class="group">
          <image src="https://img.alicdn.com/tfs/TB1rNbDCxTpK1RjSZFGXXcHqFXa-236-238.png" class="logo-3"></image>
        </view>
        <text class="delicious-want-cry">美味到想哭</text>
      </view>
      <view class="col-22">
        <view class="container">
          <image src="https://img.alicdn.com/tfs/TB1L4f6CxjaK1RjSZKzXXXVwXXa-170-268.png" class="logo-4"></image>
        </view>
        <text class="rich-nutrition">富含营养</text>
      </view>
    </view>
  </view>
</view>
</template>
<script>
export default {
  onReady() {
  },
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
.block-2 {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  border-radius: 12rpx;
  background-color: #ff5000;
  width: 342rpx;
  height: 618rpx;
  overflow: hidden;
}
.box {
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: column;
  width: 342rpx;
  height: 618rpx;
}
.layer {
  position: absolute;
  top: 0rpx;
  left: 0rpx;
  width: 342rpx;
  height: 618rpx;
}
.hd {
  display: flex;
  position: relative;
  flex-direction: row;
  margin-top: 22rpx;
  width: 342rpx;
  height: 52rpx;
}
.organization {
  margin-left: 19rpx;
  line-height: 50rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 36rpx;
  font-weight: 600;
}
.icon {
  margin-top: 8rpx;
  margin-left: 6rpx;
  width: 35rpx;
  height: 35rpx;
}
.bd {
  position: relative;
  margin-top: 6rpx;
  margin-left: 19rpx;
  max-width: 292rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 33rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
.main {
  box-sizing: border-box;
  display: flex;
  position: relative;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 25rpx;
  padding-right: 19rpx;
  padding-left: 20rpx;
  width: 342rpx;
  height: 190rpx;
}
.col-1 {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  border-radius: 6rpx;
  background-color: #f8f8f8;
  width: 148rpx;
  height: 188rpx;
  overflow: hidden;
}
.wrap {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  background-color: #ffffff;
  width: 148rpx;
  height: 148rpx;
}
.logo {
  margin-top: 20rpx;
  margin-left: 11rpx;
  width: 128rpx;
  height: 113rpx;
}
.info {
  margin-top: 9rpx;
  padding-right: 52rpx;
  padding-left: 8rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.col-2 {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  border-radius: 6rpx;
  background-color: #f8f8f8;
  width: 148rpx;
  height: 188rpx;
  overflow: hidden;
}
.block {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  background-color: #ffffff;
  width: 148rpx;
  height: 148rpx;
}
.logo-2 {
  margin-top: 29rpx;
  margin-left: 10rpx;
  width: 128rpx;
  height: 100rpx;
}
.info-2 {
  margin-top: 9rpx;
  padding-right: 52rpx;
  padding-left: 8rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.ft {
  box-sizing: border-box;
  display: flex;
  position: relative;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 5rpx;
  padding-right: 19rpx;
  padding-left: 20rpx;
  width: 342rpx;
  height: 190rpx;
}
.col-12 {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  border-radius: 6rpx;
  background-color: #f8f8f8;
  width: 148rpx;
  height: 188rpx;
  overflow: hidden;
}
.group {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  background-color: #ffffff;
  width: 148rpx;
  height: 148rpx;
}
.logo-3 {
  margin-top: 14rpx;
  margin-left: 15rpx;
  width: 118rpx;
  height: 119rpx;
}
.delicious-want-cry {
  margin-top: 9rpx;
  padding-right: 30rpx;
  padding-left: 8rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
.col-22 {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  border-radius: 6rpx;
  background-color: #f8f8f8;
  width: 148rpx;
  height: 188rpx;
  overflow: hidden;
}
.container {
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  justify-content: center;
  background-color: #ffffff;
  width: 148rpx;
  height: 148rpx;
}
.logo-4 {
  margin-top: 9rpx;
  width: 85rpx;
  height: 134rpx;
}
.rich-nutrition {
  margin-top: 9rpx;
  padding-right: 52rpx;
  padding-left: 8rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
</style>
