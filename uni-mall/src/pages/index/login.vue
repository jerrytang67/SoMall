<template>
   <view class="container">
      <view class="left-bottom-sign"></view>
      <view class="back-btn yticon icon-zuojiantou-up" @click="navBack"></view>
      <view class="right-top-sign"></view>
      <!-- 设置白色背景防止软键盘把下部绝对定位元素顶上来盖住输入框等 -->
      <view class="wrapper">
         <view class="left-top-sign">LOGIN</view>
         <view class="welcome">
            欢迎回来！
         </view>
         <!-- #ifdef MP-WEIXIN -->
         <!-- <view class="input-content">
            <view class="input-item">
               <text class="tit">当前手机号登录</text>
               <input type="number" v-model="mobile" placeholder="请输入手机号码" maxlength="11" data-key="mobile" />
            </view>
         </view> -->
         <!-- #endif -->
         <!-- #ifndef MP-WEIXIN -->
         <view class="input-content">
            <view class="input-item">
               <text class="tit">手机号码</text>
               <input type="number" v-model="mobile" placeholder="请输入手机号码" maxlength="11" data-key="mobile" />
            </view>
            <view class="input-item">
               <text class="tit">密码</text>
               <input type="mobile" v-model="password" placeholder="8-18位不含特殊字符的数字、字母组合" placeholder-class="input-empty" maxlength="20" password data-key="password" @confirm="toLogin" />
            </view>
         </view>
         <view class="forget-section">
            忘记密码?
         </view>
         <!-- #endif -->
         <view class="padding-xl">
            <button v-if="!openid" class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" open-type="getUserInfo" @getuserinfo="bindGetUserInfo($event,true)">
               {{loginBtnTest}}</button>
            <button v-else class="cu-btn block margin-tb-sm lg" :class="'bg-' + theme" @tap.stop="submit">
               <text class="cuIcon-loading2 cuIconfont-spin" v-if="loadding"></text>
               提交</button>
         </view>

      </view>
      <!-- #ifndef MP-WEIXIN -->
      <view class="register-section">
         还没有账号?
         <text @click="toRegist">马上注册</text>
      </view>
      <!-- #endif -->
   </view>
</template>


<script lang="ts">
// pageBase

export const GetRequestParameters = (locationsearch: string) => {
   let url = locationsearch;
   let theRequest: { [key: string]: string } = {};
   if (url.indexOf("?") != -1) {
      let str = url.substr(1);
      let strs = str.split("&");
      for (let i = 0; i < strs.length; i++) {
         theRequest[strs[i].split("=")[0]] = strs[i].split("=")[1];
      }
   }
   return theRequest;
};

import { BaseView } from "@/pages/baseView.ts";

import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { ShopModule } from "@/store/modules/shop";
import api from "@/utils/api";
import { Tips } from "@/utils/tips";
// if H5
import wechat from "../../utils/wechat";
// endif
@Component
export default class LoginPage extends BaseView {
   onShow() {
      // #ifdef H5
      console.log("h5");
      if (wechat.isWechat()) {
         console.log("wechat.isWechat");
         let tmpUrlSearch = window.location.search; // 得到：?sceneid=h5&wxcode=xxx&puid=fff
         let params = GetRequestParameters(tmpUrlSearch);
         let code = params["code"]; //提取参数
         console.log("code:", code);
         if (!code) {
            const host = encodeURIComponent(location.href.split("?")[0]);
            let _state = "";
            // const appid = storeState.appid;
            const appid = "wx18b9e815c0ed9a8c";
            const url = `https://open.weixin.qq.com/connect/oauth2/authorize?appid=${appid}&redirect_uri=${host}&response_type=code&scope=snsapi_userinfo&state=${_state}#wechat_redirect`;
            location.href = url;
         } else {
            api.oAuth({ code }).then((res) => {
               console.log(res);
            });
         }
      }

      // #endif
   }

   theme = "black";
   mobile = "";
   password = "";
   logining = false;
   navBack() {
      uni.navigateBack();
   }
   toRegist() {
      Tips.info("去注册");
   }
}
</script>

<style lang='scss'>
page {
   background: #fff;
}
.container {
   padding-top: 115px;
   position: relative;
   width: 100vw;
   height: 100vh;
   overflow: hidden;
   background: #fff;
}
.wrapper {
   position: relative;
   z-index: 90;
   background: #fff;
   padding-bottom: 40upx;
}
.back-btn {
   position: absolute;
   left: 40upx;
   z-index: 9999;
   padding-top: var(--status-bar-height);
   top: 40upx;
   font-size: 40upx;
   color: $font-color-dark;
}
.left-top-sign {
   font-size: 120upx;
   color: $page-color-base;
   position: relative;
   left: -16upx;
}
.right-top-sign {
   position: absolute;
   top: 80upx;
   right: -30upx;
   z-index: 95;
   &:before,
   &:after {
      display: block;
      content: "";
      width: 400upx;
      height: 80upx;
      background: #b4f3e2;
   }
   &:before {
      transform: rotate(50deg);
      border-radius: 0 50px 0 0;
   }
   &:after {
      position: absolute;
      right: -198upx;
      top: 0;
      transform: rotate(-50deg);
      border-radius: 50px 0 0 0;
      /* background: pink; */
   }
}
.left-bottom-sign {
   position: absolute;
   left: -270upx;
   bottom: -320upx;
   border: 100upx solid #d0d1fd;
   border-radius: 50%;
   padding: 180upx;
}
.welcome {
   position: relative;
   left: 50upx;
   top: -90upx;
   font-size: 46upx;
   color: #555;
   text-shadow: 1px 0px 1px rgba(0, 0, 0, 0.3);
}
.input-content {
   padding: 0 60upx;
}
.input-item {
   display: flex;
   flex-direction: column;
   align-items: flex-start;
   justify-content: center;
   padding: 0 30upx;
   background: $page-color-light;
   height: 120upx;
   border-radius: 4px;
   margin-bottom: 50upx;
   &:last-child {
      margin-bottom: 0;
   }
   .tit {
      height: 50upx;
      line-height: 56upx;
      font-size: $font-sm + 2upx;
      color: $font-color-base;
   }
   input {
      height: 60upx;
      font-size: $font-base + 2upx;
      color: $font-color-dark;
      width: 100%;
   }
}

.confirm-btn {
   width: 630upx;
   height: 76upx;
   line-height: 76upx;
   border-radius: 50px;
   margin-top: 70upx;
   background: $uni-color-primary;
   color: #fff;
   font-size: $font-lg;
   &:after {
      border-radius: 100px;
   }
}
.forget-section {
   font-size: $font-sm + 2upx;
   color: $font-color-spec;
   text-align: center;
   margin-top: 40upx;
}
.register-section {
   position: absolute;
   left: 0;
   bottom: 50upx;
   width: 100%;
   font-size: $font-sm + 2upx;
   color: $font-color-base;
   text-align: center;
   text {
      color: $font-color-spec;
      margin-left: 10upx;
   }
}
</style>
