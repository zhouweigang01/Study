(function ($) {
    //动态菜单数据
    window.$PageGuid = "THU.LabSystem.Console";
    $(document).ready(function () {
        var treeData = [
    {
        text: "基础信息",
        children: [
        {
            text: "分类信息",
            iconCls: "icon-menu",
            attributes:
            {
                url: "/Admin/AdminConsole/CommonEnum"
            }
        }
        ]
    },
    {
        text: "人员维护",
        children: [
            {
                text: "导师信息",
                iconCls: "icon-menu",
                attributes:
            {
                url: "/Admin/AdminConsole/TeacherList"
            }
            },
         {
             text: "登录用户",
             iconCls: "icon-menu",
             attributes:
            {
                url: "/Admin/AdminConsole/UserList"
            }
         }
        ]
    }
    ,
    {
        text: "设备管理",
        children: [
         {
             text: "设备录入",
             iconCls: "icon-menu",
             attributes:
            {
                url: "/Admin/AdminConsole/DeviceList"
            }
         },
         {
             text: "设备预定",
             iconCls: "icon-menu",
             attributes:
            {
                url: "/Admin/AdminConsole/DeviceAppoint"
            }
         }
        ]
    },
    {
        text: "统计报表",
        children: [
         {
             text: "设备使用",
             iconCls: "icon-menu",
             attributes:
            {
                url: "/Admin/AdminConsole/UseDeviceReport"
            }
         },
          {
              text: "设备维护",
              iconCls: "icon-menu",
              attributes:
            {
                url: "/Admin/AdminConsole/RepairDeviceReport"
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
            $('#calendar').fullCalendar('render');

        });



        window.Main.fn.initPage();


        ///一分钟刷新一次
        setInterval(window.Main.data.reloadAll, 60 * 1000);

    });



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

    window.Main = {
        fn: {
            initPage: function () {
                $("#applyDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        var styler = "height:31px;";
                        if (row.IsCompleted) {
                            styler += "background-color:#aaa;";
                        }
                        return styler;
                    },
                    columns: [[
                            { field: 'UserName', title: '使用人', width: 100, align: 'center' },
                            { field: 'UserTel', title: '联系电话', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'BeginTime', title: '开始时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'TotalHours', title: '使用时长(小时)', width: 100, align: 'center' },
                            { field: 'DeviceUseStatusName', title: '使用状态', width: 100, align: 'center' },
                             { field: 'IsAppoint', title: '预约使用', width: 50, align: 'center', formatter: function (value, rowData, rowIndex) {
                                 if (value) {
                                     return "√";
                                 } else {
                                     return "-";
                                 }
                             }
                             }
                        ]]
                    //                        ,
                    //                    toolbar: [
                    //                        {
                    //                            id: 'btnReload',
                    //                            iconCls: 'icon-reload',
                    //                            text: '刷新',
                    //                            handler: function () {
                    //                                Main.data.loadDeviceApply();
                    //                            }
                    //                        }]
                });

                $("#appointDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        if (row.IsUsing) {
                            return "background-color:#f00;color:#fff;";
                        }
                    },
                    frozenColumns: [[
                            { field: 'operator', title: '操作', width: 160, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var tpl = "";
                                if (!rowData.IsCompleted) {
                                    tpl = "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"";
                                    tpl += " onclick=\"Main.fn.appointDevice(this,1)\"><span>修改预约";
                                    tpl += "</span></a>";

                                    tpl += "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"";
                                    tpl += " onclick=\"Main.fn.appointDevice(this,2)\"><span>删除预约";
                                    tpl += "</span></a>";
                                } else {
                                    tpl = "-";
                                }

                                return tpl;
                            }
                            }
                             ]],
                    columns: [[
                            { field: 'UserName', title: '使用人', width: 100, align: 'center' },
                            { field: 'UserTel', title: '联系电话', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
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
                            }
                    //,
                    //                             { field: 'IsCompleted', title: '已完成', width: 50, align: 'center', formatter: function (value, rowData, rowIndex) {
                    //                                 if (value) {
                    //                                     return "√";
                    //                                 } else {
                    //                                     return "-";
                    //                                 }
                    //                             }
                    //                             }
                        ]]
                    //                        ,
                    //                    toolbar: [
                    //                        {
                    //                            id: 'btnReload',
                    //                            iconCls: 'icon-reload',
                    //                            text: '刷新',
                    //                            handler: function () {
                    //                                Main.data.loadDeviceAppoint();
                    //                            }
                    //                        }]
                });

                $("#repairDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        var styler = "height:31px;";
                        return styler;
                    },
                    frozenColumns: [[
                            { field: 'operator', title: '操作', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {
                                var tpl = "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"";
                                if (!rowData.RepairDate) {
                                    tpl += " onclick=\"Main.fn.repairDevice(this)\"><span>处理报修";
                                } else if (!rowData.CompleteDate) {
                                    tpl += " onclick=\"Main.fn.repairDevice(this)\"><span>完成维修";
                                } else {
                                    tpl = "<a class=\"btn btn-disable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\"";
                                    tpl += "><span>维修完成";
                                }
                                tpl += "</span></a>";
                                return tpl;
                            }
                            }
                             ]],
                    columns: [[
                            { field: 'UserName', title: '使用人', width: 100, align: 'center' },
                            { field: 'UserTel', title: '联系电话', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'ReportMemo', title: '报修原因', width: 100, align: 'center' },
                            { field: 'Fee', title: '维修费用', width: 100, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (!value) {
                                    return "-";
                                }
                                return value;
                            }
                            },
                            { field: 'RepairMemo', title: '维修方式', width: 100, align: 'center' },
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
                             }
                        ]]
                    //                        ,
                    //                    toolbar: [
                    //                        {
                    //                            id: 'btnReload',
                    //                            iconCls: 'icon-reload',
                    //                            text: '刷新',
                    //                            handler: function () {
                    //                                Main.data.loadDeviceRepair();
                    //                            }
                    //                        }]
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
                            var fee = $("#txtFee").numberbox("getValue");
                            var memo = $("#txtMemo").val();
                            doActionAsync("THU.LabSystemBP.Agent.RepairCompleteBPProxy", { ID: key, Fee: fee, Memo: memo }, function (data) {
                                if (data) {
                                    Main.data.loadDeviceRepair();
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
                $("#viewAppointForm").dialog({
                    closed: true,
                    modal: true,
                    autoRowHeight: false,
                    striped: true,
                    remoteSort: false,
                    singleSelect: true,
                    buttons: [
                    {
                        iconCls: 'icon-cancel',
                        text: '关闭',
                        handler: function () {

                            $("#viewAppointForm").dialog("close");
                        }
                    }]
                });
                $("#viewAppointList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    border: false,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'UserName', title: '使用人', width: 100, align: 'center' },
                            { field: 'UserTel', title: '联系电话', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'BeginTime', title: '开始时间', align: 'center', width: 150, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'EndTime', title: '结束时间', align: 'center', width: 150, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                             { field: 'IsCompleted', title: '已完成', width: 50, align: 'center', formatter: function (value, rowData, rowIndex) {
                                 if (value) {
                                     return "√";
                                 } else {
                                     return "-";
                                 }
                             }
                             }
                        ]]

                });

                window.Main.data.reloadAll();

                var dateStr = Util.DateTime.Formater("yyyy-MM-dd", new Date());
                $('#calendar').fullCalendar({
                    header: {
                        left: 'prev,next today',
                        center: 'title',
                        right: 'month'
                    },
                    defaultDate: dateStr,
                    editable: false,
                    selectable: true,
                    lang: "zh-cn",
                    eventLimit: true,
                    height: 350,
                    eventRender: function (event, element, view) {
                        //                        element.qtip({
                        //                            content: {
                        //                                text: event.desc
                        //                            },
                        //                            position: {
                        //                                at: 'bottom left'
                        //                            },
                        //                            style: { width: '500', name: 'blue' }
                        //                        });
                        element.css("cursor", "pointer");
                        if (event.IsCompleted) {
                            element.css("background", "#aaa");
                            element.css("color", "#fff");
                        }
                        else {
                            if (event.IsUsing) {
                                element.css("background", "#f00");
                                element.css("color", "#000");
                            }
                            else {
                                element.css("background", "#0f0");
                                element.css("color", "#000");
                            }

                        }

                    },
                    viewRender: function (view) {//动态把数据查出，按照月份动态查询
                        window.Main.data.loadCalendar();
                    },
                    eventClick: function (event, jsEvent, view) {
                        $("#viewAppointList").datagrid("loadData", event.ListData);
                        $("#viewAppointForm").dialog("open");
                    }
                });
                //window.Main.data.loadCalendar();
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

                    var rows = $("#appointDeviceList").datagrid("getRows");
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
            repairDevice: function (obj) {
                var key = $(obj).attr("key");
                var rows = $("#repairDeviceList").datagrid("getRows");
                var row = null;
                $.each(rows, function (i, item) {
                    if (item.ID == key) {
                        row = item;
                        return false;
                    }
                });
                if (row) {
                    if (row.RepairDate) {
                        $("#txtKey").val(row.ID);
                        $("#txtFee").numberbox("setValue", 0);
                        $("#txtMemo").val("");
                        $("#repairForm").dialog("open");

                    } else {
                        $.messager.confirm("提示", "确认开始维修当前设备“" + row.DeviceName + "”？", function (r) {
                            if (r) {
                                doActionAsync("THU.LabSystemBP.Agent.HandleRepairBPProxy", { ID: row.ID }, function (r) {
                                    if (r) {
                                        Main.data.loadDeviceRepair();
                                    }
                                });
                            }
                        });
                    }
                }
            }
        },
        data: {
            reloadAll: function () {
                Main.data.loadDeviceApply();
                Main.data.loadDeviceAppoint();
                Main.data.loadDeviceRepair();
                Main.data.loadDiagram();
            },
            loadDeviceApply: function () {
                var args = {};
                args.PageSize = 10;
                args.PageIndex = 1;
                args.IsAppoint = false;
                Easyui.DataGrid.GetDataGridList("#applyDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy", null, null, false);
            },
            loadDeviceAppoint: function () {
                var args = {};
                args.PageSize = 10;
                args.PageIndex = 1;
                args.IsAppoint = true;
                Easyui.DataGrid.GetDataGridList("#appointDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy", null, null, false);
            },
            loadDeviceRepair: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                Easyui.DataGrid.GetDataGridList("#repairDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceRepairRecordBPProxy", null, null, false);
            },
            loadCalendar: function () {
                var date = $('#calendar').fullCalendar('getDate');
                var args = {};
                args.Year = date.year();
                args.Month = date.month() + 1;
                args.IsAppoint = true;
                doActionAsync("THU.LabSystemBP.Agent.LoadDeviceUseDiagramBPProxy", args, function (data) {
                    var now = new Date();
                    now = new Date(now.getFullYear(), now.getMonth(), now.getDate());
                    $.each(data, function (i, item) {
                        var nowDate = dateparser(item.Date)

                        //看看有没有正在使用的
                        $.each(item.ListData, function (j, task) {
                            if (task.IsUsing) {
                                item.IsUsing = true;
                                return false;
                            }
                        });
                        ///没有正在使用的看看有没有完成的
                        if (!item.IsUsing) {
                            item.IsCompleted = true;
                            $.each(item.ListData, function (j, task) {
                                if (!task.IsCompleted) {
                                    item.IsCompleted = false;
                                    return false;
                                }
                            });
                        }

                        item.start = dateformatter(nowDate); //item.Date;
                        item.title = item.ListData.length + "个预约";
                        item.desc = "<table class='tooltip-table' width=\"300\">";

                    });
                    $('#calendar').fullCalendar('removeEvents');
                    $('#calendar').fullCalendar('addEventSource', data);
                });
            },
            loadDiagram: function () {
                var date = new Date();
                var args = {};
                args.Year = date.getFullYear();
                args.Month = date.getMonth() + 1;
                args.IsAppoint = false;
                doActionAsync("THU.LabSystemBP.Agent.LoadDeviceUseDiagramBPProxy", args, function (data) {
                    $.each(data, function (i, item) {
                        item.Categroy = item.Date.substring(5, 10);
                    });
                    window.Main.data.buildLine(data);
                }, null, null, false);
            },
            buildLine: function (data) {
                var chart;
                chart = new AmCharts.AmSerialChart();
                chart.dataProvider = data;
                chart.categoryField = "Categroy";
                chart.startDuration = 0.5;
                chart.pathToImages = "/Content/amcharts/";
                chart.balloon.color = "#fff";
                chart.color = "#000";
                //横坐标
                var categoryAxis = chart.categoryAxis;
                categoryAxis.gridAlpha = 0;
                categoryAxis.axisAlpha = 0.7;
                categoryAxis.axisColor = "#868686";
                categoryAxis.gridPosition = "start";
                categoryAxis.position = "bottom";
                categoryAxis.labelRotation = 45;
                categoryAxis.titleColor = "#f00";
                // value
                var valueAxis1 = new AmCharts.ValueAxis();
                valueAxis1.title = "时间(小时)";
                valueAxis1.dashLength = 5;
                valueAxis1.axisAlpha = 0.7;
                //valueAxis1.integersOnly = true;
                valueAxis1.gridCount = 5;
                valueAxis1.axisColor = "#868686"; //坐标的颜色
                //valueAxis1.reversed = false; // this line makes the value axis reversed
                chart.addValueAxis(valueAxis1);

                var valueAxis2 = new AmCharts.ValueAxis();
                valueAxis2.title = "费用(元)";
                valueAxis2.dashLength = 5;
                valueAxis2.position = "right";
                valueAxis2.axisColor = "#868686";
                chart.addValueAxis(valueAxis2);

                var graph1 = new AmCharts.AmGraph();
                graph1.valueField = "TotalHours";
                graph1.valueAxis = valueAxis1;
                graph1.title = "使用时间";
                graph1.balloonText = "总时间: [[value]]小时";
                graph1.balloonColor = "#4bb3d2";
                graph1.lineAlpha = 1;
                graph1.lineColor = "#21c7fb";
                graph1.bullet = "round";
                graph1.lineThickness = 2;
                graph1.bulletBorderThickness = 8;

                // indicate which field should be used for bullet size
                graph1.bulletBorderColor = "#4bb3d2";
                graph1.bulletBorderAlpha = 0.15;
                graph1.bulletColor = "#4bb3d2";
                graph1.bulletAlpha = 0.7;
                graph1.labelPosition = "right";
                graph1.showBalloon = true;
                graph1.type = "smoothedLine";
                graph1.color = "#fff";

                chart.addGraph(graph1);


                var graph2 = new AmCharts.AmGraph();
                graph2.valueField = "TotalFee";
                graph2.valueAxis = valueAxis2;
                graph2.title = "使用费用";
                graph2.balloonText = "总费用: [[value]]元";
                graph2.balloonColor = "#0f0";
                graph2.lineAlpha = 1;
                graph2.lineColor = "#0f0";
                graph2.bullet = "round";

                graph2.lineThickness = 2;
                graph2.bulletBorderThickness = 8;

                // indicate which field should be used for bullet size
                graph2.bulletBorderColor = "#0f0";
                graph2.bulletBorderAlpha = 0.15;
                graph2.bulletColor = "#FF9966";
                graph2.bulletAlpha = 0.7;
                graph2.labelPosition = "right";
                graph2.showBalloon = true;
                graph2.type = "smoothedLine";
                graph2.color = "#fff";
                chart.addGraph(graph2);
                // CURSOR
                var chartCursor = new AmCharts.ChartCursor();
                chartCursor.cursorPosition = "mouse";
                chart.addChartCursor(chartCursor);
                // WRITE
                chart.write("chartdiv");

            }
        }
    };

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

})(jQuery);
