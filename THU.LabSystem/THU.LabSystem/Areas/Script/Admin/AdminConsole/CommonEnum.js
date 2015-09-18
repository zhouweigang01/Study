(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.CommonEnum";
        UI.fn.initPage();
    });

    UI = {
        fn: {
            initPage: function () {

                var treeData = [
                {
                    text: "类别",
                    children: [
                    {
                        text: "学历",
                        iconCls: "icon-list",
                        attributes:
                        {
                            key: 1
                        }
                    },
                    {
                        text: "身份",
                        iconCls: "icon-list",
                        attributes:
                        {
                            key: 2
                        }
                    }
                    ,
                    {
                        text: "职位",
                        iconCls: "icon-list",
                        attributes:
                        {
                            key: 3
                        }
                    },
                    {
                        text: "部门",
                        iconCls: "icon-list",
                        attributes:
                        {
                            key: 4
                        }
                    },
                    {
                        text: "房间",
                        iconCls: "icon-list",
                        attributes:
                        {
                            key: 5
                        }
                    }
                    ]
                }
                ];
                $("#enumList").tree({
                    data: treeData,
                    lines: true,
                    onClick: function (node) {
                        if (node.attributes) {
                            doActionAsync("THU.LabSystemBP.Agent.GetEnumListBPProxy", { Type: node.attributes.key }, function (data) {
                                if (data) {
                                    $("#enumDetails").datagrid("loadData", data);
                                    $("#btnAdd").linkbutton({ disabled: false });
                                }
                            });
                        } else {
                            $("#enumDetails").datagrid("loadData", []);
                        }
                    }
                });

                $("#enumDetails").datagrid({
                    title: '枚举明细信息',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'Code', title: '编码', width: 100 },
                            { field: 'Name', title: '名称', width: 100 }

                        ]]
                        , toolbar: [
                            {
                                id: 'btnAdd',
                                text: '新增',
                                disabled: true,
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editType.ClearEdit();
                                    $("#editForm").dialog({ title: '新增类别信息' }).dialog("open");
                                }

                            }, {
                                id: 'btnEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#enumDetails").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editType.ClearEdit();
                                        UI.fn.data.dataBind(row);
                                        UI.fn.editType.isEdit = true;
                                        $("#editForm").dialog({ title: '编辑类别信息' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除当前类别信息？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#enumDetails").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteEnumBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#enumDetails').datagrid('deleteRow', $('#enumDetails').datagrid('getRowIndex', rowData));
                                                    $("#btnEdit").linkbutton({ disabled: true });
                                                    $("#btnDelete").linkbutton({ disabled: true });
                                                }
                                            });

                                        } else {
                                            $.messager.alert("温馨提示", "请选择要删除的类别信息", "error");
                                            return false;
                                        }
                                    }
                                });
                            }
                        }
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnEdit").linkbutton({ disabled: false });
                        $("#btnDelete").linkbutton({ disabled: false });
                    }
                });
                $("#editForm").dialog({
                    closed: true,
                    modal: true,
                    autoRowHeight: false,
                    pagination: true,
                    striped: true,
                    remoteSort: false,
                    singleSelect: true,
                    buttons: [{
                        iconCls: 'icon-ok',
                        text: '确定',
                        handler: function () {
                            UI.fn.editType.EditOK();
                        }
                    },
                    {
                        iconCls: 'icon-cancel',
                        text: '取消',
                        handler: function () {
                            UI.fn.editType.EditCancel();
                        }
                    }]
                });
            },
            data: {
                exchangeData: {},
                dataCollect: function () {
                    var node = $("#enumList").tree("getSelected");
                    if (!node) {
                        $.messager.alert("提示", "类别信息不能为空", "info");
                        return false;
                    }
                    if ($("#txtCode").val() == "") {
                        $.messager.alert("提示", "明细信息编码不能为空", "info");
                        return false;
                    }
                    if ($("#txtName").val() == "") {
                        $.messager.alert("提示", "明细信息名称不能为空", "info");
                        return false;
                    }
                    UI.fn.data.exchangeData.Code = $("#txtCode").val();
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
                    UI.fn.data.exchangeData.Type = node.attributes.key;
                    return true;
                },
                dataBind: function (row) {
                    UI.fn.data.exchangeData = row;
                    $("#txtCode").val(row.Code);
                    $("#txtName").val(row.Name);
                }
            },
            editType: {
                isEdit: false,
                EditOK: function () {
                    if (UI.fn.data.dataCollect()) {
                        var args = {};
                        if (UI.fn.editType.isEdit && UI.fn.data.exchangeData.ID > 0) {
                            //编辑
                            args.EnumDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyEnumBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#enumDetails").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#enumDetails").datagrid("refreshRow", $('#enumDetails').datagrid('getRowIndex', row));
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.EnumDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertEnumBPProxy", args, function (data) {
                                if (data) {
                                    $("#enumDetails").datagrid('appendRow', data);
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        }
                    }
                },
                EditCancel: function () {
                    UI.fn.editType.ClearEdit();
                    UI.fn.editType.isEdit = false;
                    UI.fn.data.exchangeData = {};
                    $("#editForm").window("close");

                },
                ClearEdit: function () {
                    $("#txtCode").val("");
                    $("#txtName").val("");
                    $("#txtPassword").val("");
                }
            }
        }
    }
})(jQuery);