<template>
  <view class="pic-upload" >
<block v-if="limit===1">
    <div class="upload-btn" v-if="!data" @click="uploadImg()"  :style="{'width':width || '120rpx','height':height || '120rpx'}">
        <span class="upload-add">+</span> 
    </div>
    <div class="box" v-if="data">
        <img @click.stop="previewImage(0)" :src="data+'!w100h100'" :style="{'width':width || '120rpx','height':height || '120rpx'}" class="img" >
        <image src="/static/images/close.png" background-size="cover" class="box__close" @click.stop="deleteImg(0)" />
    </div>
</block>
<block v-if="limit>1">
    <div v-if="data && data.length<limit" class="upload-btn" @click="uploadImg()"  :style="{'width':width || '120rpx','height':height || '120rpx'}">
        <span class="upload-add">+</span>
    </div>
    <div v-for="(src,index) in data" :key="src"  class="box">
        <img @click="previewImage(index)" :src="src+'!w100h100'" :style="{'width':width || '120rpx','height':height || '120rpx'}" class="img" >
        <image src="/static/images/close.png" background-size="cover" class="box__close" @click.stop="deleteImg(index)" />
    </div>
</block>
  </view>
</template>

<script>
import upload from "@/utils/upload";

export default {
  props: ["data", "limit"],
  data: function() {
    return {
      width: "120rpx",
      height: "120rpx"
    };
  },
  methods: {
    deleteImg(index) {
      if (this.limit == 1) this.data = "";
      else this.data.splice(index, 1);
    },
    previewImage(e) {
      var that = this;
      if (that.limit > 1)
        wx.previewImage({
          current: that.data[e],
          urls: that.data // 需要预览的图片http链接列表
        });
      else
        wx.previewImage({
          urls: [that.data]
        });
    },
    uploadImg() {
      var that = this;
      upload
        .upload()
        .then(res => {
          console.log("upfile ok");
          if (that.limit == 1) {
            that.data = "http://img.wjhaomama.com/" + res;
          } else {
            that.data.push("http://img.wjhaomama.com/" + res);
          }
          that.$emit("onUpdate", that.data);
        })
        .catch(err => {
          wx.showToast({
            title: err
          });
        });
    }
  }
};
</script>

<style lang="scss">
.pic-upload {
  padding: 10rpx;
  display: flex;
  flex-direction: row;
  align-items: center;
  flex-wrap: wrap;
  .upload-btn {
    border: 1px dashed #ddd;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    margin-right: 20rpx;
  }
  .upload-add {
    font-size: 80rpx;
    font-weight: 500;
    color: #c9c9c9;
  }
}

.box {
  position: relative;
  .box__close {
    position: absolute;
    left: -16rpx;
    top: -16rpx;
    width: 45rpx;
    height: 45rpx;
    border-radius: 50%;
  }
}

.img {
  margin: 10rpx 30rpx 10rpx 0;
}
</style>
