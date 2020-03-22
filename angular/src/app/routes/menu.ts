
const Home = {
    text: '分析页',
    link: '/dashboard/analysis',
    icon: 'icon-home'
};

const headingMain = {
    text: '主导航',
    heading: true
};

export const menu = [
    headingMain,
    {
        text: '分析页',
        link: '/dashboard/analysis',
        icon: 'fa fa-chart-line'
    },
    {
        text: "工作台",
        link: "/dashboard/workplace",
        icon: 'fa fa-tachometer-alt'
    }
    ,
    {
        text: '商家管理',
        heading: true
    },
    {
        "text": "商家列表",
        "link": "/shop-management",
        icon:"fa fa-store"
    }
    ,
    {
        text: '访客管理',
        heading: true
    },
    {
        "text": "表单列表",
        "link": "/visitor/forms",
        icon:'fa fa-address-book'
    }
    ,
    {
        text: '访客管理',
        heading: true
    },
    {
        "text": "登录信息",
        "link": "/demo/demo1",
        icon:"fa fa-user"
    },
    {
        "text": "Kibana(Local)",
        "link": "http://127.0.0.1:5601",
        icon:"fa fa-chart-pie"
    }
];
