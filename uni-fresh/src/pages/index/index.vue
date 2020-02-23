<template>
   <view class="container">
      <van-sticky>
         <!-- filters：过滤选项设置， sortChanged：排序更改的事件监听方法，showShape：是否显示右侧模板选择按钮，shapeValue：初始化的模板值，2：双列，1：单列，具体可自行控制，shapeChanged:右侧的模板选择按钮事件监听方法-->
         <filterList :filters="goodsFilters" @sortChanged="goodsFilterChanged" @shapeChanged="goodsTemplateChanged" :showShape="true" :shapeValue="2"></filterList>
      </van-sticky>
      <view class="mainContainer">
         <view style="width:85px;">
            <!-- <van-sticky :offset-top="45"> -->
            <van-sidebar :active-key="activeBar" class="sidebar" @change="sidebarChange">
               <van-sidebar-item v-for="(x,index) in categoryList" :key="index" :title="x.Name" />
            </van-sidebar>
            <!-- </van-sticky> -->
         </view>

         <view class="shopItems">
            <style1 v-for="(x,index2) in showItems" :key="index2" :item="x" />
         </view>
      </view>
      <copyright />
      <!-- <button @click="open">打开弹窗</button>
      <uni-popup ref="popup">
         <view class="uniPopup">
            底部弹出 Popup
         </view>
      </uni-popup> -->
      <unifab ref="fab" direction="vertical" :pattern="pattern" :content="content" @trigger="trigger"></unifab>
   </view>
</template>


<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { AppModule, ICategory } from "@/store/modules/app";

import filterList from "@/components/filterList/index.vue";
import style1 from "@/components/shopItem/style1.vue";
import uniPopup from "@/components/uni-popup/uni-popup.vue";
import unifab from "@/components/uni-fab/index.vue";
import { BaseView } from "../baseView";
import { UserModule } from "@/store/modules/user";
import copyright from "@/components/copyright/index.vue";

@Component({
   components: { filterList, style1, uniPopup, unifab, copyright }
})
export default class About extends BaseView {
   activeBar = 0;
   itemList: any[] = [];

   get shop() {
      return AppModule.getShop;
   }

   get shopItems() {
      return AppModule.getShopItems;
   }

   get cart() {
      return AppModule.getCart;
   }

   get categoryList() {
      return AppModule.getCategory;
   }

   get categorySelect() {
      return AppModule.getCurrentCategory;
   }

   get showItems() {
      return this.shopItems.filter(x => x.CategoryId == this.categorySelect.Id);
   }

   @Watch("cart")
   cartCange(v: any[]) {
      if (v.length > 0) (this.$refs.fab as any).isShow = true;
      else (this.$refs.fab as any).isShow = false;
   }

   get goodsFilters() {
      const cateOptions = [{ name: "推荐", value: "0" }];
      return [
         { title: "类别", value: 0, filterType: 2, options: cateOptions },
         { title: "人气", value: 3, filterType: 1 },
         { title: "最新", value: 4, filterType: 1 },
         { title: "价格", value: 5, filterType: 1, initAscState: true }
      ];
   }

   async onPullDownRefresh() {
      await this.fetchData();
      uni.stopPullDownRefresh();
   }

   open() {
      (this.$refs.popup as any).open();
   }

   async fetchData() {
      await AppModule.Init();
   }

   sidebarChange(e: any) {
      let index = e.detail;
      AppModule.setCurrentCategory(this.categoryList[index]);
   }

   carouselList = [
      { src: "/static/temp/cate1.jpg", background: "/static/temp/cate1.jpg" },
      { src: "/static/temp/cate2.jpg", background: "/static/temp/cate1.jpg" },
      { src: "/static/temp/cate3.jpg", background: "/static/temp/cate1.jpg" }
   ];

   goodsListTemplate = 2;
   // 过滤参数
   curCateFid = "";

   goodsListTemplateType() {
      return this.goodsListTemplate;
   }

   goodsFilterChanged(filter: any) {}

   // 点击了右侧的模板选择按钮：即单列还是双列展示商品
   goodsTemplateChanged(templateValue: any) {
      console.log(templateValue);
      this.goodsListTemplate = templateValue;
   }

   //fab

   // icon
   pattern = {
      color: "#7A7E83",
      backgroundColor: "#fff",
      selectedColor: "#fa436a",
      buttonColor: "#fa436a"
   };

   content = [
      {
         iconPath: "/static/tab-cart.png",
         selectedIconPath: "/static/tab-cart-current.png",
         text: "购物车",
         active: true
      }
   ];

   trigger(e: any) {
      console.log(e);
      if (e.item.text === "购物车") uni.navigateTo({ url: "/pages/cart/cart" });
   }
}
</script>
<style lang="scss" scoped>
page {
   background: #f5f5f5;
}

.mainContainer {
   min-height: calc(100vh - 46px);
   display: flex;
   flex-wrap: nowrap;
   flex-direction: row;
   overflow: auto;
   .shopItems {
      flex: 1;
      display: flex;
      flex-direction: row;
      flex-wrap: wrap;
      justify-content: space-between;
      background: #fff;
      padding: 10rpx;
      align-items: flex-start;
      align-content: start;

   }
}
</style>