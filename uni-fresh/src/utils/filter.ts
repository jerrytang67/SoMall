import dayjs from 'dayjs'

const formatDate = (value: any, arg: string | undefined) => {
    console.log(value)
    if (value) {
        return dayjs(value).format('YYYY-MM-DD HH:mm')
    }
}

const currency = (value: any | undefined) => {
    console.log(value);

    if (value !== undefined) {
        return '￥' + parseFloat(value).toFixed(2)
    }
    return value
}

export default {
    currency,
    formatDate
}
