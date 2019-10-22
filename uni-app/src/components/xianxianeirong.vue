<template>
    <view class="box">
  <view class="bd">
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_04_56_629.png!wh500" class="item"></image>
    <view class="wrap">
      <image src="http://img.wjhaomama.com/6/img/2019-05/16_03_42_367.png" class="icon"></image>
      <text class="distance">距离500m</text>
    </view>
  </view>
  <view class="main">
    <text class="title">小户型卫浴怎样才能装得高大上？</text>
  </view>
  <view class="ft">
    <view class="desc-wrap">
      <image src="http://img.wjhaomama.com/6/img/2019-05/16_03_42_367.png" class="avator"></image>
      <text class="desc">时尚家居</text>
    </view>
    <view class="group">
      <image src="http://img.wjhaomama.com/6/img/2019-05/16_05_23_859.png" class="icon-2"></image>
      <text class="num">168</text>
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
.box {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  background-color: #ffffff;
  width: 342rpx;
  height: 534rpx;
}
.bd {
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: row;
  width: 342rpx;
  height: 342rpx;
}
.item {
  position: relative;
  width: 342rpx;
  height: 342rpx;
}
.wrap {
  box-sizing: border-box;
  display: flex;
  position: absolute;
  top: 18rpx;
  left: 18rpx;
  align-items: flex-start;
  flex-direction: row;
  justify-content: space-between;
  border-radius: 15rpx;
  background-color: rgba(0,0,0,0.40);
  padding-right: 9rpx;
  padding-left: 10rpx;
  width: 122rpx;
  height: 30rpx;
}
.icon {
  margin-top: 6rpx;
  width: 14rpx;
  height: 18rpx;
}
.distance {
  margin-top: 6rpx;
  line-height: 18rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 18rpx;
  font-weight: 400;
}
.main {
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin-top: 22rpx;
  width: 342rpx;
  height: 89rpx;
}
.title {
  width: 306rpx;
  height: 88rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 44rpx;
  color: #333333;
  font-family: PingFangSC;
  font-size: 30rpx;
  font-weight: 400;
}
.ft {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 28rpx;
  padding-right: 17rpx;
  padding-left: 18rpx;
  width: 342rpx;
  height: 32rpx;
}
.desc-wrap {
  display: flex;
  flex-direction: row;
  height: 31rpx;
}
.avator {
  width: 30rpx;
  height: 30rpx;
}
.desc {
  margin-top: 3rpx;
  margin-left: 6rpx;
  line-height: 24rpx;
  white-space: nowrap;
  color: #666666;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 300;
}
.group {
  display: flex;
  flex-direction: row;
  height: 31rpx;
}
.icon-2 {
  margin-top: 4rpx;
  width: 22rpx;
  height: 22rpx;
}
.num {
  margin-top: 4rpx;
  margin-left: 5rpx;
  line-height: 22rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 400;
}
</style>
