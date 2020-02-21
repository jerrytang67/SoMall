
<template>
   <view class="appContainer">
      <van-goods-action>
         <van-goods-action-button text="新增收货地址" />
      </van-goods-action>
   </view>
</template>``
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { SystemModule } from "@/store/modules/system";
@Component({})
export default class MyAddress extends Vue {
   created() {}

   get info() {
      return SystemModule.getInfo;
   }
}
</script>

<style lang="scss" scoped>
</style>