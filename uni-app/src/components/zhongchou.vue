<template>
    <view class="box">
        <view class="hd">
            <view class="banner-wrap">
            <image src="http://img.wjhaomama.com/6/img/2019-05/19_50_46_313.png!w500" class="banner"></image>
            <view class="outer">
                <view class="wrap">
                <text class="organization">众筹</text>
                <text class="desc">｜全网首发</text>
                </view>
            </view>
            </view>
            <image src="http://img.wjhaomama.com/6/img/2019-05/19_52_58_600.png" class="play"></image>
        </view>
        <text class="bd">对饮茶酒 手工茶罐与小对杯</text>
        <view class="main">
            <text class="summary">宽杯、小杯自在搭配，喝茶喝酒都很适合。手工制/static/images宽杯、小杯自在搭配，喝茶喝酒都很适合。手工制做…</text>
        </view>
        <view class="submain">
            <view class="bg-wrap">
            <view class="color"></view>
            <image src="http://img.wjhaomama.com/6/img/2019-05/19_52_08_528.png" class="bg" :style="{width: 5.83*progress+'rpx'}"></image>
            </view>
            <text class="text">{{progress}}%</text>
        </view>
        <view class="ft">
            <text class="people-support-prev">5216</text>
            <text class="people-support">人支持</text>
            <text class="people-support-next">486.52万</text>
            <text class="has-raise-amount">已筹金额</text>
        </view>
</view>
</template>
<script>
export default {
  onReady() {
    this.progress = this.progress>100?100:this.progress;
  },
  props: ["progress"],
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
  border-radius: 24rpx;
  background-color: #ffffff;
  width: 702rpx;
  height: 672rpx;
}
.hd {
  box-sizing: border-box;
  display: flex;
  position: relative;
  align-items: center;
  flex-direction: row;
  justify-content: center;
  margin-bottom: -18rpx;
  padding-bottom: 18rpx;
  width: 702rpx;
  height: 412rpx;
}
.banner-wrap {
  box-sizing: border-box;
  display: flex;
  position: relative;
  margin-bottom: -18rpx;
  padding-bottom: 18rpx;
  width: 702rpx;
  height: 412rpx;
}
.banner {
  position: relative;
  width: 702rpx;
  height: 394rpx;
}
.outer {
  display: flex;
  position: absolute;
  bottom: 0rpx;
  left: 24rpx;
  align-items: flex-start;
  flex-direction: row;
  border-radius: 6rpx;
  background-color: #ffb901;
  width: 189rpx;
  height: 36rpx;
}
.wrap {
  display: flex;
  flex-direction: row;
  margin-top: 6rpx;
  margin-left: 10rpx;
  height: 24rpx;
}
.organization {
  text-align: left;
  line-height: 24rpx;
  white-space: nowrap;
  color: #FFFFFF;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 600;
}
.desc {
  max-width: 120rpx;
  overflow: hidden;
  text-align: left;
  text-overflow: ellipsis;
  line-height: 24rpx;
  white-space: nowrap;
  color: #FFFFFF;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 300;
}
.play {
  position: absolute;
  top: 148rpx;
  left: 301rpx;
  width: 100rpx;
  height: 100rpx;
}
.bd {
  margin-top: 32rpx;
  margin-left: 24rpx;
  max-width: 642rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 32rpx;
  white-space: nowrap;
  color: #333333;
  font-family: PingFangSC;
  font-size: 32rpx;
  font-weight: 500;
}
.main {
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin-top: 18rpx;
  width: 702rpx;
  height: 81rpx;
}
.summary {
  width: 654rpx;
  height: 80rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 40rpx;
  color: #888888;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 300;
}
.submain {
  display: flex;
  flex-direction: row;
  margin-top: 24rpx;
  width: 702rpx;
  height: 28rpx;
}
.bg-wrap {
  box-sizing: border-box;
  display: flex;
  position: relative;
  margin-top: 10rpx;
  margin-left: 24rpx;
  padding-left: 7rpx;
  width: 590rpx;
  height: 6rpx;
}
.color {
  border-radius: 100rpx;
  background-color: #ebebeb;
  width: 583rpx;
  height: 6rpx;
  display: flex;
}
.bg {
  position: absolute;
  top: 0rpx;
  left: 0rpx;
  max-width:583rpx;
  height: 6rpx;
}
.text {
  margin-left: 12rpx;
  max-width: 64rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 26rpx;
  white-space: nowrap;
  color: #ff9e00;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 400;
}
.ft {
  display: flex;
  flex-direction: row;
  margin-top: 5rpx;
  width: 702rpx;
  height: 32rpx;
}
.people-support-prev {
  margin-top: 3rpx;
  margin-left: 24rpx;
  line-height: 26rpx;
  white-space: nowrap;
  color: #ff9d00;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 400;
}
.people-support {
  line-height: 30rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 300;
}
.people-support-next {
  margin-top: 3rpx;
  margin-left: 43rpx;
  line-height: 26rpx;
  white-space: nowrap;
  color: #ff9d00;
  font-family: PingFangSC;
  font-size: 26rpx;
  font-weight: 400;
}
.has-raise-amount {
  margin-left: 6rpx;
  max-width: 382rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 30rpx;
  white-space: nowrap;
  color: #999999;
  font-family: PingFangSC;
  font-size: 22rpx;
  font-weight: 300;
}
</style>
