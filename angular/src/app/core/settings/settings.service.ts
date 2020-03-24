import { Injectable } from '@angular/core';

@Injectable()
export class SettingsService {

    public user: any;
    private app: any;
    private layout: any;

    constructor() {

        // User Settings
        // -----------------------------------
        this.user = {
            name: 'TT',
            job: 'ng-developer',
            picture: 'https://wx.qlogo.cn/mmopen/vi_32/PiajxSqBRaEIRaX5cTpKvbticN9ghp25GC05Kic8o3Ydoiam0Xmz9lZXo0QxW3iac7X7EFWAX4nsO8VpR2TbYpd9wGQ/132'
        };

        // App Settings
        // -----------------------------------
        this.app = {
            name: 'SoMall',
            description: '社交电商 开拓者',
            year: ((new Date()).getFullYear())
        };

        // Layout Settings
        // -----------------------------------
        this.layout = {
            isFixed: true,
            isCollapsed: false,
            isBoxed: false,
            isRTL: false,
            horizontal: false,
            isFloat: false,
            asideHover: false,
            theme: null,
            asideScrollbar: false,
            isCollapsedText: false,
            useFullLayout: false,
            hiddenFooter: false,
            offsidebarOpen: false,
            asideToggled: false,
            viewAnimation: 'ng-fadeInUp'
        };

    }

    getAppSetting(name) {
        return name ? this.app[name] : this.app;
    }
    getUserSetting(name) {
        return name ? this.user[name] : this.user;
    }
    getLayoutSetting(name) {
        return name ? this.layout[name] : this.layout;
    }

    setAppSetting(name, value) {
        if (typeof this.app[name] !== 'undefined') {
            this.app[name] = value;
        }
    }
    setUserSetting(name, value) {
        if (typeof this.user[name] !== 'undefined') {
            this.user[name] = value;
        }
    }
    setLayoutSetting(name, value) {
        if (typeof this.layout[name] !== 'undefined') {
            return this.layout[name] = value;
        }
    }

    toggleLayoutSetting(name) {
        return this.setLayoutSetting(name, !this.getLayoutSetting(name));
    }

}
