
<template>
   <view>
      Hello {{name}}
      <view>
         <van-button type="default">默认按钮</van-button>
         <van-button type="primary">主要按钮</van-button>
         <van-button type="info">信息按钮</van-button>
         <van-button type="warning">警告按钮</van-button>
         <van-button type="danger">危险按钮</van-button>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";

@Component({})
export default class About extends Vue {
   get name() {
      return "TT";
   }

   created() {
      console.log("created");
   }
}
</script>

<style lang="scss" scoped>
</style>