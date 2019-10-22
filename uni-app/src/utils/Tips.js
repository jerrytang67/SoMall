import Dialog from "../../static/dist/dialog/dialog";


export default class Tips {
  constructor() {
    this.isLoading = false;
  }

  static confirm(title = "确定吗?", message = "") {
    console.log(title,message);
    return new Promise((resolve, reject) => {
      Dialog.confirm({
          title: title,
          message: message
        }).then(() => resolve())
        .catch(() => reject());
    })
  }

  /**
   * 弹出加载提示
   */
  static loading(title = "加载中") {
    if (Tips.isLoading) {
      return;
    }
    Tips.isLoading = true;
    wx.showLoading({
      title: title,
      mask: true
    });
  }

  /**
   * 加载完毕
   */
  static loaded() {
    if (Tips.isLoading) {
      Tips.isLoading = false;
      wx.hideLoading();
    }
  }

  //出错
  static error(msg, duration = 5000) {
    wx.showToast({
      title: `${msg}`,
      // image: `/static/images/error-msg.png`,
      icon: "none",
      duration: duration
    })
  }
}

/**
 * 静态变量，是否加载中
 */
Tips.isLoading = false;
