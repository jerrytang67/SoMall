<template>
   <view class="appContainer">
      <div class="title">
         <image src="/static/logo.png" style="width:177rpx;" mode="widthFix" />
      </div>
      <div style="display:flex;flex-direction:column;">
         <van-button style="margin-top:15rpx;" size="large" open-type="getUserInfo" round type="danger" @getuserinfo="bindGetUserInfo">微信一键登录</van-button>
      </div>
      <div class="desc">
         登陆即代表您同意我们的
         <span>服务协议</span> 和
         <span>隐私协议</span>
      </div>
   </view>
</template>

<script lang="ts">
import { Component, Vue, Inject, Watch, Ref } from "vue-property-decorator";
import { UserModule } from "@/store/modules/user";
import api from "@/utils/api";

@Component({})
export default class Login extends Vue {
   get token() {
      return UserModule.getToken;
   }

   get userInfo() {
      return UserModule.getUserInfo;
   }

   created() {}

   bindGetUserInfo(e: any) {
      uni.login({
         success: (loginRes: any) => {
            console.log("loginRes", loginRes);
            uni.getUserInfo({
               success: (res1: any) => {
                  console.log("res1", res1);
                  api.postUserInfo({
                     code: loginRes.code,
                     iv: res1.iv,
                     encryptedData: res1.encryptedData,
                     storeId: 4
                  }).then((res: any) => {
                     console.log(res);
                     if (res.success) {
                        UserModule.Set_UserInfo(res.data.userInfo);
                        UserModule.Set_Token(res.data.token);

                        uni.navigateBack();
                     }
                  });
               }
            });
         },
         fail: err => {
            console.log(err);
         }
      });
   }
}
</script>

<style lang="scss" scoped>
page {
   height: 100%;
}

.title {
   color: #508ed4;
   font-size: 25px;
   text-align: center;
   font-weight: 700;
   height: 40vh;
   display: flex;
   align-items: center;
   justify-content: center;
}

.mainView {
   height: 100%;
   justify-content: space-around;
}
.desc {
   margin-top:5vh;
   text-align: center;
   font-size: 26rpx;
}
.desc span {
   color: #508ed4;
}
</style>