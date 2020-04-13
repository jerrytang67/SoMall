
<template>
   <view>
      <view class="cu-list menu  card-menu margin-top">
         <view class="cu-item" v-for="(x , index) in addressList" :key="index">
            <view class="content padding-tb-sm" @tap.stop="select(x)">
               <view class="content">
                  <text class="cuIcon-location text-red"></text>
                  <text class="text-black text-bold text-lg">{{x.locationLable}}</text>
               </view>
               <view class="text-black flex" style="margin-left:calc(1.6em + 10rpx)">
                  <view>{{x.realName}}</view>
                  <view class="margin-left">{{x.phone}}</view>
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
                     <input placeholder="收件人" :value="form.realName" @input="onInput" data-name="realName" />
                  </view>
                  <view class="cu-form-group">
                     <view class="title">手机号</view>
                     <input placeholder="手机号" :value="form.phone" @input="onInput" data-name="phone" />
                     <button class='cu-btn bg-green shadow sm' @getphonenumber="getPhoneNumber" open-type="getPhoneNumber">微信获取</button>
                  </view>
                  <view class="cu-form-group">
                     <view class="title">地址</view>
                     <input placeholder="请点击地图获取" :value="form.locationAddress" @input="onInput" data-name="locationAddress" />
                     <button class='cu-btn bg-green shadow sm' @tap="getAddress">地图</button>
                  </view>
                  <view class="cu-form-group">
                     <view class="title">楼号-门牌</view>
                     <input placeholder="具体收货地址" :value="form.locationLable" @input="onInput" data-name="locationLable" />
                  </view>
                  <view class="flex margin-xs">
                     <view class="flex-treble">
                        <button class="cu-btn block bg-red lg shadow" @tap="submit" v-if="form.id">更新</button>
                        <button class="cu-btn block bg-red lg shadow" @tap="submit" v-else>确定</button>
                     </view>
                     <view class="flex-sub padding-left-xs" v-if="form.id">
                        <button class="cu-btn block bg-grey lg shadow" @tap="deleteAddress">删除</button>
                     </view>

                  </view>

               </form>
            </view>
         </view>
      </view>
      <button class="cu-btn block bg-red margin lg fix-bottom  shadow" @tap="addAddress($event)" data-target="addAddress">新增收货地址</button>
   </view>
</template>
<script lang="ts">
import { BaseView } from "../baseView";
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { Tips } from "../../utils/tips";
import { UserModule } from "@/store/modules/user";
import { AddressModule, IAddress } from "@/store/modules/address";

@Component
export default class MyAddress extends BaseView {
   async onLoad(options: any) {
      await AddressModule.GetAndSetUserAddressList();
   }

   get addressList() {
      return AddressModule.getAddressList;
   }
   get selectAddress() {
      return AddressModule.getSelectAddress;
   }

   form: any = { locationType: "gcj02" };

   onInput(e: any) {
      console.log(e);

      let value = e.detail.value;
      let key = e.currentTarget.dataset.name;
      let o: any = {};
      o[key] = value;
      this.form = Object.assign({}, this.form, o);
   }

   async deleteAddress() {
      if (this.form.id) {
         await api.address_delete(this.form).then(async (res: any) => {
            this.hideModal();
            this.initUser();
            await AddressModule.GetAndSetUserAddressList();
         });
      }
   }

   async submit() {
      if (this.form.id)
         await api.address_update(this.form).then((res: any) => {
            this.initUser();
            this.hideModal();
         });
      else
         await api.address_create(this.form).then((res: any) => {
            this.initUser();
            this.hideModal();
         });
      await AddressModule.GetAndSetUserAddressList();
   }

   addAddress(e: any) {
      this.form = { id: null, locationType: "gcj02" };
      this.showModal(e);
   }

   edit(e: any, x: IAddress) {
      this.form = x;
      this.showModal(e);
   }

   async select(x: IAddress) {
      console.log(x);
      await AddressModule.SelectAddress(x);
      // this.initUser();
      uni.navigateBack();
   }

   getAddress() {
      uni.chooseLocation({
         success: res => {
            console.log("位置名称：" + res.name);
            console.log("详细地址：" + res.address);
            console.log("纬度：" + res.latitude);
            console.log("经度：" + res.longitude);

            this.form = Object.assign({}, this.form, {
               locationAddress: res.address,
               locationLable: res.name,
               lat: res.latitude,
               lng: res.longitude
            });
         }
      });
   }

   getPhoneNumber(e: any) {
      if (e.mp.detail.errMsg.indexOf("ok") > 0) {
         console.log("action:getPhoneNumber", e.mp.detail);
         api.getPhone({
            iv: e.mp.detail.iv,
            encryptedData: e.mp.detail.encryptedData,
            session_key: UserModule.getSessionKey
         }).then((res: any) => {
            console.log(res);
            Tips.info("获取成功");
            this.form = Object.assign({}, this.form, {
               phone: res.phoneNumber
            });
            UserModule.SetPhone(res.phoneNumber);
         });
      } else {
         if (e.mp.detail.errMsg === "getPhoneNumber:fail user deny")
            Tips.info("您取消了授权");
         else {
            Tips.info(e.mp.detail.errMsg);
         }
      }
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