let colorList: string[] = ["magenta", "volcano", "orange", "#2db7f5", "#87d068", "#108ee9", "#f50",]
let appList: string[] = []

export function getRndAppColor(str): string {
    if (this.appList.indexOf(str) > -1) {
        return this.colorList[this.appList.indexOf(str)];
    }
    else {
        this.appList.push(str);
        return this.colorList[this.appList.indexOf(str)];
    }
}