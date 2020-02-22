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
      {{shopMember.Balance}}
      <button @click="open">打开弹窗</button>
      <uni-popup ref="popup">
         <view class="uniPopup">
            底部弹出 Popup
         </view>
      </uni-popup>
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

@Component({
   components: { filterList, style1, uniPopup, unifab }
})
export default class About  extends BaseView {
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



<style lang="scss">
/* #ifdef MP */
.mp-search-box {
   position: absolute;
   left: 0;
   top: 30upx;
   z-index: 9999;
   width: 100%;
   padding: 0 80upx;
   .ser-input {
      flex: 1;
      height: 56upx;
      line-height: 56upx;
      text-align: center;
      font-size: 28upx;
      color: $font-color-base;
      border-radius: 20px;
      background: rgba(255, 255, 255, 0.6);
   }
}
page {
   .cate-section {
      position: relative;
      z-index: 5;
      border-radius: 16upx 16upx 0 0;
      margin-top: -20upx;
   }
   .carousel-section {
      padding: 0;
      .titleNview-placing {
         padding-top: 0;
         height: 0;
      }
      .carousel {
         .carousel-item {
            padding: 0;
         }
      }
      .swiper-dots {
         left: 45upx;
         bottom: 40upx;
      }
   }
}
/* #endif */

page {
   background: #f5f5f5;
}
.m-t {
   margin-top: 16upx;
}
/* 头部 轮播图 */
.carousel-section {
   position: relative;
   padding-top: 10px;

   .titleNview-placing {
      height: var(--status-bar-height);
      padding-top: 44px;
      box-sizing: content-box;
   }

   .titleNview-background {
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 426upx;
      transition: 0.4s;
   }
}
.carousel {
   width: 100%;
   height: 350upx;

   .carousel-item {
      width: 100%;
      height: 100%;
      padding: 0 28upx;
      overflow: hidden;
   }

   image {
      width: 100%;
      height: 100%;
      border-radius: 10upx;
   }
}
.swiper-dots {
   display: flex;
   position: absolute;
   left: 60upx;
   bottom: 15upx;
   width: 72upx;
   height: 36upx;
   background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMgAAABkCAYAAADDhn8LAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTMyIDc5LjE1OTI4NCwgMjAxNi8wNC8xOS0xMzoxMzo0MCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6OTk4MzlBNjE0NjU1MTFFOUExNjRFQ0I3RTQ0NEExQjMiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6OTk4MzlBNjA0NjU1MTFFOUExNjRFQ0I3RTQ0NEExQjMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTcgKFdpbmRvd3MpIj4gPHhtcE1NOkRlcml2ZWRGcm9tIHN0UmVmOmluc3RhbmNlSUQ9InhtcC5paWQ6Q0E3RUNERkE0NjExMTFFOTg5NzI4MTM2Rjg0OUQwOEUiIHN0UmVmOmRvY3VtZW50SUQ9InhtcC5kaWQ6Q0E3RUNERkI0NjExMTFFOTg5NzI4MTM2Rjg0OUQwOEUiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz4Gh5BPAAACTUlEQVR42uzcQW7jQAwFUdN306l1uWwNww5kqdsmm6/2MwtVCp8CosQtP9vg/2+/gY+DRAMBgqnjIp2PaCxCLLldpPARRIiFj1yBbMV+cHZh9PURRLQNhY8kgWyL/WDtwujjI8hoE8rKLqb5CDJaRMJHokC6yKgSCR9JAukmokIknCQJpLOIrJFwMsBJELFcKHwM9BFkLBMKFxNcBCHlQ+FhoocgpVwwnv0Xn30QBJGMC0QcaBVJiAMiec/dcwKuL4j1QMsVCXFAJE4s4NQA3K/8Y6DzO4g40P7UcmIBJxbEesCKWBDg8wWxHrAiFgT4fEGsB/CwIhYE+AeBAAdPLOcV8HRmWRDAiQVcO7GcV8CLM8uCAE4sQCDAlHcQ7x+ABQEEAggEEAggEEAggEAAgQACASAQQCCAQACBAAIBBAIIBBAIIBBAIABe4e9iAe/xd7EAJxYgEGDeO4j3EODp/cOCAE4sYMyJ5cwCHs4rCwI4sYBxJ5YzC84rCwKcXxArAuthQYDzC2JF0H49LAhwYUGsCFqvx5EF2T07dMaJBetx4cRyaqFtHJ8EIhK0i8OJBQxcECuCVutxJhCRoE0cZwMRyRcFefa/ffZBVPogePihhyCnbBhcfMFFEFM+DD4m+ghSlgmDkwlOgpAl4+BkkJMgZdk4+EgaSCcpVX7bmY9kgXQQU+1TgE0c+QJZUUz1b2T4SBbIKmJW+3iMj2SBVBWz+leVfCQLpIqYbp8b85EskIxyfIOfK5Sf+wiCRJEsllQ+oqEkQfBxmD8BBgA5hVjXyrBNUQAAAABJRU5ErkJggg==);
   background-size: 100% 100%;

