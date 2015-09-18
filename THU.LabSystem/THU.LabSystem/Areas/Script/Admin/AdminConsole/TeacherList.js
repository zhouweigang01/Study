(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.TeacherList";
        UI.fn.initPage();
        UI.fn.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#teacherList").datagrid({
                    title: '教师列表',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'Name', title: '姓名', width: 100 },
                            { field: 'SexName', title: '性别', width: 100 },
                            { field: 'PositionName', title: '职位', width: 100 },
                            { field: 'DepartmentName', title: '所属院系', width: 100 }

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
                                    var row = $("#teacherList").datagrid("getSelected");
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
                                        var rowData = $("#teacherList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteTeacherBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#teacherList').datagrid('deleteRow', $('#teacherList').datagrid('getRowIndex', rowData));
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
                    doActionAsync("THU.LabSystemBP.Agent.GetTeacherListBPProxy", {}, function (data) {
                        if (data) {
                            $("#teacherList").datagrid("loadData", data);
                        }
                    });

                    var args = {};
                    args.TypeList = [3, 4];
                    doActionAsync("THU.LabSystemBP.Agent.GetGroupEnumListBPProxy", args, function (data) {
                        if (data) {
                            $.each(data, function (i, item) {
                                if (item.Type == 3) {
                                    $("#txtPosition").combobox(
                                    {
                                        valueField: 'ID',
                                        textField: 'Name'
                                    }).combobox("loadData", item.EnumList);
                                }
                                else if (item.Type == 4) {
                                    $("#txtDepartment").combobox(
                                    {
                                        valueField: 'ID',
                                        textField: 'Name'
                                    }).combobox("loadData", item.EnumList);
                                }
                            });
                        }
                    });
                },
                dataCollect: function () {
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
                    UI.fn.data.exchangeData.Sex = $("#txtSex").combobox("getValue");
                    UI.fn.data.exchangeData.Position = $("#txtPosition").combobox("getValue");
                    UI.fn.data.exchangeData.Department = $("#txtDepartment").combobox("getValue");
                    if (UI.fn.data.exchangeData.Name == "") {
                        $.messager.alert("提示", "教师姓名不能为空", "info");
                        return false;
                    }
                    if (UI.fn.data.exchangeData.Position <= 0) {
                        $.messager.alert("提示", "教师职位不能为空", "info");
                        return false;
                    }

                    return true;
                },
                dataBind: function (row) {
                    UI.fn.data.exchangeData = row;
                    $("#txtName").val(row.Name);
                    $("#txtSex").val(row.Sex);
                    $("#txtPosition").val(row.Position);
                    $("#txtDepartment").val(row.Department);
                }
            },
            editType: {
                isEdit: false,
                EditOK: function () {
                    if (UI.fn.data.dataCollect()) {
                        var args = {};
                        if (UI.fn.editType.isEdit && UI.fn.data.exchangeData.ID > 0) {
                            //编辑
                            args.TeacherDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyTeacherBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#teacherList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#teacherList").datagrid("refreshRow", $('#teacherList').datagrid('getRowIndex', row));
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.TeacherDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertTeacherBPProxy", args, function (data) {
                                if (data) {
                                    $("#teacherList").datagrid('appendRow', data);
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
                    $("#txtName").val("");
                    $("#txtSex").combobox("setValue", "1");
                    $("#txtPosition").combobox("setValue", -1);
                    $("#txtPosition").combobox("setText", "");
                    $("#txtDepartment").combobox("setValue", -1);
                    $("#txtDepartment").combobox("setText", "");
                }
            }
        }
    }
})(jQuery);

 