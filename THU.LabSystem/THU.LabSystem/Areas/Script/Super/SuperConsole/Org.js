(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.Org";
        UI.fn.initPage();
        UI.fn.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#orgList").datagrid({
                    title: '组织列表',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'Code', title: '编码', width: 100 },
                            { field: 'Name', title: '名称', width: 100 }

                        ]],
                    toolbar: [
                            {
                                id: 'btnAdd',
                                text: '新增',
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editType.ClearEdit();
                                    $("#editForm").dialog({ title: '新增组织' }).dialog("open");
                                }

                            }, {
                                id: 'btnEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#orgList").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editType.ClearEdit();
                                        UI.fn.data.dataBind(row);
                                        UI.fn.editType.isEdit = true;
                                        $("#editForm").dialog({ title: '编辑组织' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#orgList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteOrgBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#orgList').datagrid('deleteRow', $('#orgList').datagrid('getRowIndex', rowData));
                                                    $("#btnEdit").linkbutton({ disabled: true });
                                                    $("#btnDelete").linkbutton({ disabled: true });
                                                }
                                            });

                                        } else {
                                            $.messager.alert("温馨提示", "请选择要删除的项", "error");
                                            return false;
                                        }
                                    }
                                });
                            }
                        },
                        {
                            id: 'btnReload',
                            iconCls: 'icon-reload',
                            text: '刷新',
                            handler: function () {
                                UI.fn.data.initData();
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
                initData: function () {
                    doActionAsync("THU.LabSystemBP.Agent.GetOrgListBPProxy", {}, function (data) {
                        if (data) {
                            $("#orgList").datagrid("loadData", data);
                        }
                    });
                },
                dataCollect: function () {
                    if ($("#txtCode").val() == "") {
                        $.messager.alert("提示", "编码不能为空", "info");
                        return false;
                    }
                    if ($("#txtName").val() == "") {
                        $.messager.alert("提示", "名称不能为空", "info");
                        return false;
                    }
                    UI.fn.data.exchangeData.Code = $("#txtCode").val();
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
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
                            args.OrgDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyOrgBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#orgList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#orgList").datagrid("refreshRow", $('#orgList').datagrid('getRowIndex', row));
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.OrgDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertOrgBPProxy", args, function (data) {
                                if (data) {
                                    $("#orgList").datagrid('appendRow', data);
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
                }
            }
        }
    }
})(jQuery);

 