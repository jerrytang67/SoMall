export const PREFIX = 'somall_';
/**
 * 存储localStorage
 * @param name
 * @param content
 * @param duration Storage有效时间，单位：小时
 * @param set_time 是否设置时间
 * @returns {boolean}
 */
export const setStore = (name: string, content: any, set_time = false, duration = 0) => {
    if (!name) return false;
    name = PREFIX + name;
    if (typeof content !== 'string') {
        content = JSON.stringify(content)
    }
    if (set_time) {
        const date = new Date;
        if (duration > 0) {
            content += '&' + (date.getTime() + duration * 3600 * 1e3)
        } else {
            content += '&0'
        }
        content += '&' + (date.getTime())
    }
    window.localStorage.setItem(name, content)
};

/**
 * 获取localStorage
 * @param name
 * @returns {boolean}
 */
export function getStore<T>(name: string): T | undefined {
    const parse = true;
    if (!name) return undefined;
    name = PREFIX + name;
    if (parse) {
        if (typeof (window.localStorage.getItem(name)) == "string" && window.localStorage.getItem(name) != "undefined") {
            return JSON.parse(window.localStorage.getItem(name) || "null")
        }
    }
};

/**
 * 删除localStorage
 */
export const removeStore = (name: string) => {
    if (!name) return false;
    name = PREFIX + name;
    window.localStorage.removeItem(name)
};
