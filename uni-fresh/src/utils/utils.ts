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
                resolve(data)

                // if (data.success) {
                //     resolve(data.result)
                // } else {
                //     if (data.unAuthorizedRequest) {
                //         uni.navigateTo({
                //             url: '/pages/index/login'
                //         });
                //         reject(data.error.message);
                //         return;
                //     }
                //     errorPrompt(data.error.details || data.error.message)
                //     reject(data.error.details || data.error.message);
                // }
            }
            options!.fail = (err: any) => {
                console.log(err)
                uni.hideLoading();
                uni.hideNavigationBarLoading();
                reject(err)
            }
            fn(options)
        })
    }
}

export default {
    httpsPromisify
}