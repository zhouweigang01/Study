(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.RepairReport";
        UI.fn.initPage();
        UI.fn.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#repairDeviceList").treegrid({
                    idField: 'id',
                    treeField: 'SN',
                    title: '维护记录',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'SN', title: '设备号', width: 100 }
                        ]],
                    columns: [[
                            { field: 'DeviceName', title: '设备名称', width: 100, align: "center" },
                            { field: 'HouseName', title: '房间号', width: 100, align: "center" },
                            { field: 'StartTime', title: '日期', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return value;
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'Fee', title: '费用', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value > 0) {
                                    return value;
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'Number', title: '维修次数', width: 50, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value > 0) {
                                    return value;
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'Memo', title: '报修原因', width: 150 },
                            { field: 'RepairMemo', title: '维修方式', width: 150 }
                        ]],
                    toolbar: [
                        "<span class=\"datagrid-toolbar-label\">开始时间</span> <input id=\"txtBeginTime\" type=\"text\" style=\"width: 120px\" /><span class=\"datagrid-toolbar-label\">结束时间</span> <input id=\"txtEndTime\" type=\"text\" style=\"width: 120px\" />",
                        {
                            id: 'btnExport',
                            iconCls: 'icon-search',
                            text: '查询',
                            handler: function () {
                                UI.fn.data.initData();
                            }
                        },
                         {
                             id: "btnDownload",
                             text: '导出',

                             iconCls: 'icon-download',
                             handler: function () {

                                 var st = $('#txtBeginTime').datebox("getText");
                                 var et = $('#txtEndTime').datebox("getText");
                                 var url = "/Admin/AdminConsole/ExportRepairFile/?start=" + st + "&end=" + et;
                                 window.open(url);
                             }
                         }
                        ],
                    onBeforeExpand: function (node) {
                        if (!node.attributes.hasExpand) {
                            node.attributes.hasExpand = true;
                            var args = {};
                            args.StartTime = $("#txtBeginTime").datebox("getText");
                            args.EndTime = $("#txtEndTime").datebox("getText");
                            args.DeviceKey = node.DeviceKey;
                            args.Level = 1;
                            doActionAsync("THU.LabSystemBP.Agent.GetDeviceRepairReportBPProxy", args, function (data) {
                                if (data.ListData) {
                                    $.each(data.ListData, function (i, item) {
                                        item.attributes = {};
                                        item.attributes.DeviceKey = this.Device;
                                        item.id = Util.Guid.New();
                                        item.iconCls = "icon-project";

                                    });
                                    Easyui.Tree.Append("#repairDeviceList", data.ListData, node, "treegrid");
                                }
                            });
                        }
                    }
                });

                $('#txtBeginTime,#txtEndTime').datebox({
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
                $('#txtEndTime').datebox("setValue", Util.DateTime.Formater("yyyy-MM-dd", new Date()));
                $('#txtBeginTime').datebox("setValue", Util.DateTime.Formater("yyyy-MM-dd", (new Date()).DateAdd("y", -1)));
            },
            data: {

                initData: function () {
                    var args = {};
                    args.PageIndex = 1;
                    args.PageSize = 20;
                    args.StartTime = $("#txtBeginTime").datebox("getText");
                    args.EndTime = $("#txtEndTime").datebox("getText");
                    Easyui.TreeGrid.GetTreeGridList("#repairDeviceList", "THU.LabSystemBP.Agent.GetDeviceRepairReportBPProxy", args, function () {
                        this.attributes = {};
                        this.attributes.DeviceKey = this.DeviceKey;
                        this.id = Util.Guid.New();
                        this.iconCls = "icon-merchant";
                        if (this.Number > 0) {
                            this.state = "closed";
                        }
                    }, null, null, null, true);


                }
            }
        }
    }
})(jQuery);

 