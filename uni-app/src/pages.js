// pages.js

const usingComponents = {
  "van-button": "/static/dist/button/index",
  "van-toast": "/static/dist/toast/index",
  "van-tag": "/static/dist/tag/index",
  "van-icon": "/static/dist/icon/index",
  "van-row": "/static/dist/row/index",
  "van-col": "/static/dist/col/index",
  "van-cell": "/static/dist/cell/index",
  "van-switch-cell": "/static/dist/switch-cell/index",
  "van-switch": "/static/dist/switch/index",
  "van-panel": "/static/dist/panel/index",

  "van-card": "/static/dist/card/index",

  "van-tabbar": "/static/dist/tabbar/index",
  "van-tabbar-item": "/static/dist/tabbar-item/index",
  "van-goods-action": "/static/dist/goods-action/index",
  "van-goods-action-icon": "/static/dist/goods-action-icon/index",
  "van-goods-action-button": "/static/dist/goods-action-button/index",
  "van-dialog": "/static/dist/dialog/index",
  "van-popup": "/static/dist/popup/index",
  "demo-block": "/static/demo-block/index"
}

module.exports = [{
    path: 'pages/index/index',
    config: {
      navigationBarTitleText: '',
      enablePullDownRefresh: true,
      usingComponents: Object.assign({}, usingComponents, {})
    }
  },
  {
    path: 'pages/index/my',
    config: {
      navigationBarTitleText: '我的',
      enablePullDownRefresh: true,
      usingComponents: Object.assign({}, usingComponents, {})
    }
  }
]
