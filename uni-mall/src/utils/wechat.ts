import api from './api';

var jweixin = require('jweixin-module');

export default {
    //判断是否在微信中  
    isWechat: function () {
        return /micromessenger/i.test(window.navigator.userAgent.toLowerCase());
    },
    //初始化sdk配置  
    initJssdk: function (callback: any) {
        api.h5({
            // url: encodeURIComponent(location.href.split('#')[0])
            url: location.href.split('#')[0]
        }).then((res: any) => {
            // console.log(res);
            jweixin.config({
                debug: false,
                appId: res.appId,
                timestamp: res.timestamp,
                nonceStr: res.nonceStr,
                signature: res.signature,
                jsApiList: [
                    'checkJsApi',
                    'onMenuShareTimeline',
                    'onMenuShareAppMessage'
                ]
            });
            //配置完成后，再执行分享等功能  
            if (callback) {
                callback(res);
            }
        })
    },
    //在需要自定义分享的页面中调用  
    share: function (data: any, url: string) {
        url = url ? url : window.location.href;
        if (!this.isWechat()) {
            return;
        }
        //每次都需要重新初始化配置，才可以进行分享  
        this.initJssdk(function (signData: any) {
            jweixin.ready(function () {
                var shareData = {
                    title: data && data.title ? data.title : signData.site_name,
                    desc: data && data.desc ? data.desc : signData.site_description,
                    link: url,
                    imgUrl: data && data.img ? data.img : signData.site_logo,
                    success: function (res: any) {
                        //用户点击分享后的回调，这里可以进行统计，例如分享送金币之类的  
                        //request.post('/api/member/share');
                    },
                    cancel: function (res: any) {
                    }
                };
                //分享给朋友接口  
                jweixin.onMenuShareAppMessage(shareData);
                //分享到朋友圈接口  
                jweixin.onMenuShareTimeline(shareData);
            });
        });
    }
}