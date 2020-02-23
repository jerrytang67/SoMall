
<template>
   <view>

      <view class="cu-list menu  card-menu margin-top">
         <view class="cu-item arrow" v-for="(x , index) in addressList" :key="index" @click.stop="select(x)">
            <view class="content padding-tb-sm">
               <view class="content">
                  <text class="cuIcon-location text-red"></text>
                  <text class="text-black text-bold text-lg">{{x.LocationLable}}</text>
               </view>
               <view class="text-black flex  " style="margin-left:calc(1.6em + 10rpx)">
                  <view>{{x.RealName}}</view>
                  <view>{{x.Phone}}</view>
               </view>
            </view>
         </view>
      </view>

      <button class="cu-btn block bg-blue margin lg fix-bottom  shadow shadow-lg" block @click="newAddress">新增收货地址</button>

      <uni-popup ref="popup">
         <view class="uniPopup" style="width:650rpx;">
            <van-cell-group>
               <van-field titleWidth="60px" :value.sync="form.RealName" data-name="RealName" label="收件人" placeholder="收件人" @change="onChange" />

               <van-field titleWidth="60px" :value="form.Phone" data-name="Phone" label="手机号" placeholder="手机号" @change="onChange" use-button-slot>

                  <van-button slot="button" size="mini" type="danger" @getphonenumber="bindPhone" open-type="getPhoneNumber">获取</van-button>
               </van-field>

               <van-field titleWidth="60px" :value="form.Address" data-name="Address" label="小区" placeholder="收货地址" @change="onChange" use-button-slot>
                  <van-button slot="button" size="mini" type="danger" @click="getAddress">地图</van-button>
               </van-field>

               <van-field titleWidth="60px" :value="form.LocationLable" data-name="LocationLable" label="楼号-门牌" placeholder="收货地址" @change="onChange">
               </van-field>
               <van-button block @click="submit" size="small">确定</van-button>
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
import { IAddress, UserModule } from "@/store/modules/user";
import { BaseView } from "../baseView";

@Component({
   components: { uniPopup }
})
export default class MyAddress extends BaseView {
   get addressList() {
      return UserModule.getAddressList;
   }

   created() {}

   form: any = {};

   get info() {
      return SystemModule.getInfo;
   }

   async newAddress() {
      (this.$refs.popup as any).open();
   }

   onChange(e: any) {
      let value = e.detail;
      let key = e.currentTarget.dataset.name;
      let o: any = {};
      o[key] = value;
      this.form = Object.assign({}, this.form, o);
   }

   submit() {
      api.postNewAddress(this.form).then((res: any) => {
         if (res.success) {
            this.initUser();
            (this.$refs.popup as any).close();
         }
      });
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

   async select(x: IAddress) {
      console.log(x);
      await api.SetAddressDefault({ Id: x.Id! }).then((res: any) => {
         if (res.success) uni.navigateBack();
      });
   }

   getAddress() {
      uni.chooseLocation({
         success: res => {
            console.log("位置名称：" + res.name);
            console.log("详细地址：" + res.address);
            console.log("纬度：" + res.latitude);
            console.log("经度：" + res.longitude);

            this.form = Object.assign({}, this.form, {
               Address: res.address,
               LocationLable: res.name,
               Lat: res.latitude,
               Lng: res.longitude
            });
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