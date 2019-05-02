<template>
  <div>
    my
  </div>
</template>
<script>
//vuex
import { mapState, mapMutations, mapActions, mapGetters } from "vuex";

import Toast from "../../../static/dist/toast/toast";

export default {
  onLoad(option) {},
  onReady() {
    var that = this;
    var query = that.$root.$mp.query;
  },
  onPullDownRefresh: function() {
    wx.stopPullDownRefresh();
  },
  components: {},
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
</style>
