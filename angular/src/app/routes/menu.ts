export const menu = [
    { text: '主导航', heading: true },
    { text: '分析页', link: '/dashboard/analysis', icon: 'fa fa-chart-line' },
    { text: "工作台", link: "/dashboard/workplace", icon: 'fa fa-tachometer-alt' },


    { text: 'SAAS', heading: true },
    { text: "用户列表", link: "/identity/users", icon: "fa fa-user" },
    { text: "角色列表", link: "/identity/roles", icon: "fa fa-key" },
    { text: "租户", link: "/tenant/tenants", icon: "fa fa-key" },
    { text: "应用管理", link: "/app-management/apps", icon: "fa fa-app" },

    { text: '商家管理', heading: true },
    { text: "商家列表", link: "/shop-management", icon: "fa fa-store" },

    { text: '商城系统', heading: true },
    { text: "商铺", link: "/mall/shops", icon: "fa fa-store" },
    { text: "商品分类", link: "/mall/categories", icon: "fas fa-sitemap" },
    { text: "商品列表", link: "/mall/spus", icon: "far fa-lightbulb" },
    { text: "订单列表", link: "/mall/orders", icon: "fas fa-donate" },
    { text: "支付请求列表", link: "/mall/payOrders", icon: "fas fa-donate" },
    { text: "合伙人列表", link: "/mall/partners", icon: "far fa-user" },
    { text: "地址列表", link: "/mall/addresses", icon: "far fa-address-book" },
    { text: "商城用户", link: "/mall/users", icon: "far fa-user" },
    { text: "优惠券列表", link: "/mall/coupons", icon: "far fa-user" },
    { text: "用户优惠券", link: "/mall/userCoupons", icon: "far fa-user" },
    { text: "滚动广告", link: "/mall/swiper", icon: "far fa-ads" },

    { text: '访客管理', heading: true },
    { text: "表单列表", link: "/visitor/forms", icon: 'fa fa-address-book' },

    { text: '帐号管理', heading: true },
    { text: "微信用户管理", link: "/account-management/wechatUserInfos", icon: 'fa fa-address-book' },
    { text: "实名认证", link: "/account-management/realNameInfos", icon: "far fa-address-book" },


    { text: '访客管理', heading: true },
    {
        text: "管理工具", icon: "fa fa-brain",
        submenu: [
            { text: "ids登录信息", link: "/demo/demo1", icon: "fa fa-user-astronaut" },
            { text: "swagger", elink: "http://127.0.0.1:44340/swagger/index.html", target: "_blank", icon: "fa fa-restroom" },
            { text: "Kibana(Local)", elink: "http://127.0.0.1:5601", target: "_blank", icon: "fa fa-restroom" },
            { text: "Cap", elink: "http://127.0.0.1:44340/cap", target: "_blank", icon: "fa fa-crown" },
            { text: "Consul", elink: "http://127.0.0.1:8500", target: "_blank", icon: "fa fa-database" },
            { text: "Redis", elink: "http://127.0.0.1:8500", target: "_blank", icon: "fa fa-registered" },
            { text: "ng-zorro", elink: "https://ng.ant.design/version/next/docs/introduce/zh", target: "_blank", icon: "fab fa-alipay" },
            { text: "fontawesome", elink: "https://fontawesome.com/icons?d=gallery&q=auth", target: "_blank", icon: "fab fa-fonticons" },
            { text: "angular", elink: "https://angular.io/docs", target: "_blank", icon: "fab fa-angular" },
            { text: "bootstrap", elink: "https://getbootstrap.com/docs/4.4/getting-started/introduction/", target: "_blank", icon: "fab fa-angular" },
            { text: "Jenkins", elink: "http://wwwttt.vicp.net:18080/", target: "_blank", icon: "fab fa-jenkins" },
        ]
    }
];