   .num {
      width: 36upx;
      height: 36upx;
      border-radius: 50px;
      font-size: 24upx;
      color: #fff;
      text-align: center;
      line-height: 36upx;
   }

   .sign {
      position: absolute;
      top: 0;
      left: 50%;
      line-height: 36upx;
      font-size: 12upx;
      color: #fff;
      transform: translateX(-50%);
   }
}
/* 分类 */
.cate-section {
   display: flex;
   justify-content: space-around;
   align-items: center;
   flex-wrap: wrap;
   padding: 30upx 22upx;
   background: #fff;
   .cate-item {
      display: flex;
      flex-direction: column;
      align-items: center;
      font-size: $font-sm + 2upx;
      color: $font-color-dark;
   }
   /* 原图标颜色太深,不想改图了,所以加了透明度 */
   image {
      width: 88upx;
      height: 88upx;
      margin-bottom: 14upx;
      border-radius: 50%;
      opacity: 0.7;
      box-shadow: 4upx 4upx 20upx rgba(250, 67, 106, 0.3);
   }
}

.ad-1 {
   width: 100%;
   height: 210upx;
   padding: 10upx 0;
   background: #fff;
   image {
      width: 100%;
      height: 100%;
   }
}

.f-header {
   display: flex;
   align-items: center;
   height: 140upx;
   padding: 6upx 30upx 8upx;
   background: #fff;
   image {
      flex-shrink: 0;
      width: 80upx;
      height: 80upx;
      margin-right: 20upx;
   }
   .tit-box {
      flex: 1;
      display: flex;
      flex-direction: column;
   }
   .tit {
      font-size: $font-lg + 2upx;
      color: $font-color-dark;
      line-height: 1.3;
   }
   .tit2 {
      font-size: $font-sm;
      color: $font-color-light;
   }
   .icon-you {
      font-size: $font-lg + 2upx;
      color: $font-color-light;
   }
}
/* 团购楼层 */
.group-section {
   background: #fff;
   .g-swiper {
      height: 650upx;
      padding-bottom: 30upx;
   }
   .g-swiper-item {
      width: 100%;
      padding: 0 30upx;
      display: flex;
   }
   image {
      width: 100%;
      height: 460upx;
      border-radius: 4px;
   }
   .g-item {
      display: flex;
      flex-direction: column;
      overflow: hidden;
   }
   .left {
      flex: 1.2;
      margin-right: 24upx;
      .t-box {
         padding-top: 20upx;
      }
   }
   .right {
      flex: 0.8;
      flex-direction: column-reverse;
      .t-box {
         padding-bottom: 20upx;
      }
   }
   .t-box {
      height: 160upx;
      font-size: $font-base + 2upx;
      color: $font-color-dark;
      line-height: 1.6;
   }
   .price {
      color: $uni-color-primary;
   }
   .m-price {
      font-size: $font-sm + 2upx;
      text-decoration: line-through;
      color: $font-color-light;
      margin-left: 8upx;
   }
   .pro-box {
      display: flex;
      align-items: center;
      margin-top: 10upx;
      font-size: $font-sm;
      color: $font-base;
      padding-right: 10upx;
   }
   .progress-box {
      flex: 1;
      border-radius: 10px;
      overflow: hidden;
      margin-right: 8upx;
   }
}

/* 猜你喜欢 */
.guess-section {
   display: flex;
   flex-wrap: wrap;
   padding: 0 30upx;
   background: #fff;
   .guess-item {
      display: flex;
      flex-direction: column;
      width: 48%;
      padding-bottom: 40upx;
      &:nth-child(2n + 1) {
         margin-right: 4%;
      }
   }
   .image-wrapper {
      width: 100%;
      height: 330upx;
      border-radius: 3px;
      overflow: hidden;
      image {
         width: 100%;
         height: 100%;
         opacity: 1;
      }
   }
   .title {
      font-size: $font-lg;
      color: $font-color-dark;
      line-height: 80upx;
   }
   .price {
      font-size: $font-lg;
      color: $uni-color-primary;
      line-height: 1;
   }
}

.mainContainer {
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
   }
}
</style>