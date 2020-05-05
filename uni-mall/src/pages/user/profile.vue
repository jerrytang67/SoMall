<template>
   <view class="profile">
      <view>
         <view class="cu-form-group padding-top">
            <view class="title">头像</view>
            <view class="cu-avatar radius bg-gray" style="width:128upx;height:128upx;" @tap="unable">
               <image :src="profile.headImgUrl" mode="widthFix" style="width:128upx;" />
            </view>
         </view>
         <view class="cu-form-group">
            <view class="title">用户名</view>
            <input v-model="profile.userName" class="text-right" placeholder="请输入用户名" />
         </view>
         <view class="cu-form-group">
            <view class="title">昵称</view>
            <input v-model="profile.name" class="text-right" placeholder="请输入昵称" :disabled="true" @tap="unable" />
         </view>
         <view class="cu-form-group">
            <view class="title">姓名</view>
            <input v-model="profile.surname" class="text-right" placeholder="请输入姓名" />
         </view>
         <view class="cu-form-group">
            <view class="title">手机</view>
            <input v-model="profile.phoneNumber" class="text-right" placeholder="请输入手机" :disabled="true" @tap="unable($event,'请使用自动获取')" />
            <button class='cu-btn bg-green shadow' @getphonenumber="getPhoneNumber" open-type="getPhoneNumber">自动获取</button>
         </view>

         <view class="cu-form-group">
            <view class="title">邮箱</view>
            <input v-model="profile.email" class="text-right" placeholder="请输入邮箱号" />
         </view>

         <view class="cu-form-group">
            <view class="title">重设密码</view>
            <input v-model="profile.password" class="text-right" placeholder="如需重设密码,请输入" />
         </view>
         <view class="cu-form-group" v-show="profile.password">
            <view class="title">确认密码</view>
            <input v-model="profile.passwordConfirm" class="text-right" placeholder="请重复密码" />
         </view>

         <view class="cu-bar btn-group">
            <button class="cu-btn bg-green shadow-blur round" @click="save">保存</button>
            <button class="cu-btn bg-grey shadow-blur round" @tap="toBack">返回</button>
         </view>
      </view>

   </view>
</template>


<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { BaseView } from "../baseView";
import { Tips } from "@/utils/tips";
import { UserModule } from "@/store/modules/user";
import api from "@/utils/api";

@Component
export default class ProfilePage extends BaseView {
   needLogin = true;

   comment: string = "";

   profile: {
      headImgUrl?: string;
      userName?: string;
      name?: string;
      surname?: string;
      phoneNumber?: string;
      email?: string;
      password?: string;
      passwordConfirm?: string;
   } = {};

   get currentUser() {
      return UserModule.getUser;
   }

   async onShow() {
      await UserModule.CheckLogin();
      this.profile = Object.assign({}, this.profile, {
         headImgUrl: this.userinfo.avatarUrl,
         userName: this.currentUser.userName,
         name: this.userinfo.nickName,
         surname: this.currentUser.surname,
         phoneNumber: this.currentUser.phoneNumber,
         email: this.currentUser.email,
         password: "",
         passwordConfirm: ""
      });
   }

   unable(event: any, str: string) {
      str = str || "不能修改";
      Tips.info(str);
   }

   save() {
      api.public_updateUserProfile(this.profile).then(() => {
         UserModule.CheckLogin();
         Tips.info("更新成功");
         this.toBack();
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
            this.profile = Object.assign({}, this.profile, {
               phoneNumber: res.phoneNumber
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
<style lang='scss'>
page {
   background: $page-color-base;
   padding-bottom: 100upx;
}
</style>
