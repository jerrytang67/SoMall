// const Tips = require("./Tips")
// const Promise = require('es6-promise').Promise
import Promise from 'es6-promise';
import Tips from './Tips'

function httpsPromisify(fn) {
  return function (obj = {}) {
    return new Promise((resolve, reject) => {
      obj.success = function (res) {
        Tips.loaded();
        if (res.data.success) {
          resolve(res.data.data)
        } else {
          if (res.data.needAuth) {
            wx.navigateTo({
              url: '/pages/index/login'
            });
            return;
          }
          Tips.error(res.data.msg);
          reject(res.data.msg);
        }
      }
      obj.fail = function (res) {
        console.log(res)
        Tips.loaded();
        reject(res)
      }
      fn(obj)
    })
  }
}

export default {
  httpsPromisify
}
