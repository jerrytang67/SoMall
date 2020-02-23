<template>
   <view>
      <scroll-view scroll-x class="bg-white nav">
         <view class="flex text-center">
            <view class="cu-item flex-sub" :class="index==TabCur?'text-orange cur':''" v-for="(item,index) in 4" :key="index" @tap="tabSelect" :data-id="index">
               Tab{{index}}
            </view>
         </view>
      </scroll-view>
      <view class="appContainer">

         <van-panel v-for="(x,index) in orders" custom-class="panel" :key="index" :title="title(x)" :status="x.State" use-footer-slot>
            <view>
               <van-cell-group>
                  <van-cell title="商品" use-label-slot>
                     <view slot="label">
                        <view v-for="(c,index2) in x.ShopCarts" :key="index2" class="">
                           <view>
                              {{c.ShopItemName}} x {{c.Count}} {{c.ShopItemUnit}}
                           </view>
                           <view>
                              {{c.ShopItemPrice | currency}}
                           </view>
                        </view>
                     </view>
                  </van-cell>
                  <van-cell title="送货方式" :value="x.Type" />
                  <van-cell title="支付方式" :value="x.PayType" />
                  <van-cell title="预计应收">
                     <view>
                        {{x.PriceOriginal | currency}}
                     </view>
                  </van-cell>
                  <van-cell title="实收">
                     <view>
                        {{x.PricePaidIn | currency}}
                     </view>
                  </van-cell>
               </van-cell-group>
            </view>
         </van-panel>
      </view>
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { BaseView } from "../baseView";
import dayjs from "dayjs";

@Component
export default class About extends BaseView {
   get name() {
      return "TT";
   }

   TabCur = 0;
   scrollLeft = 0;

   title(v: any) {
      const date = dayjs(v.DateTimeCreate).format("YYYY-MM-DD HH:mm");
      return `#${v.Id} 时间:${date}`;
   }

   desc(v: any) {}

   orders: any[] = [];

   async onShow() {
      if (!this.openid) this.toLogin();
      await api.GetOrders().then((res: any) => {
         if (res.success) {
            this.orders = res.data;
         }
      });
   }

   tabSelect(e: any) {
      this.TabCur = e.currentTarget.dataset.id;
      this.scrollLeft = (e.currentTarget.dataset.id - 1) * 60;
   }

   created() {}
}
</script>

<style lang="scss">
.panel {
   margin: 20rpx 0;
}
.van-cell__title {
   flex: 2;
}
.van-cell__value {
   flex: auto !important;
}
</style>

