const errorPrompt = (err: any) => {
    uni.showToast({
        title: err || 'fetch data error.',
        icon: 'none'
    })
}

const httpsPromisify = (fn: Function) => {
    return function (options: RequestOptions | undefined) {
        return new Promise((resolve, reject) => {
            options!.success = ({
                data
            }: any) => {
                uni.hideLoading();
                uni.hideNavigationBarLoading();
                if (data.error) {
                    if (data.error.validationErrors && data.error.validationErrors.length) {
                        let info = data.error.validationErrors.reduce((c: string, o: any) => c += `${o.message}\r\n`, "");
                        uni.showModal({
                            title: data.error.message,
                            content: info,
                            showCancel: false,
                            success: function (res) {
                                if (res.confirm) {
                                    console.log('用户点击确定');
                                } else if (res.cancel) {
                                    console.log('用户点击取消');
                                }
                            }
                        });
                    }
                    return reject(data.error)
                }
                else {
                    return resolve(data)
                }
            }
            options!.fail = (err: any) => {
                console.log("httpsPromisify", err)
                uni.hideLoading();
                uni.hideNavigationBarLoading();
                return reject(err)
            }
            fn(options)
        })
    }
}

export default {
    httpsPromisify
}