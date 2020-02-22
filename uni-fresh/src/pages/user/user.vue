
<template>
   <view>
      Hello {{name}}
      <view>
         <van-button type="primary" @click="login">Login</van-button>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
@Component({})
export default class About extends Vue {
   get name() {
      return "TT";
   }

   created() {}

   login(){
      uni.navigateTo({url:"/pages/index/login"});
   }
}
</script>

<style lang="scss" scoped>
</style>