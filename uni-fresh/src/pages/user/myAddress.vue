
<template>
   <view>

      <view class="cu-list menu  card-menu margin-top">
         <view class="cu-item" v-for="(x , index) in addressList" :key="index">
            <view class="content padding-tb-sm" @tap.stop="select(x)">
               <view class="content">
                  <text class="cuIcon-location text-red"></text>
                  <text class="text-black text-bold text-lg">{{x.LocationLable}}</text>
               </view>
               <view class="text-black flex  " style="margin-left:calc(1.6em + 10rpx)">
                  <view>{{x.RealName}}</view>
                  <view>{{x.Phone}}</view>
               </view>
            </view>
            <view class="action">
               <button class="cu-btn round bg-white lg" @tap="edit($event,x)" data-target="addAddress">
                  <text class="cuIcon-edit text-green"></text></button>
            </view>
         </view>
      </view>

      <view class="cu-modal" :class="modalName==='addAddress'?'show':''">
         <view class="cu-dialog">
            <view class="cu-bar bg-gray justify-end">
               <view class="content">新增收货地址</view>
               <view class="action" @tap="hideModal">
                  <text class="cuIcon-close text-red"></text>
               </view>
            </view>
            <view class="bg-white">
               <form>
                  <view class="cu-form-group">
                     <view class="title">收件人</view>
                     <input placeholder="收件人" :value="form.RealName" />
                  </view>
                  <view class="cu-form-group">
                     <view class="title">手机号</view>
                     <input placeholder="手机号" :value="form.Phone" />
                  </view>
                  <view class="cu-form-group">
                     <view class="title">小区</view>
                     <input placeholder="请点击地图获取" :value="form.Address" />
                     <button class='cu-btn bg-green shadow sm' @tap="getAddress">地图</button>
                  </view>
                  <view class="cu-form-group">
                     <view class="title">楼号-门牌</view>
                     <input placeholder="具体收货地址" :value="form.LocationLable" />
                  </view>
                  <view class="flex margin-xs">
                     <view class="flex-treble">
                        <button class="cu-btn block bg-red lg shadow" @click="newAddress">确定</button>
                     </view>
                     <view class="flex-sub padding-left-xs" v-if="form.Id">
                        <button class="cu-btn block bg-grey lg shadow" @click="deleteAddress">删除</button>
                     </view>

                  </view>

               </form>
            </view>
         </view>
      </view>
      <button class="cu-btn block bg-red margin lg fix-bottom  shadow" @tap="showModal" data-target="addAddress">新增收货地址</button>
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

   onChange(e: any) {
      let value = e.detail;
      let key = e.currentTarget.dataset.name;
      let o: any = {};
      o[key] = value;
      this.form = Object.assign({}, this.form, o);
   }

   async deleteAddress() {
      if (this.form.Id > 0) {
         api.AddressDelete(this.form).then((res: any) => {
            if (res.success) {
               this.hideModal();
               this.initUser();
            }
         });
      }
   }

   submit() {
      api.postNewAddress(this.form).then((res: any) => {
         if (res.success) {
            this.initUser();
         }
      });
   }

   edit(e: any, x: IAddress) {
      this.form = x;
      this.showModal(e);
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
.cu-modal {
   input {
      text-align: left;
   }
}
</style>