
<template>
   <view>
      Hello {{name}}
      <view>
            <van-card v-for="product in products" :key="x.id" :num="product.id" :price="product.id" :desc="product.description" :title="product.name" thumb="https://img-cdn-qiniu.dcloud.net.cn/uploads/avatar/000/15/95/31_avatar_max.jpg" />

         <van-field :value="id" @change="onChange" />

         <van-button type="primary" @click="getProduct">主要按钮</van-button>

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

   id: number = 0;

   products: any[] = [];
   created() {}

   async getProduct() {
      console.log(this.id);
      await api.project_GetAll({}).then((res: any) => {
         console.log(res);

         this.products = res;
      });
   }

   async onChange(e: any) {
      console.log(e);
      this.id = e.detail;
   }
}
</script>

<style lang="scss" scoped>
</style>