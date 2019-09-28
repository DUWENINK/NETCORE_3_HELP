(function() {
    $("#ChargePersonName").bsSuggest({
        allowNoKeyword: true,
        multiWord: true,
        showHeader: true,
        effectiveFieldsAlias: { id: "主键", realName: "姓名", userQq: "QQ", departmentName: "部门" },
        effectiveFields: ["id", "realName", "userQq", "departmentName"],
        getDataMethod: "url",
        url: "/User/GetListWithKeywords?keywords=",
        idField: "id",
        keyField: "realName"
    }).on('onSetSelectValue', function(e, data) {
        $("#ChargePersonId").val(data.id);
    }).on('onUnsetSelectValue', function() {
        $("#ChargePersonId").val("");
    });

    //$("#Icon").focus(function() {
    //    parent.layer.open({
    //        title: '选择Icon图标',
    //        type: 2,
    //        content: "/Menu/FontAwesome",
    //        area: ['90%', '80%'],
    //        btn: ['确定', '关闭'],
    //        btnclass: ['btn btn-primary', 'btn btn-danger'],
    //        yes: function(index, layero) {
    //            var icon = $(layero).find("iframe")[0].contentWindow.getData();
    //            $("#Icon").val(icon);
    //            parent.layer.close(index);
    //        },
    //        cancel: function() {
    //            return true;
    //        }
    //    });
    //});
})();