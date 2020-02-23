export abstract class Tips {

    private static isLoading: boolean = false;

    constructor() {
    }

    public static confirm(title = "确定吗?", message = ""): Promise<boolean> {
        return new Promise((resolve, reject) => {
            uni.showModal({
                title: title,
                content: message,
                success: (res) => {
                    if (res.confirm) {
                        console.log('用户点击确定');
                        return resolve(true);
                    } else if (res.cancel) {
                        console.log('用户点击取消');
                        return reject(false);
                    }
                }
            });
        });
    }

    /**
     * 弹出加载提示
     */
    public static loading(title = "加载中"): void {
        if (Tips.isLoading) {
            return;
        }
        Tips.isLoading = true;
        uni.showLoading({
            title: title,
            mask: true
        });
    }

    public static loaded(): void {
        if (Tips.isLoading) {
            Tips.isLoading = false;
            uni.hideLoading();
        }
    }

    public static info(msg: string, duration = 2000): void {
        console.log("info");
        uni.showToast({
            title: `${msg}`,
            icon: "none",
            duration: duration
        })
    }

    public static success(msg: string, duration = 2000): void {
        uni.showToast({
            title: `${msg}`,
            icon: "success",
            duration: duration
        })
    }
}