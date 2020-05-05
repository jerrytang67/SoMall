<template>
   <view class="profile">
      <view class="bg-white padding">
         <view class="cu-steps">
            <view class="cu-item" :class="index>num?'':'text-green'" v-for="(item,index) in numList" :key="index">
               <text class="num" :class="index==2?'err':''" :data-index="index + 1"></text> {{item.name}}
            </view>
         </view>
      </view>
      <view>
         <view class="cu-form-group">
            <view class="title">姓名</view>
            <input v-model="profile.realName" class="text-right" placeholder="请输入姓名" />
         </view>
         <view class="cu-form-group">
            <view class="title">手机</view>
            <input v-model="profile.phone" class="text-right" placeholder="请输入手机" :disabled="true" @tap="unable($event,'请使用自动获取')" />
            <button class='cu-btn bg-green shadow' @getphonenumber="getPhoneNumber" open-type="getPhoneNumber">自动获取</button>
         </view>
         <view class="cu-form-group">
            <view class="title">备用号码</view>
            <input v-model="profile.phoneBackup" class="text-right" placeholder="备用号码" />
         </view>
         <view class="cu-form-group">
            <view class="title">地址</view>
            <input class="text-right" v-model="profile.locationAddress" placeholder="请点击地图获取" />
            <button class='cu-btn bg-green shadow sm' @tap="getAddress">地图</button>
         </view>
         <view class="cu-form-group">
            <view class="title">楼号-门牌</view>
            <input class="text-right" v-model="profile.locationLabel" placeholder="具体地址" />
         </view>
         <view class="cu-form-group">
            <view class="title">自我介绍</view>
            <textarea maxlength="-1" v-model="profile.introducting" placeholder="自我介绍"></textarea>
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
export default class PartnerEditPage extends BaseView {
   needLogin = true;
   basics = 0;
   numList = [
      {
         name: "实名认证"
      },
      {
         name: "等待审核"
      },
      {
         name: "完成"
      }
   ];
   num = 0;
   scroll = 0;

   profile: {
      realName?: string;
      phone?: string;
      phoneBackup?: string;
      iDCardFrontUrl?: string;
      iDCardBackUrl?: string;
      iDCardHandUrl?: string;
      introducting?: string;
      lat?: number;
      lng?: number;
      locationLabel?: string;
      locationAddress?: string;
      locationType?: string;
   } = {};

   get currentUser() {
      return UserModule.getUser;
   }

   async onShow() {
      await UserModule.CheckLogin();
      api.partner_getCurrent().then((res: any) => {
         this.profile = Object.assign({}, this.profile, res);
      });
   }

   unable(event: any, str: string) {
      str = str || "不能修改";
      Tips.info(str);
   }

   save() {
      console.log(this.profile);
      api.partner_publicEdit(this.profile).then(() => {
         Tips.info("提交成功,请等待审核");
         setTimeout(() => {
            this.toBack();
         }, 500);
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
               phone: res.phoneNumber
            });
         });
      } else {
         if (e.mp.detail.errMsg === "getPhoneNumber:fail user deny")
            Tips.info("您取消了授权");
         else {
            Tips.info(e.mp.detail.errMsg);
         }
      }
   }

   getAddress() {
      uni.chooseLocation({
         success: res => {
            console.log("位置名称：" + res.name);
            console.log("详细地址：" + res.address);
            console.log("纬度：" + res.latitude);
            console.log("经度：" + res.longitude);

            this.profile = Object.assign({}, this.profile, {
               locationAddress: res.address,
               locationLabel: res.name,
               lat: res.latitude,
               lng: res.longitude,
               locationType: "gcj02"
            });
         },
         fail: e => {
            console.log(e.errMsg);
            if (e.errMsg == "chooseLocation:fail cancel") {
               Tips.info("用户取消");
            } else if (e.errMsg == "chooseLocation:fail auth deny") {
               // 定位权限未开启，引导设置
               uni.showModal({
                  title: "温馨提示",
                  content: "您已拒绝定位,请开启",
                  confirmText: "去设置",
                  success(res) {
                     if (res.confirm) {
                        //打开授权设置
                        uni.openSetting();
                     }
                  }
               });
            }
         }
      });
   }
}
</script>
<style lang='scss'>
page {
   background: $page-color-base;
   padding-bottom: 100upx;
}
</style>
