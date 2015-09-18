(function ($) {
    //动态菜单数据
    window.$PageGuid = "THU.LabSystem.Console";
    $(document).ready(function () {
        var treeData = [

    {
        text: "我的工作台",
        children: [
            {
                text: "设备申请",
                iconCls: "icon-menu",
                attributes:
            {
                url: "/User/UserConsole/DeviceApply"
            }
            },
         {
             text: "设备预约",
             iconCls: "icon-menu",
             attributes:
            {
                url: "/User/UserConsole/DeviceAppoint"
            }
         }
        ]
    }

    ];

        //实例化树形菜单
        $("#tree").tree({
            data: treeData,
            lines: true,
            onClick: function (node) {
                if (node.attributes) {
                    Open(node.text, node.attributes.url);
                }
            }
        });

        //绑定tabs的右键菜单
        $("#tabs").tabs({
            onContextMenu: function (e, title) {
                e.preventDefault();
                $('#tabsMenu').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                }).data("tabTitle", title);
            }
        });

        //实例化menu的onClick事件
        $("#tabsMenu").menu({
            onClick: function (item) {
                CloseTab(this, item.name);
            }
        });
        $("#editPwd").dialog({
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
                    EditOK();
                }
            },
                {
                    iconCls: 'icon-cancel',
                    text: '取消',
                    handler: function () {
                        EditCancel();
                    }
                }]
        });
        $("#sysPassword").bind("click", function () {
            $("#editPwd").dialog('open');
        });


        $(".pro_con ul li").click(function () {
            $(this).parent().find("li").removeClass("hover");
            $(this).addClass("hover");
            var target = $(this).attr("target");
            $(".lyz_tab_right>div").hide();
            $("#" + target).show();
            $("#" + target).children("div").layout("resize");

        });
        Main.fn.initPage();

        ///一分钟刷新一次
        setInterval(window.Main.data.reloadAll, 60 * 1000);

        //  $("#con_one_1").children("div").layout("resize");

    });

    window.Main = {
        fn: {
            initPage: function () {
                $("#myApplyList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        var styler = "height:31px;";
                        if (row.IsCompleted) {
                            styler += "background-color:#aaa;";
                        } if (row.IsUsing) {
                            styler += "background-color:#f00;color:#fff;";
                        }
                        return styler;
                    },
                    frozenColumns: [[
                            { field: 'operator', title: '操作', width: 150, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var tpl = "";
                                if (rowData.IsCompleted) {
                                    tpl += "<a class=\"btn btn-disable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"><span>结束使用</span></a>";
                                    tpl += "<a class=\"btn btn-disable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"><span>设备报修</span></a>";
                                }
                                else {
                                    if (!rowData.IsAppoint) {
                                        tpl = "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"   onclick=\"Main.fn.applyDevice(this,1)\"><span>结束使用</span></a>";
                                    } else {
                                        tpl = "<a class=\"btn btn-disable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"><span>预约使用</span></a>";
                                    }
                                    tpl += "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"  onclick=\"Main.fn.applyDevice(this,2)\"><span>设备报修</span></a>";
                                }
                                return tpl;
                            }
                            }
                        ]],
                    columns: [[

                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'DeviceStatusName', title: '设备状态', width: 100, align: 'center' },
                            { field: 'DeviceUseStatusName', title: '使用状态', width: 100, align: 'center' },
                            { field: 'BeginTime', title: '开始时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'TotalHours', title: '使用时长(小时)', width: 100, align: 'center' },
                             { field: 'IsAppoint', title: '预约使用', width: 50, align: 'center', formatter: function (value, rowData, rowIndex) {
                                 if (value) {
                                     return "√";
                                 } else {
                                     return "-";
                                 }
                             }
                             }

                        ]]
                    //                        , toolbar: [
                    //                            {
                    //                                id: 'btnReload',
                    //                                iconCls: 'icon-reload',
                    //                                text: '刷新',
                    //                                handler: function () {
                    //                                    Main.data.loadMyApply();
                    //                                }
                    //                            }]
                });
                $("#myAppointList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        if (row.IsUsing == 1) {
                            return "background-color:#f00;color:#fff;";
                        } else {
                            return "background-color:#0f0;";
                        }
                    },
                    frozenColumns: [[
                             { field: 'operator', title: '操作', width: 160, align: 'center', formatter: function (value, rowData, rowIndex) {
                                 var tpl = "";
                                 if (rowData.CanAppoint) {
                                     tpl = "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"  onclick=\"Main.fn.appointDevice(this,1)\"><span>修改预约</span></a>";
                                     tpl += "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"  onclick=\"Main.fn.appointDevice(this,2)\"><span>取消预约</span></a>";
                                     return tpl;
                                 } else {
                                     tpl = "<a class=\"btn btn-disable\"><span>修改预约</span></a>";
                                     tpl += "<a class=\"btn btn-disable\"><span>取消预约</span></a>";
                                 }
                                 return tpl;
                             }
                             }
                        ]],
                    columns: [[

                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'DeviceStatusName', title: '设备状态', width: 100, align: 'center' },
                            { field: 'UseStatusName', title: '使用状态', width: 100, align: 'center' },
                            { field: 'BeginTime', title: '开始时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'EndTime', title: '结束时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'TotalHours', title: '使用时长(小时)', width: 100, align: 'center' }
                        ]]
                    //                        , toolbar: [
                    //                            {
                    //                                id: 'btnReload',
                    //                                iconCls: 'icon-reload',
                    //                                text: '刷新',
                    //                                handler: function () {
                    //                                    Main.data.loadMyAppoint();
                    //                                }
                    //                            }]
                });

                $("#myRepairList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        var styler = "height:31px;";
                        return styler;
                    },
                    frozenColumns: [[
                            { field: 'operator', title: '操作', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {

                                var tpl = "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"  onclick=\"Main.fn.alarmDevice(this)\"><span>不再提醒</span></a>";
                                return tpl;
                            }
                            }
                             ]],
                    columns: [[
                            { field: 'DeviceStatusName', title: '设备状态', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'ReportDate', title: '提交时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'RepairDate', title: '处理时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                             { field: 'CompleteDate', title: '完成时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                 if (value) {
                                     return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                 } else {
                                     return "-";
                                 }
                             }
                             }]]
                    //                    ,toolbar: [
                    //                            {
                    //                                id: 'btnReload',
                    //                                iconCls: 'icon-reload',
                    //                                text: '刷新',
                    //                                handler: function () {
                    //                                    Main.data.loadMyRepair();
                    //                                }
                    //                            }]
                });

                $("#repairForm").dialog({
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
                            var key = $("#txtKey").val();
                            var memo = $("#txtMemo").val();
                            doActionAsync("THU.LabSystemBP.Agent.ApplyRepairBPProxy", { ID: key, Memo: memo }, function (data) {
                                if (data) {
                                    Main.data.reloadAll();
                                    $("#repairForm").dialog("close");
                                }
                            });
                        }
                    },
                {
                    iconCls: 'icon-cancel',
                    text: '取消',
                    handler: function () {

                        $("#repairForm").dialog("close");
                    }
                }]
                });

                $("#appointForm").dialog({
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
                            var key = $("#txtAppointKey").val();
                            var beginStr = $('#txtStartTime').datebox("getText") + " " + $('#txtSTHour').combobox("getText") + ":" + $('#txtSTMinute').combobox("getText") + ":00";
                            var endStr = $('#txtEndTime').datebox("getText") + " " + $('#txtETHour').combobox("getText") + ":" + $('#txtETMinute').combobox("getText") + ":00";
                            var beginDate = new Date(beginStr.replace(/-/g, "/"));
                            var endDate = new Date(endStr.replace(/-/g, "/"));
                            if (beginDate >= endDate) {
                                $.messager.alert("提示", "预约设备的结束时间必须大于开始预约设备时间", "error");
                            } else {
                                doActionAsync("THU.LabSystemBP.Agent.AjustAppointBPProxy", { ID: key, BeginTime: beginStr, EndTime: endStr }, function (data) {
                                    if (data) {
                                        Main.data.reloadAll();
                                        $("#appointForm").dialog("close");
                                    }
                                });
                            }
                        }
                    },
                {
                    iconCls: 'icon-cancel',
                    text: '取消',
                    handler: function () {
                        $("#appointForm").dialog("close");
                    }
                }]
                });

                $('#txtStartTime,#txtEndime').datebox({
                    parser: dateparser,
                    formatter: dateformatter
                });

                Main.data.reloadAll();
            },
            applyDevice: function (obj, type) {
                var msg = "你确认";
                if (type == 1) {//结束使用
                    msg += "结束使用当前设备";
                }
                else {//设备保修
                    msg += "申请报修当前设备"
                }
                msg += "“" + $(obj).attr("txt") + "”?";
                if (type == 1) {
                    $.messager.confirm("提示", msg, function (r) {
                        if (r) {
                            var key = $(obj).attr("key");
                            doActionAsync("THU.LabSystemBP.Agent.UseCompleteBPProxy", { ID: key }, function (data) {
                                if (data) {
                                    Main.data.reloadAll();
                                }
                            });
                        }
                    });
                } else {
                    var key = $(obj).attr("key");
                    $("#txtKey").val(key);
                    $("#txtMemo").val("");
                    $("#repairForm").dialog("open");

                }
            },
            appointDevice: function (obj, type) {
                var msg = "你确认";
                if (type == 2) {//结束使用
                    msg += "取消当前设备";
                }
                else {//设备保修
                    msg += "修改当前设备"
                }
                msg += "“" + $(obj).attr("txt") + "”的预约记录?";
                if (type == 2) {
                    $.messager.confirm("提示", msg, function (r) {
                        if (r) {
                            var key = $(obj).attr("key");
                            doActionAsync("THU.LabSystemBP.Agent.DeleteAppointBPProxy", { ID: key }, function (data) {
                                if (data) {
                                    Main.data.reloadAll();
                                }
                            });
                        }
                    });
                } else {
                    var key = $(obj).attr("key");

                    var rows = $("#myAppointList").datagrid("getRows");
                    $.each(rows, function (i, item) {
                        if (item.ID == key) {
                            $("#txtAppointName").val(item.DeviceName);
                            $("#txtAppointKey").val(key);
                            var st = dateformatter(new Date(parseInt(item.BeginTime.replace("/Date(", "").replace(")/", ""))));
                            var et = dateformatter(new Date(parseInt(item.EndTime.replace("/Date(", "").replace(")/", ""))));
                            var stDate = new Date(parseInt(item.BeginTime.replace("/Date(", "").replace(")/", "")));
                            var etDate = new Date(parseInt(item.EndTime.replace("/Date(", "").replace(")/", "")));
                            var stHour = stDate.getHours();
                            var stMin = stDate.getMinutes();
                            var etHour = etDate.getHours();
                            var etMin = etDate.getMinutes();
                            $("#txtStartTime").datebox("setValue", st);
                            $("#txtEndTime").datebox("setValue", et);
                            $("#txtSTHour").combobox("setValue", stHour);
                            $("#txtETHour").combobox("setValue", etHour);
                            $("#txtSTMinute").combobox("setValue", stMin);
                            $("#txtETMinute").combobox("setValue", etMin);
                            $("#appointForm").dialog("open");
                        }
                    });



                }
            },
            alarmDevice: function (obj) {
                var key = $(obj).attr("key");
                if (key) {
                    doActionAsync("THU.LabSystemBP.Agent.ModifyRepairAlarmBPProxy", { ID: key, UserKey: 1 }, function (data) {
                        if (data) {
                            Main.data.loadMyRepair();
                        }
                    });
                }
            }
        },
        data: {
            reloadAll: function () {
                Main.data.loadMyApply();
                Main.data.loadMyAppoint();
                Main.data.loadMyRepair();
            },
            loadMyApply: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                args.IsAppoint = false;
                args.UserKey = 1;
                Easyui.DataGrid.GetDataGridList("#myApplyList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy", null, null, false);
            },
            loadMyAppoint: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                args.IsAppoint = true;
                args.UserKey = 1;
                Easyui.DataGrid.GetDataGridList("#myAppointList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy", null, null, false);
            },
            loadMyRepair: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                args.UserKey = 1;
                Easyui.DataGrid.GetDataGridList("#myRepairList", args, "THU.LabSystemBP.Agent.GetDeviceRepairRecordBPProxy", null, null, false);
            }
        }
    }
    function dateformatter(date) {
        if (date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();

            var str = y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
            return str;
        }
        return "";
    }
    function dateparser(s) {
        if (!s) return new Date();
        var y = s.substring(0, 4);
        var m = s.substring(5, 7);
        var d = s.substring(8, 10);
        if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
            return new Date(y, m - 1, d);
        } else {
            return new Date();
        }
    }

    //在右边center区域打开菜单，新增tab
    function Open(text, url) {
        if ($("#tabs").tabs('exists', text)) {
            $('#tabs').tabs('select', text);
        } else {
            $('#tabs').tabs('add', {
                title: text,
                closable: true,
                content: " <iframe style='width: 100%; height: 100%' frameborder='0' src='" + url + "'></iframe>"
            });
        }

    }

    //几个关闭事件的实现
    function CloseTab(menu, type) {
        var curTabTitle = $(menu).data("tabTitle");
        var tabs = $("#tabs");

        if (type === "close") {
            if (curTabTitle != "我的桌面") {
                tabs.tabs("close", curTabTitle);
            }
            return;
        }

        var allTabs = tabs.tabs("tabs");
        var closeTabsTitle = [];

        $.each(allTabs, function () {
            var opt = $(this).panel("options");
            if (opt.closable && opt.title != curTabTitle && type === "Other") {
                closeTabsTitle.push(opt.title);
            } else if (opt.closable && type === "All") {
                closeTabsTitle.push(opt.title);
            }
        });

        for (var i = 0; i < closeTabsTitle.length; i++) {
            tabs.tabs("close", closeTabsTitle[i]);
        }
    }
    function EditOK() {
        var oldPwd = $.trim($("#txtPwd").val());
        var newPwd = $.trim($("#txtNewPwd").val());
        var newPwd1 = $.trim($("#txtNewPwd1").val());
        if (newPwd != newPwd1) {
            $.messager.alert("错误提示", "两次输入的密码不一样", "error");
            return false;
        }
        var args = {};
        args.OPassword = oldPwd;
        args.Password = newPwd;
        doActionAsync("THU.LabSystemBP.Agent.ChangePasswordBPProxy", args, function (result) {
            if (result != undefined && result) {
                $.messager.alert("温馨提示", "密码修改成功", "info");
                $("#editPwd").dialog("close");
                Clear();
            }
        });
    }
    function EditCancel() {
        $("#editPwd").dialog("close");
        Clear();
    }
    function Clear() {
        $("#txtPwd").val("");
        $("#txtNewPwd").val("");
        $("#txtNewPwd1").val("");
    }
})(jQuery);
