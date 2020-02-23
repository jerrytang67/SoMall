<template>
   <view>
      <!-- <van-sticky>
          <filterList :filters="goodsFilters" @sortChanged="goodsFilterChanged" @shapeChanged="goodsTemplateChanged" :showShape="true" :shapeValue="2"></filterList>
      </van-sticky> -->

      <view class="VerticalBox">
         <scroll-view class="VerticalNav nav" scroll-y scroll-with-animation :scroll-top="verticalNavTop" style="min-height:calc(100vh - 200rpx)">
            <view class="cu-item" :class="index==tabCur?'text-green cur':''" v-for="(item,index) in categoryList" :key="index" @tap="TabSelect" :data-id="index">
               {{item.Name}}
            </view>
         </scroll-view>
         <view class="VerticalMain margin-lr-xs">
            <view class="cu-list menu-avatar">
               <view class="cu-item" v-for="(x ,idx2) in showItems" :key="idx2">
                  <view class="cu-avatar round lg" :style="`background-image:url(${x.LogoUrl}!w300w);`"></view>
                  <view class="content">
                     <view class="text-grey">{{x.Name}}</view>
                     <view class="text-gray text-sm flex">
                        <text class="text-cut">
                           <text class="cuIcon-moneybag text-red margin-right-xs"></text>
                           <text class="text-red text-lg margin-right-xs">
                              {{ x.PriceVip }}元
                           </text>/{{x.Unit}}
                        </text> </view>
                  </view>
                  <view class="action" style="width:140rpx;">
                     <view class="flex justify-end align-center ">
                        <button v-show="x.Count>0" @click="cartRemove(x)" class="cu-btn" style="background:none;padding:0">
                           <text class="cuIcon-move text-green" style="font-size:50rpx;"></text></button>
                        <text v-show="x.Count>0" class="text-red text-xl margin-lr text-bold">
                           {{x.Count}}
                        </text>
                        <button @click="cartAdd(x)" class="cu-btn" style="background:none;padding:0">
                           <text class="cuIcon-add text-green" style="font-size:50rpx;"></text></button>
                     </view>
                  </view>
               </view>
            </view>
         </view>
      </view>
      <copyright />
      <unifab ref="fab" direction="vertical" :pattern="pattern" :content="content" @trigger="trigger"></unifab>
   </view>
</template>


<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { AppModule, ICategory, IShopItem } from "@/store/modules/app";

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
   tabCur = 0;

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

   TabSelect(e: any) {
      let index = e.currentTarget.dataset.id;
      this.tabCur = index;
      AppModule.setCurrentCategory(this.categoryList[index]);
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

   cartAdd(item: IShopItem) {
      AppModule.AddCart(item);
   }

   cartRemove(item: IShopItem) {
      AppModule.RemoveCart(item);
   }

   async onPullDownRefresh() {
      await this.fetchData();
      this.tabCur = 0;
      uni.stopPullDownRefresh();
   }

   open() {
      (this.$refs.popup as any).open();
   }

   async fetchData() {
      await AppModule.Init();
   }

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



<style>
.fixed {
   position: fixed;
   z-index: 99;
}

.VerticalNav.nav {
   width: 160upx;
   white-space: initial;
}

.VerticalNav.nav .cu-item {
   width: 100%;
   text-align: center;
   background-color: #fff;
   margin: 0;
   border: none;
   height: 50px;
   position: relative;
}

.VerticalNav.nav .cu-item.cur {
   background-color: #f1f1f1;
}

.VerticalNav.nav .cu-item.cur::after {
   content: "";
   width: 8upx;
   height: 30upx;
   border-radius: 10upx 0 0 10upx;
   position: absolute;
   background-color: currentColor;
   top: 0;
   right: 0upx;
   bottom: 0;
   margin: auto;
}

.VerticalBox {
   display: flex;
}

.VerticalMain {
   background-color: #f1f1f1;
   flex: 1;
}
</style>
