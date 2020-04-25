<template>
   <view class="content">
      <!-- 头部轮播 -->
      <view class="carousel-section">
         <!-- 标题栏和状态栏占位符 -->
         <view class="titleNview-placing"></view>
         <!-- 背景色区域 -->
         <view class="titleNview-background" :style="{backgroundColor:titleNViewBackground}"></view>
         <swiper class="carousel" circular @change="swiperChange">
            <swiper-item v-for="(item, index) in carouselList" :key="index" class="carousel-item" @click="navToDetailPage({title: '轮播广告'})">
               <image :src="item.src" />
            </swiper-item>
         </swiper>
         <!-- 自定义swiper指示器 -->
         <view class="swiper-dots">
            <text class="num">{{swiperCurrent+1}}</text>
            <text class="sign">/</text>
            <text class="num">{{swiperLength}}</text>
         </view>
      </view>
      <!-- 分类 -->
      <view class="cate-section">
         <view class="cate-item" v-for="(cate,index) in categories" :key="index">
            <image :src="cate.logoImageUrl"></image>
            <text>{{cate.name}}</text>
         </view>
      </view>
      <!-- 商品列表 -->
      <view class="goods-list">
         <view class="title">— 猜你喜欢 —</view>
         <view class="product-list">
            <view class="product" v-for="(product,p_index) in productList" :key="p_index" @tap="toSpu(product.id)">
               <image mode="widthFix" :src="product.skus[0].coverImageUrls[0]"></image>
               <view class="name text-lg margin-lr-sm" style="min-height:64upx;">{{product.name}}</view>
               <view class="info">
                  <view class="price text-xl  margin-sm">¥{{product.skus[0].price}}</view>
                  <!-- <view class="slogan"></view> -->
               </view>
            </view>
         </view>
         <view class="loading-text">{{loadingText}}</view>
      </view>

      <view class="cu-card" v-for="(x,idx) in shops" :key="idx">
         <view class="cu-item shadow" @tap="toShop(x.id)">
            <view class="title">
               <view class="text-cut">{{x.name}}</view>
            </view>
            <view class="content">
               <image :src="x.logoImage" mode="widthFix" style="width:150upx;"></image>
               <!-- <view class="desc">
                  <view class="text-content" v-html="x.description">
                  </view>
               </view> -->
            </view>
         </view>
      </view>
      <view class="padding-xl">
         <button v-if="!openid" class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" open-type="getUserInfo" @getuserinfo="bindGetUserInfo">
            {{loginBtnTest}}</button>
         <button v-else class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" @tap.stop="submit">
            <text class="cuIcon-loading2 cuIconfont-spin" v-if="loadding"></text>
            提交</button>
      </view>

      <navigator url="plugin-private://wx2b03c6e691cd7370/pages/live-player-plugin?room_id=2">
         <image class="logo" style="height:200upx;width:200upx;" src="../../static/head.jpg"></image>
         <view>
            <text class="title">TT的直播间</text>
         </view>
      </navigator>

   </view>
</template>
<script lang="ts">
// pageBase
import { BaseView } from "@/pages/baseView.ts";

import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { ShopModule } from "@/store/modules/shop";
import api from "@/utils/api";
@Component
export default class About extends BaseView {
   theme = "green";

   onShareAppMessage(option: any) {
      return {
         title: "SoMall 社区电商版",
         path: "/pages/index/index"
      };
   }
   async loadData() {
      this.titleNViewBackground = this.carouselList[0].background;
      this.swiperLength = this.carouselList.length;
      this.carouselList = this.carouselList;
   }

   get shops() {
      return ShopModule.shops;
   }

   get categories() {
      return ShopModule.getCategories;
   }

   get productList() {
      return ShopModule.getIndexSpus;
   }

   created() {
      this.loadData();
   }

   async click() {
      uni.navigateTo({
         url: "/pages/index/about"
      });
      await api.init({ s: 123 }).then(res => {});
   }

   // 分类
   carouselList = [
      {
         src:
            "https://img.somall.top/somall/2020/04/24/gbobddyj0wpl7qod5x7maoa74dfsg4i2.jpg!w500",
         background: "rgb(203, 87, 60)"
      },
      {
         src:
            "https://img.somall.top/somall/2020/04/24/rm8ktxqh093medudqf5owfzr3vmlbv1y.jpg!w500",
         background: "rgb(205, 215, 218)"
      },
      {
         src:
            "https://img.somall.top/somall/2020/04/24/kvurlo7gqyyd5xzt68otf4b1cs8px9hy.jpg!w500",
         background: "rgb(183, 73, 69)"
      }
   ];

   swiperCurrent = 0;
   swiperLength = 0;
   titleNViewBackground = "";
   //轮播图切换修改背景色
   swiperChange(e: any) {
      const index = e.detail.current;
      this.swiperCurrent = index;
      this.titleNViewBackground = this.carouselList[index].background;
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
   justify-content: space-between;
   align-items: center;
   flex-wrap: wrap;
   padding: 30upx 30upx;
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
      width: 98upx;
      height: 98upx;
      margin: 12upx;
      // margin-bottom: 14upx;

      border-radius: 50%;
      // opacity: 0.7;
      // box-shadow: 4upx 4upx 20upx rgba(250, 67, 106, 0.3);
   }
}

/* goods */
.goods-list {
   margin: 0 18upx;
   background-color: #f4f4f4;
   .title {
      width: 100%;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 60upx;
      color: #979797;
      font-size: 24upx;
   }
   .loading-text {
      width: 100%;
      display: flex;
      justify-content: center;
      align-items: center;
      height: 60upx;
      color: #979797;
      font-size: 24upx;
   }
   .product-list {
      padding: 0;
      display: flex;
      justify-content: space-between;
      flex-wrap: wrap;
      .product {
         width: 340upx;
         border-radius: 20upx;
         background-color: #fff;
         margin: 0 0 24upx 0;
         image {
            width: 100%;
            border-radius: 20upx 20upx 0 0;
         }
         .name {
            display: -webkit-box;
            -webkit-box-orient: vertical;
            -webkit-line-clamp: 2;
            text-align: justify;
            overflow: hidden;
         }
         .info {
            display: flex;
            justify-content: space-between;
            align-items: flex-end;
            .price {
               color: #e65339;
               font-weight: 600;
            }
            .slogan {
               color: #807c87;
               font-size: 24upx;
            }
         }
      }
   }
}
</style>
