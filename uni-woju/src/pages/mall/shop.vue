<template>
   <view>
      <view>
         <image :src="currentShop.coverImage" mode="widthFix" style="width:100vw"></image>
      </view>

      <view>
         {{currentShop.name}}
      </view>
      <view>
         <image :src="currentShop.logoImage" mode="widthFix" style="width:150upx;"></image>
      </view>
      <!-- <wxparser :rich-text="currentShop.description" /> -->
      <view v-html="currentShop.description" />
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { ShopModule } from "@/store/modules/shop";

@Component
export default class Shop extends Vue {
   async onLoad(query: any) {
      console.log(query);
      if (query.shopid) {
         await ShopModule.GetAndSetCurrentShop(query.shopid);
      }
   }

   get currentShop() {
      return ShopModule.getCurrentShop;
   }

   get name() {
      return "TT";
   }

   created() {}
}
</script>

<style lang="scss" scoped>
</style>