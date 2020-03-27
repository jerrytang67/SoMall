export const menu = [
    { text: '主导航', heading: true },
    { text: '分析页', link: '/dashboard/analysis', icon: 'fa fa-chart-line' },
    { text: "工作台", link: "/dashboard/workplace", icon: 'fa fa-tachometer-alt' },
    { text: '商家管理', heading: true },
    { text: "商家列表", link: "/shop-management", icon: "fa fa-store" },
    { text: '商城系统', heading: true },
    { text: "商铺", link: "/mall", icon: "fa fa-store" },
    { text: '访客管理', heading: true }, { text: "表单列表", link: "/visitor/forms", icon: 'fa fa-address-book' },
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
        ]
    }
];
