<template>
  <view class="mainContainer">
    <zhongchou></zhongchou>
    <changtuwen></changtuwen>
  </view>
</template>
<script>
//vuex
import { mapState, mapMutations, mapActions, mapGetters } from "vuex";

import Toast from "../../../static/dist/toast/toast";
import zhongchou from "@/components/zhongchou";
import changtuwen from "@/components/changtuwen";

export default {
  onLoad(option) {},
  onReady() {
    var that = this;
    var query = that.$root.$mp.query;
  },
  onPullDownRefresh: function() {
    wx.stopPullDownRefresh();
  },
  components: { zhongchou, changtuwen },
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
  margin-top:50rpx;
  flex-direction: column;
  display: flex;
  justify-content: center;
  align-items:center;
}
</style>
