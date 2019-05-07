<template>
    <view class="box">
  <view class="hd">
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_16_09_393.png" class="banner"></image>
    <view class="group">
      <view class="container">
        <view class="action-bg-wrap">
          <image src="http://img.wjhaomama.com/6/img/2019-05/16_17_00_165.png" class="action-bg"></image>
        </view>
        <view class="block">
          <text class="title">左右旋转手机查看全景</text>
          <view class="label-wrap">
            <image src="http://img.wjhaomama.com/6/img/2019-05/16_17_26_448.png" class="label"></image>
            <image src="http://img.wjhaomama.com/6/img/2019-05/16_17_47_868.png" class="icon"></image>
          </view>
        </view>
      </view>
      <image src="http://img.wjhaomama.com/6/img/2019-05/16_18_05_801.png" class="mark"></image>
    </view>
  </view>
  <text class="bd">3室2厅 日系无印风小户型</text>
  <view class="main">
    <text class="summary">美味的萌物们，让人看了就流口水，松软饱满的吐美味美味的萌物们，让人看了就流口水，松软饱满的吐美味的…</text>
  </view>
  <view class="submain">
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_18_27_518.png" class="item"></image>
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_18_42_584.png" class="product"></image>
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_18_56_417.png" class="item-2"></image>
    <image src="http://img.wjhaomama.com/6/img/2019-05/16_19_26_410.png" class="product-2"></image>
  </view>
  <view class="ft">
    <view class="block-2">
      <image src="http://img.wjhaomama.com/6/img/2019-05/16_19_44_608.png" class="avator"></image>
      <text class="info">大海装饰公司</text>
      <view class="tag-wrap">
        <text class="tag">装修专家</text>
      </view>
    </view>
    <view class="tag-wrap-2">
      <text class="tag-2">＃西式厨房</text>
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
  border-radius: 24rpx;
  background-color: #ffffff;
  width: 750rpx;
  height: 790rpx;
  overflow: hidden;
}
.hd {
  box-sizing: border-box;
  display: flex;
  position: relative;
  align-items: flex-start;
  margin-bottom: -18rpx;
  padding-bottom: 18rpx;
  width: 750rpx;
  height: 378rpx;
}
.banner {
  position: absolute;
  top: 0rpx;
  left: 0rpx;
  width: 750rpx;
  height: 360rpx;
}
.group {
  box-sizing: border-box;
  display: flex;
  position: absolute;
  top: 0rpx;
  left: 0rpx;
  margin-bottom: -18rpx;
  padding-bottom: 18rpx;
  width: 750rpx;
  height: 378rpx;
}
.container {
  display: flex;
  align-items: flex-start;
  flex-direction: column;
  background-color: rgba(0,0,0,0.20);
  width: 750rpx;
  height: 360rpx;
}
.action-bg-wrap {
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin-top: 216rpx;
  width: 750rpx;
  height: 57rpx;
}
.action-bg {
  width: 240rpx;
  height: 56rpx;
}
.block {
  display: flex;
  flex-direction: row;
  margin-top: 20rpx;
  width: 750rpx;
  height: 51rpx;
}
.title {
  margin-left: 235rpx;
  line-height: 28rpx;
  white-space: nowrap;
  color: #ffffff;
  font-family: PingFangSC;
  font-size: 28rpx;
  font-weight: 400;
}
.label-wrap {
  display: flex;
  position: relative;
  align-items: flex-start;
  flex-direction: row;
  margin-top: 20rpx;
  margin-left: 157rpx;
  width: 60rpx;
  height: 29rpx;
}
.label {
  position: relative;
  width: 60rpx;
  height: 29rpx;
}
.icon {
  position: absolute;
  top: 5rpx;
  right: 8rpx;
  width: 9rpx;
  height: 20rpx;
}
.mark {
  position: absolute;
  bottom: 0rpx;
  left: 26rpx;
  width: 95rpx;
  height: 36rpx;
}
.bd {
  margin-top: 32rpx;
  margin-left: 24rpx;
  max-width: 690rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 36rpx;
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
  width: 750rpx;
  height: 85rpx;
}
.summary {
  width: 702rpx;
  height: 84rpx;
  overflow: hidden;
  text-overflow: ellipsis;
  line-height: 42rpx;
  color: #888888;
  font-family: PingFangSC;
  font-size: 28rpx;
  font-weight: 300;
}
.submain {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 12rpx;
  padding-right: 23rpx;
  padding-left: 24rpx;
  width: 750rpx;
  height: 164rpx;
}
.item {
  width: 162rpx;
  height: 162rpx;
}
.product {
  width: 162rpx;
  height: 162rpx;
}
.item-2 {
  width: 162rpx;
  height: 162rpx;
}
.product-2 {
  width: 162rpx;
  height: 162rpx;
}
.ft {
  box-sizing: border-box;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin-top: 19rpx;
  padding-right: 23rpx;
  padding-left: 24rpx;
  width: 750rpx;
  height: 38rpx;
}
.block-2 {
  display: flex;
  flex-direction: row;
  height: 37rpx;
}
.avator {
  margin-top: 3rpx;
  width: 30rpx;
  height: 30rpx;
}
.info {
  margin-top: 7rpx;
  margin-left: 6rpx;
  line-height: 24rpx;
  white-space: nowrap;
  color: #666666;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 300;
}
.tag-wrap {
  box-sizing: border-box;
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  margin-top: 5rpx;
  margin-left: 8rpx;
  border-radius: 6rpx;
  background-color: rgba(253,234,238,0.90);
  padding-right: 8rpx;
  padding-left: 8rpx;
  height: 28rpx;
}
.tag {
  margin-top: 2rpx;
  line-height: 24rpx;
  white-space: nowrap;
  color: #ff2c54;
  font-family: PingFangSC;
  font-size: 20rpx;
  font-weight: 400;
}
.tag-wrap-2 {
  box-sizing: border-box;
  display: flex;
  align-items: flex-start;
  flex-direction: row;
  border-radius: 19rpx;
  background-color: #fff4c0;
  padding-right: 18rpx;
  padding-left: 12rpx;
  height: 36rpx;
}
.tag-2 {
  margin-top: 6rpx;
  line-height: 24rpx;
  white-space: nowrap;
  color: #ff9d00;
  font-family: PingFangSC;
  font-size: 24rpx;
  font-weight: 400;
}
</style>
