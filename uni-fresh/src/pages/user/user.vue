<template>
   <view>
      <div class="head flex-r-ac">
         <img class="avatar" :src="userInfo.avatarUrl" />
         <div class="main flex-c">
            <div class="nickname" v-if="openid">{{userInfo.nickName}}</div>
            <div class="nickname" v-else @click="login">{{userInfo.nickName}}</div>
            <div class="info flex-r-ac" v-if="openid">
               <div class="jf">帐户余额: {{shopMember.Balance | currency}}</div>
            </div>
         </div>
      </div>

      <view class="cu-bar bg-white solid-bottom margin-top">
         <view class="action">
            <text class="cuIcon-title text-orange"></text> 用户信息
         </view>
      </view>
      <view class="cu-list menu">
         <view class="cu-item">
            <view class="content">
               <text class="cuIcon-phone text-olive"></text>
               <text class="text-grey">手机号</text>
            </view>
            <view class="action">
               <text class="text-grey text-sm">
                  {{shopMember.Telphone}}
               </text>
            </view>
         </view>
      </view>

      <view class="cu-bar bg-white solid-bottom margin-top">
         <view class="action">
            <text class="cuIcon-title text-orange"></text> 操作指南
         </view>
      </view>
      <view class="cu-list menu">
         <view class="cu-item">
            <view class="content">
               <text class="cuIcon-btn text-green"></text>
               <text class="text-grey">
                  客服</text>
            </view>
            <view class="action">
               <button class="cu-btn round bg-green shadow">
                  <text class="cuIcon-service"></text> 联系客服</button>
            </view>
         </view>
      </view>

      <view class="padding flex flex-direction">
         <button class="cu-btn bg-white margin-tb-sm lg" @click.stop="logout">
            退出登录</button>
      </view>
   </view>
</template>
<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import api from "@/utils/api";
import { BaseView } from "../baseView";
import { UserModule } from "@/store/modules/user";

@Component
export default class User extends BaseView {
   created() {}

   scan() {
      uni.scanCode({
         success: res => {
            console.log("扫码结果");
            console.log(res);
            // that.$message.info(res);
         },
         fail: res => {
            console.log(res);
         }
      });
   }

   onShow() {
      if (!this.openid) this.toLogin();
   }

   logout() {
      UserModule.Logout();
      this.toHome();
   }

   login() {
      uni.showModal({
         title: "是否登录",
         content: "请先登陆再进行操作",
         success: function(res) {
            if (res.confirm) {
               uni.navigateTo({ url: "/pages/index/login" });
            } else if (res.cancel) {
               console.log("用户点击取消");
            }
         }
      });
   }
}
</script>




<style scoped lang="scss">
.head {
   height: 225rpx;
   background: linear-gradient(to bottom, $base-color, #dd6662);
   .avatar {
      background-color: #f7f7f7;
      margin-left: 44rpx;
      width: 140rpx;
      height: 140rpx;
      border: 8rpx #f9ebd7 solid;
      border-radius: 50%;
   }
   .main {
      height: 140rpx;
      padding-left: 30rpx;
      justify-content: space-between;
      display: flex;
      flex-direction: column;
      color: #fff;
      .nickname {
         font-size: 36rpx;
         font-weight: 700;
      }

      .info {
         .jf {
            height: 46rpx;
            border-radius: 22rpx;
            font-size: 24rpx;
            display: flex;
            align-items: center;
            padding: 0 24rpx;
            background-color: #e38987;
         }
         .icon {
            width: 32rpx;
            height: 32rpx;
            padding-left: 28rpx;
         }
      }
   }
}
.countBar {
   margin-top: -15rpx;
   border-radius: 15rpx 15rpx 0 0;
   background-color: #fff;
   height: 166rpx;
   display: flex;
   flex-direction: row;
   align-items: center;
   .col1 {
      font-size: 28rpx;
      display: flex;
      flex-direction: column;
      text-align: center;
      justify-content: space-around;
      .title {
         color: #000;
         font-size: 38rpx;
         font-weight: 700;
      }
      width: 249rpx;
   }
   .col2 {
      width: 1px;
      height: 54rpx;
      background: #c4c4c4;
   }
}
.mainNav {
   height: 190rpx;
   display: flex;
   flex-direction: row;
   justify-content: space-around;
   background-color: #fff;
   .navItem {
      width: 25vw;
      display: flex;
      justify-content: center;
      align-items: center;
      flex-direction: column;
      image {
         width: 50rpx;
         height: 50rpx;
      }
      text {
         color: #333;
         margin-top: 22rpx;
         font-size: 26rpx;
         font-weight: 500;
      }
   }
}
</style>










