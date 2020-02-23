import * as dayjs from 'dayjs'
import 'dayjs/locale/zh-cn' // import locale

function formatDate(value: any, arg: string | undefined) {
    if (value) {
        if (arg) {
            if (arg === 'fromNow') { return dayjs(String(value)).fromNow() }
            return dayjs(String(value)).format(arg)
        }
        return dayjs(String(value)).format('YYYY-MM-DD HH:mm')
    }
}

function currency(value: any) {
    if (value !== undefined) {
        return '￥' + parseFloat(value).toFixed(2)
    }
    return value
}

export default {
    currency,
    formatDate
}
