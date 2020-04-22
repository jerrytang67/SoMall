$(function () {
    var dataTable = $('#ShopsTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        ajax: abp.libs.datatables.createAjax(tT.abp.mall.application.shops.mallShop.getList),
        columnDefs: [
            {data: "name"},
            {data: "shortName"},
            {data: "logoImage"},
        ]
    }));
});