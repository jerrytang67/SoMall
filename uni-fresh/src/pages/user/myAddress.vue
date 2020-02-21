
<template>
   <view>
      <view class="appContainer">
         <view class="cardWrap">
            <view class="card__cell" v-for="(x , index) in addressList" :key="index">
               <view class="_icon">
                  <van-icon name="location-o" />
               </view>
               <view class="_main" @click.stop="select(x)">
                  <view class="_title">
                     {{x.address}}
                  </view>
                  <view class="_desc">
                     <view>{{x.name}}</view>
                     <view>{{x.phone}}</view>
                  </view>
               </view>
               <view class="_nav">
                  <van-icon name="edit" class="edit" @click.stop="edit(x)" />
               </view>
            </view>
            <view class="line1" />
         </view>
         <van-button type="danger" block class="fix-bottom" @click="newAddress">新增收货地址</van-button>

         <uni-popup ref="popup">
            <view class="uniPopup" style="width:650rpx;">

               <van-cell-group>
                  <van-field titleWidth="60px" :value.sync="form.name" data-name="name" label="收件人" placeholder="收件人" @change="onChange" />

                  <van-field titleWidth="60px" :value="form.phone" data-name="phone" label="手机号" placeholder="手机号" @change="onChange" use-button-slot>

                     <van-button slot="button" size="mini" type="danger" @getphonenumber="bindPhone" open-type="getPhoneNumber">获取</van-button>
                  </van-field>

                  <van-field titleWidth="60px" :value="form.address" data-name="address" label="地址" placeholder="收货地址" @change="onChange" use-button-slot>
                     <van-button slot="button" size="mini" type="danger" @click="getAddress">地图</van-button>
                  </van-field>
                  <van-button block @click="submit">确定</van-button>
               </van-cell-group>
            </view>
         </uni-popup>
      </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import uniPopup from "@/components/uni-popup/uni-popup.vue";

import api from "@/utils/api";
import { SystemModule } from "@/store/modules/system";
@Component({
   components: { uniPopup }
})
export default class MyAddress extends Vue {
   created() {}

   form: any = {
      id: 0,
      name: "",
      phone: "",
      address: "",
      lat: 0,
      lng: 0
   };

   addressList: any[] = [
      {
         id: 0,
         address: "东方花园小区33幢3单元1301",
         name: "tt",
         phone: "138868998",
         lat: 0,
         lng: 0
      }
   ];

   get info() {
      return SystemModule.getInfo;
   }

   async newAddress() {
      (this.$refs.popup as any).open();
   }

   onChange(e: any) {
      let value = e.detail;
      let key = e.currentTarget.dataset.name;
      this.form[key] = value;
   }

   submit() {
      this.form.id = this.addressList.length;
      this.addressList = [...this.addressList, this.form];
      this.form = {
         id: 0,
         name: "",
         phone: "",
         address: "",
         lat: 0,
         lng: 0
      };
      (this.$refs.popup as any).close();
   }

   edit(x: any) {
      this.form = x;
      (this.$refs.popup as any).open();
   }

   bindPhone(e: any) {
      if (e)
         if (e.mp.detail.errMsg.indexOf("ok") > 0) {
            console.log("action:getPhoneNumber", e.mp.detail);
            // await this.$api
            //    .getPhone({
            //       iv: e.mp.detail.iv,
            //       encryptedData: e.mp.detail.encryptedData,
            //       session_key: this.session_key
            //    })
            //    .then(res => {
            //       this.$api.updatePhone(res.phoneNumber).then(res => {
            //          this.$store.commit("SET_PHONE", res.phoneNumber);
            //       });
            //    });
         } else {
            if (e.mp.detail.errMsg === "getPhoneNumber:fail user deny")
               uni.showToast({
                  title: "取消了授权"
               });
            else
               uni.showToast({
                  icon: "none",
                  title: e.mp.detail.errMsg
               });
         }
   }

   select(x: any) {
      uni.navigateBack();
   }

   getAddress() {
      uni.chooseLocation({
         success: res => {
            console.log("位置名称：" + res.name);
            console.log("详细地址：" + res.address);
            console.log("纬度：" + res.latitude);
            console.log("经度：" + res.longitude);
            this.form.address = `${res.name}`;
            this.form.lat = res.latitude;
            this.form.lng = res.longitude;
         }
      });
   }
}
</script>

<style lang="scss" scoped>
.edit {
   color: $base-color;
   margin-right: 20rpx;
}
</style>