(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.OrgUser";
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
                            id: 'btnReload',
                            iconCls: 'icon-reload',
                            text: '刷新',
                            handler: function () {
                                UI.fn.data.initData();
                            }
                        }
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnAdd").linkbutton({ disabled: false });
                        var args = {};
                        args.PageIndex = 1;
                        args.PageSize = 10;
                        args.OrgKey = rowData.ID;
                        Easyui.DataGrid.GetDataGridList("#userList", args, "THU.LabSystemBP.Agent.GetAdminUserListBPProxy");
                    }
                });
                $("#userList").datagrid({
                    title: '组织管理员',
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
                                    $("#editForm").dialog({ title: '新增管理员' }).dialog("open");
                                }

                            }, {
                                id: 'btnEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#userList").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editType.ClearEdit();
                                        UI.fn.data.dataBind(row);
                                        UI.fn.editType.isEdit = true;
                                        $("#editForm").dialog({ title: '编辑管理员' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除当前管理员？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#userList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteAdminUserBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#userList').datagrid('deleteRow', $('#userList').datagrid('getRowIndex', rowData));
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
                    $("#userList").datagrid("loadData", []);
                    $("#btnAdd").linkbutton({ disabled: true });
                },
                dataCollect: function () {
                    var orgRow = $("#orgList").datagrid("getSelected");
                    if (!orgRow) {
                        $.messager.alert("提示", "系统管理员所属组织不能为空", "info");
                        return false;
                    }
                    if ($("#txtCode").val() == "") {
                        $.messager.alert("提示", "用户登录名不能为空", "info");
                        return false;
                    }
                    if ($("#txtPassword").val() == "") {
                        $.messager.alert("提示", "用户密码不能为空", "info");
                        return false;
                    }
                    UI.fn.data.exchangeData.Code = $("#txtCode").val();
                    UI.fn.data.exchangeData.Password = $("#txtPassword").val();
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
                    UI.fn.data.exchangeData.Type = 2;
                    UI.fn.data.exchangeData.OrgR = orgRow.ID;
                    return true;
                },
                dataBind: function (row) {
                    UI.fn.data.exchangeData = row;
                    $("#txtCode").val(row.Code);
                    $("#txtPassword").val(row.Password);
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
                            args.UserDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyAdminUserBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#userList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#userList").datagrid("refreshRow", $('#userList').datagrid('getRowIndex', row));
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.UserDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertAdminUserBPProxy", args, function (data) {
                                if (data) {
                                    $("#userList").datagrid('appendRow', data);
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

 