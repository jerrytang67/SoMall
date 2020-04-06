
<template>
   <view>
      Hello {{name}}
      <view>
         <van-button type="primary" @click="getProduct">主要按钮</van-button>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
@Component
export default class About extends Vue {
   get name() {
      return "TT";
   }

   id: number = 0;

   products: any[] = [];
   created() {}

   async getProduct() {
      console.log(this.id);
   }

   async onChange(e: any) {
      console.log(e);
      this.id = e.detail;
   }
}
</script>

<style lang="scss" scoped>
</style>