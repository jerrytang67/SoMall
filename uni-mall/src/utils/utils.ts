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
                    return reject(data.error)
                }
                else {
                    return resolve(data)
                }
            }
            options!.fail = (err: any) => {
                console.log(err)
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