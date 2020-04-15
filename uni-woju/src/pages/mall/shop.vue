<template>
   <view>
      <view>
         <image :src="currentShop.coverImage" mode="widthFix" style="width:100vw"></image>
      </view>
      <!-- <view>
         <image :src="currentShop.logoImage" mode="widthFix" style="width:150upx;"></image>
      </view> -->

      <rich-text :nodes="currentShop.description"></rich-text>
      <view class="flex justify-around">
         <spu :data="x" v-for="(x,index) in spuList" :key="index"></spu>
      </view>
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { ShopModule, IMallShop } from "@/store/modules/shop";
import spu from "@/components/spu.vue";

@Component({ components: { spu } })
export default class Shop extends Vue {
   async onLoad(query: any) {
      console.log(query);
      if (query.shopid) {
         await ShopModule.GetAndSetCurrentShop(query.shopid);
         await ShopModule.GetAndSetSpuList(query.shopid);
      }
   }

   get spuList() {
      return ShopModule.getSpuList;
   }

   get currentShop() {
      return ShopModule.getCurrentShop;
   }

   @Watch("currentShop")
   onChildChanged(val: IMallShop, oldVal: IMallShop) {
      uni.setNavigationBarTitle({
         title: val.shortName
      });
   }

   get name() {
      return "TT";
   }

   created() {}
}
</script>

<style lang="scss" scoped>
</style>