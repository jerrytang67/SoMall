<template>
  <view class="mainContainer">
    <d3></d3>
    <zhongchou :progress="60"></zhongchou>
    <changtuwen></changtuwen>
    <div style="display:flex;flex-dirction:row;flex-wrap:wrap;justify-content:space-around;">
      <oneOfTwo></oneOfTwo>
      <oneOfTwo></oneOfTwo>
      <oneOfTwo></oneOfTwo>
      <oneOfTwo></oneOfTwo>
    </div>
    <div
      style="display:flex;flex-dirction:row;flex-wrap:wrap;justify-content:space-between;margin-bottom:10rpx;width:702rpx;"
    >
      <genduobaobei></genduobaobei>
      <xianxianeirong></xianxianeirong>
    </div>
    <zhongchou :progress="99"></zhongchou>
    <div style="display:flex;flex-dirction:row;flex-wrap:wrap;justify-content:space-around;">
      <oneOfTwo2></oneOfTwo2>
      <oneOfTwo2></oneOfTwo2>
      <oneOfTwo2></oneOfTwo2>
      <oneOfTwo2></oneOfTwo2>
    </div>
  </view>
</template>
<script>
//vuex
import { mapState, mapMutations, mapActions, mapGetters } from "vuex";

import Toast from "../../../static/dist/toast/toast";
import zhongchou from "@/components/zhongchou";
import changtuwen from "@/components/changtuwen";
import oneOfTwo from "@/components/oneOfTwo";
import oneOfTwo2 from "@/components/oneOfTwo2";
import genduobaobei from "@/components/genduobaobei";
import xianxianeirong from "@/components/xianxianeirong";
import d3 from "@/components/d3";

export default {
  onLoad(option) {},
  onReady() {
    var that = this;
    var query = that.$root.$mp.query;
  },
  onPullDownRefresh: function() {
    wx.stopPullDownRefresh();
  },
  components: {
    zhongchou,
    changtuwen,
    oneOfTwo,
    oneOfTwo2,
    genduobaobei,
    xianxianeirong,
    d3
  },
  created() {},
  mounted() {},
  onShareAppMessage: res => {
    return {
      title: "szfeichang",
      path: "/pages/index/index"
    };
  },
  data() {},
  computed: {
    ...mapState(["openid", "unionid"]),
    ...mapGetters([])
  },

  methods: {
    ...mapMutations([]),
    ...mapActions([])
  }
};
</script>
<style scoped>
.mainContainer {
  margin-top: 50rpx;
  flex-direction: column;
  display: flex;
  justify-content: center;
  align-items: center;
}
</style>
