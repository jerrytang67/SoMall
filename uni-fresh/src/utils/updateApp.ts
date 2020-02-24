const updateApp = () => {
    const updateManager = uni.getUpdateManager()
    updateManager.onCheckForUpdate(function (res) {
        // 请求完新版本信息的回调
        if (res.hasUpdate) {
            uni.showLoading({
                title: '更新下载中...',
            })
        }
    })
    updateManager.onUpdateReady(function () {
        uni.hideLoading();
        uni.showModal({
            title: '更新提示',
            content: '新版本已经准备好，是否重启应用？',
            success: function (res) {
                if (res.confirm) {
                    // 新的版本已经下载好，调用 applyUpdate 应用新版本并重启
                    updateManager.applyUpdate()
                }
            }
        })

    })
    updateManager.onUpdateFailed(function () {
        // 新的版本下载失败
        uni.hideLoading();
        uni.showToast({
            title: '下载失败...',
            icon: "none"
        });
    })
}
export default {
    updateApp
}