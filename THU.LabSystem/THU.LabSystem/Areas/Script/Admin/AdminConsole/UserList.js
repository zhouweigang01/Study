(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.UserList";
        UI.fn.initPage();
        UI.fn.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#userList").datagrid({
                    title: '用户列表',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'Name', title: '名称', align: 'center', width: 100 },
                            { field: 'Tel', title: '电话', align: 'center', width: 100 },
                            { field: 'SN', title: '学号', align: 'center', width: 100 },
                             { field: 'TeacherName', title: '导师', align: 'center', width: 100 },
                            { field: 'BeginTime', title: '进实验室时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'EndTime', title: '出实验室时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'DegreeName', title: '学历', align: 'center', width: 100 },
                            { field: 'StatusName', title: '身份', align: 'center', width: 100 }
                        ]],
                    toolbar: [
                            {
                                id: 'btnAdd',
                                text: '新增',
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editType.ClearEdit();
                                    $("#editForm").dialog({ title: '新增用户' }).dialog("open");
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
                                        $("#editForm").dialog({ title: '编辑用户' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除当前使用用户？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#userList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteUserBPProxy", args, function (del) {
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
                        },
                        {
                            id: 'btnReload',
                            iconCls: 'icon-reload',
                            text: '刷新',
                            handler: function () {
                                UI.fn.data.initData();
                            }
                        },
                        "|",
                        "<span class=\"datagrid-toolbar-label\">搜索</span><select id=\"txtSearchUser\" style=\"width:120px\"></select>"
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnEdit").linkbutton({ disabled: false });
                        $("#btnDelete").linkbutton({ disabled: false });

                        $("#btnForbitAdd").linkbutton({ disabled: false });
                        var args = { UserKey: rowData.ID };
                        args.PageSize = 10;
                        args.PageIndex = 1;
                        Easyui.DataGrid.GetDataGridList("#loggerList", args, "THU.LabSystemBP.Agent.GetLoggerListBPProxy");

                        UI.fn.forbitData.initData(rowData.ID);

                    }
                });
                $("#forbitList").datagrid({
                    //  title: '实验室设备',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'UserName', title: '用户名', width: 100, align: 'center' },
                            { field: 'StartTime', title: '开始时间', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'EndTime', title: '结束时间', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd");
                                } else {
                                    return "-";
                                }
                            }
                            }

                        ]],
                    toolbar: [
                            {
                                id: 'btnForbitAdd',
                                text: '新增',
                                disabled: true,
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editForbitType.isEdit = false;
                                    UI.fn.editForbitType.ClearEdit();
                                    UI.fn.forbitData.dataBind();
                                    $("#editForbitForm").dialog({ title: '新增用户惩罚记录' }).dialog("open");
                                }

                            }, {
                                id: 'btnForbitEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#forbitList").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editForbitType.isEdit = true;
                                        UI.fn.editForbitType.ClearEdit();
                                        UI.fn.forbitData.dataBind(row);
                                        $("#editForbitForm").dialog({ title: '编辑用户惩罚记录' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnForbitDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除当前惩罚记录？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#forbitList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteForbitBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#forbitList').datagrid('deleteRow', $('#forbitList').datagrid('getRowIndex', rowData));
                                                    $("#btnForbitEdit").linkbutton({ disabled: true });
                                                    $("#btnForbitDelete").linkbutton({ disabled: true });
                                                }
                                            });

                                        } else {
                                            $.messager.alert("温馨提示", "请选择要删除的惩罚记录", "error");
                                            return false;
                                        }
                                    }
                                });
                            }
                        }
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnForbitEdit").linkbutton({ disabled: false });
                        $("#btnForbitDelete").linkbutton({ disabled: false });
                    }
                });
                $("#loggerList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'Name', title: '登录名', align: 'center', width: 100 },
                            { field: 'LoginDate', title: '登陆时间', align: 'center', width: 60, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'IP', title: '来源IP', align: 'center', width: 100 },
                            { field: 'ErrorMsg', title: '错误原因', align: 'center', width: 100 }
                        ]]
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
                $("#editForbitForm").dialog({
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
                            UI.fn.editForbitType.EditOK();
                        }
                    },
                    {
                        iconCls: 'icon-cancel',
                        text: '取消',
                        handler: function () {
                            UI.fn.editForbitType.EditCancel();
                        }
                    }]
                });
                $('#txtBeginTime,#txtEndTime').datebox({
                    parser: dateparser,
                    formatter: dateformatter
                });

                $('#txtForbitBeginTime,#txtForbitEndTime').datebox({
                    parser: dateparser,
                    formatter: dateformatter
                });
                function dateformatter(date) {
                    if (date) {
                        var y = date.getFullYear();
                        var m = date.getMonth() + 1;
                        var d = date.getDate();
                        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
                    }
                    return "";
                }
                function dateparser(s) {
                    if (!s) return new Date();
                    var ss = (s.split('-'));
                    var y = parseInt(ss[0], 10);
                    var m = parseInt(ss[1], 10);
                    var d = parseInt(ss[2], 10);
                    if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                        return new Date(y, m - 1, d);
                    } else {
                        return new Date();
                    }
                }

                $("#txtTeacher").searchgrid({
                    panelWidth: 320,
                    panelHeight: 120,
                    idField: 'ID',
                    textField: 'Name',
                    columns: [[
                             { field: 'Name', title: '姓名', width: 100, align: 'center' },
                             { field: 'PositionName', title: '职称', width: 100, align: 'center' },
                             { field: 'DepartmentName', title: '院系', width: 100, align: 'center' }
                    ]],
                    searchHandler: function (value) {
                        if (value != "") {
                            doActionAsync("THU.LabSystemBP.Agent.SearchTeacherListBPProxy", { AttrubuteList: ["Name", "Tag"], SearchTxt: value }, function (data) {
                                if (data) {
                                    $("#txtTeacher").searchgrid("loadData", data);

                                }
                            }, null, null, false);
                        } else {
                            $("#txtTeacher").searchgrid("hidePanel");
                            $("#txtTeacher").searchgrid("loadData", UI.fn.data.teacherList);
                        }
                    }
                });

                $("#txtSearchUser").searchgrid({
                    panelWidth: 420,
                    panelHeight: 120,
                    idField: 'ID',
                    textField: 'Name',
                    columns: [[
                             { field: 'Name', title: '姓名', width: 100, align: 'center' },
                             { field: 'DegreeName', title: '学历', width: 100, align: 'center' },
                             { field: 'TeacherName', title: '导师', width: 100, align: 'center' },
                             { field: 'StatusName', title: '身份', width: 100, align: 'center' },
                    ]],
                    searchHandler: function (value) {
                        if (value != "") {
                            doActionAsync("THU.LabSystemBP.Agent.SearchUserListBPProxy", { AttrubuteList: ["Name", "SN", "Teacher.Name"], SearchTxt: value }, function (data) {
                                if (data) {
                                    $("#txtSearchUser").searchgrid("loadData", data);

                                }
                            }, null, null, false);
                        } else {
                            $("#txtSearchUser").searchgrid("hidePanel");
                            UI.fn.data.initData();

                        }
                    },
                    onClickRow: function (rowIndex, rowData) {
                        UI.fn.data.initData($("#txtSearchUser").searchgrid("getValue"));
                    }
                });
            },
            forbitData: {
                exchangeData: {},
                initData: function (key) {
                    var args = {};
                    args.UserKey = key;
                    doActionAsync("THU.LabSystemBP.Agent.GetForbitListBPProxy", args, function (data) {
                        if (data) {
                            $("#forbitList").datagrid("loadData", data);
                        }
                    });
                    $("#btnForbitEdit").linkbutton({ disabled: true });
                    $("#btnForbitDelete").linkbutton({ disabled: true });
                },
                dataCollect: function () {
                    var row = $("#userList").datagrid("getSelected");
                    if (row) {
                        UI.fn.forbitData.exchangeData.User = row.ID;
                    }

                    UI.fn.forbitData.exchangeData.StartTime = $("#txtForbitBeginTime").datebox("getText");
                    UI.fn.forbitData.exchangeData.EndTime = $("#txtForbitEndTime").datebox("getText");


                    if (UI.fn.forbitData.exchangeData.StartTime == "") {
                        $.messager.alert("提示", "开始时间不能为空", "info");
                        return false;
                    }
                    if (UI.fn.forbitData.exchangeData.EndTime == "") {
                        $.messager.alert("提示", "结束时间不能为空", "info");
                        return false;
                    }
                    if (UI.fn.forbitData.exchangeData.User == "") {
                        $.messager.alert("提示", "用户不能为空", "info");
                        return false;
                    }

                    return true;
                },
                dataBind: function (row) {
                    if (row) {
                        UI.fn.forbitData.exchangeData = row;
                    }
                    var usr = $("#userList").datagrid("getSelected");
                    if (usr) {
                        $("#txtForbitName").val(usr.Name);
                    }
                    if (UI.fn.editForbitType.isEdit) {
                        $("#txtForbitBeginTime").datebox("setText", Util.DateTime.DateToStr(row.StartTime, "yyyy-MM-dd"));
                        $("#txtForbitEndTime").datebox("setText", Util.DateTime.DateToStr(row.EndTime, "yyyy-MM-dd"));
                        $("#txtForbitBeginTime").datebox("setValue", Util.DateTime.DateToStr(row.StartTime, "yyyy-MM-dd"));
                        $("#txtForbitEndTime").datebox("setValue", Util.DateTime.DateToStr(row.EndTime, "yyyy-MM-dd"));
                    }
                }
            },
            data: {
                teacherList: [],
                exchangeData: {},
                initData: function (id) {
                    var args = {};
                    args.Type = 1;
                    args.PageIndex = 1;
                    args.PageSize = 20;
                    if (id) {
                        args.ID = id;
                    }
                    Easyui.DataGrid.GetDataGridList("#userList", args, "THU.LabSystemBP.Agent.GetUserListBPProxy");
                    var args = {};
                    args.TypeList = [1, 2];
                    doActionAsync("THU.LabSystemBP.Agent.GetGroupEnumListBPProxy", args, function (data) {
                        if (data) {
                            $.each(data, function (i, item) {
                                if (item.Type == 1) {
                                    $("#txtDegree").combobox(
                                    {
                                        valueField: 'ID',
                                        textField: 'Name'
                                    }).combobox("loadData", item.EnumList);
                                }
                                else if (item.Type == 2) {
                                    $("#txtStatus").combobox(
                                    {
                                        valueField: 'ID',
                                        textField: 'Name'
                                    }).combobox("loadData", item.EnumList);
                                }
                            });
                        }
                    });
                    $("#loggerList").datagrid("loadData", []);
                    $("#btnEdit").linkbutton({ disabled: true });
                    $("#btnDelete").linkbutton({ disabled: true });


                    $("#btnForbitAdd").linkbutton({ disabled: true });
                    $("#btnForbitEdit").linkbutton({ disabled: true });
                    $("#btnForbitDelete").linkbutton({ disabled: true });
                    doActionAsync("THU.LabSystemBP.Agent.GetTeacherListBPProxy", {}, function (data) {
                        if (data) {
                            UI.fn.data.teacherList = data;
                            $("#txtTeacher").searchgrid("loadData", UI.fn.data.teacherList);
                        }
                    });

                    $("#forbitList").datagrid("loadData", []);
                },
                dataCollect: function () {
                    UI.fn.data.exchangeData.Code = $("#txtCode").val();
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
                    UI.fn.data.exchangeData.Password = $("#txtPassword").val();
                    UI.fn.data.exchangeData.SN = $("#txtSN").val();
                    UI.fn.data.exchangeData.Tel = $("#txtTel").val();
                    UI.fn.data.exchangeData.Email = $("#txtEmail").val();
                    UI.fn.data.exchangeData.Teacher = $("#txtTeacher").searchgrid("getValue");
                    UI.fn.data.exchangeData.Degree = $("#txtDegree").combobox("getValue");
                    UI.fn.data.exchangeData.Status = $("#txtStatus").combobox("getValue");
                    UI.fn.data.exchangeData.BeginTime = $("#txtBeginTime").datebox("getText");
                    UI.fn.data.exchangeData.EndTime = $("#txtEndTime").datebox("getText");
                    UI.fn.data.exchangeData.Type = 1;
                    var data = UI.fn.data.exchangeData;
                    if (data.Code == "") {
                        $.messager.alert("提示", "编码不能为空", "info");
                        return false;
                    }
                    if (data.Name == "") {
                        $.messager.alert("提示", "名称不能为空", "info");
                        return false;
                    }
                    if (data.Password == "") {
                        $.messager.alert("提示", "密码不能为空", "info");
                        return false;
                    }
                    if (data.SN == "") {
                        $.messager.alert("提示", "学号不能为空", "info");
                        return false;
                    }
                    if (data.Teacher <= 0) {
                        $.messager.alert("提示", "导师信息不能为空", "info");
                        return false;
                    }
                    if (data.Degree <= 0) {
                        $.messager.alert("提示", "学历信息不能为空", "info");
                        return false;
                    }
                    if (data.Status <= 0) {
                        $.messager.alert("提示", "身份信息不能为空", "info");
                        return false;
                    }

                    if (data.BeginTime <= 0) {
                        $.messager.alert("提示", "启用时间不能为空", "info");
                        return false;
                    }

                    if (data.EndTime <= 0) {
                        $.messager.alert("提示", "停用时间不能为空", "info");
                        return false;
                    }

                    return true;
                },
                dataBind: function (row) {
                    UI.fn.data.exchangeData = row;
                    $("#txtCode").val(row.Code);
                    $("#txtName").val(row.Name);
                    $("#txtPassword").val(row.Password);
                    $("#txtSN").val(row.SN);
                    $("#txtEmail").val(row.Email);
                    $("#txtTel").val(row.Tel);
                    $("#txtTeacher").searchgrid("setValue", row.Teacher);
                    $("#txtTeacher").searchgrid("setText", row.TeacherName);
                    $("#txtDegree").combobox("setValue", row.Degree);
                    $("#txtStatus").combobox("setValue", row.Status);
                    $("#txtBeginTime").datebox("setText", Util.DateTime.DateToStr(row.BeginTime, "yyyy-MM-dd"));
                    $("#txtEndTime").datebox("setText", Util.DateTime.DateToStr(row.EndTime, "yyyy-MM-dd"));
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
                            doActionAsync("THU.LabSystemBP.Agent.ModifyUserBPProxy", args, function (data) {
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
                            doActionAsync("THU.LabSystemBP.Agent.InsertUserBPProxy", args, function (data) {
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
                    $("#txtSN").val("");
                    $("#txtEmail").val("");
                    $("#txtTel").val("");
                    $("#txtTeacher").searchgrid("setValue", -1);
                    $("#txtTeacher").searchgrid("setText", "");
                    $("#txtDegree").combobox("setValue", "");
                    $("#txtDegree").combobox("setText", "");
                    $("#txtStatus").combobox("setValue", "");
                    $("#txtStatus").combobox("setText", "");
                    $("#txtBeginTime").datebox("setText", "");
                    $("#txtEndTime").datebox("setText", "");
                }
            },
            editForbitType: {
                isEdit: false,
                EditOK: function () {
                    if (UI.fn.forbitData.dataCollect()) {
                        var args = {};
                        if (UI.fn.editForbitType.isEdit && UI.fn.forbitData.exchangeData.ID > 0) {
                            //编辑
                            args.ForbitDTO = UI.fn.forbitData.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyForbitBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#forbitList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#forbitList").datagrid("refreshRow", $('#forbitList').datagrid('getRowIndex', row));
                                    UI.fn.editForbitType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.ForbitDTO = UI.fn.forbitData.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertForbitBPProxy", args, function (data) {
                                if (data) {
                                    $("#forbitList").datagrid('appendRow', data);
                                    UI.fn.editForbitType.EditCancel();
                                }
                            });

                        }
                    }
                },
                EditCancel: function () {
                    UI.fn.editForbitType.ClearEdit();
                    UI.fn.editForbitType.isEdit = false;
                    UI.fn.forbitData.exchangeData = {};
                    $("#editForbitForm").window("close");

                },
                ClearEdit: function () {
                    UI.fn.forbitData.exchangeData = {};
                    $("#txtForbitName").val("");

                    $("#txtForbitBeginTime").datebox("setText", "");
                    $("#txtForbitEndTime").datebox("setText", "");
                    $("#txtForbitBeginTime").datebox("setValue", "");
                    $("#txtForbitEndTime").datebox("setValue", "");
                }
            }
        }
    }
})(jQuery);

 