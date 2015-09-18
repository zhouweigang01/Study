(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.UseReport";
        UI.fn.initPage();
        UI.fn.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#useDeviceList").treegrid({
                    idField: 'id',
                    treeField: 'TeacherName',
                    title: '维护记录',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'TeacherName', title: '导师名称', width: 100 }
                        ]],
                    columns: [[
                            { field: 'StartTime', title: '开始时间', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'EndTime', title: '结束时间', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'Hours', title: '使用时间', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value > 0) {
                                    return value;
                                } else {
                                    return "-";
                                }
                            }
                            },
                            { field: 'Price', title: '单价', width: 100, align: "center", formatter: function (value, rowData, rowIndex) {
                                if (value > 0) {
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
                            { field: 'UserName', title: '使用人', width: 100, align: "center" },
                            { field: 'SN', title: '设备号', width: 100, align: "center" },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: "center" },
                            { field: 'HouseName', title: '房间号', width: 100, align: "center" }


                        ]],
                    toolbar: [
                        "<span class=\"datagrid-toolbar-label\">开始时间</span> <input id=\"txtBeginTime\" type=\"text\" style=\"width: 120px\" /><span class=\"datagrid-toolbar-label\">结束时间</span> <input id=\"txtEndTime\" type=\"text\" style=\"width: 120px\" />",
                        "<span class=\"datagrid-toolbar-label\">设备筛选</span><select id=\"txtSearchDevice\" style=\"width:120px\"></select>",
                        "-",
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
                                 var device = $('#txtSearchDevice').searchgrid("getValue");
                                 if (device == "") {
                                     device = -1;
                                 }
                                 var url = "/Admin/AdminConsole/ExportApplyFile/?start=" + st + "&end=" + et + "&device=" + device;
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
                            args.Level = 1;
                            args.TeacherKey = node.attributes.TeacherKey;
                            args.DeviceKey = $("#txtSearchDevice").searchgrid("getValue");
                            doActionAsync("THU.LabSystemBP.Agent.GetDeviceUseReportBPProxy", args, function (data) {
                                if (data.ListData) {
                                    $.each(data.ListData, function (i, item) {
                                        item.attributes = {};
                                        item.attributes.DeviceKey = this.Device;
                                        item.id = Util.Guid.New();
                                        item.iconCls = "icon-project";

                                    });
                                    Easyui.Tree.Append("#useDeviceList", data.ListData, node, "treegrid");
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

                $("#txtSearchDevice").searchgrid({
                    panelWidth: 430,
                    panelHeight: 220,
                    idField: 'ID',
                    textField: 'DeviceName',
                    columns: [[
                             { field: 'SN', title: '设备号', width: 100, align: 'center' },
                             { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                             { field: 'DeviceStatusName', title: '状态', width: 100, align: 'center' },
                             { field: 'HouseName', title: '房间号', width: 100, align: 'center' }
                    ]],
                    searchHandler: function (value) {
                        if (value != "") {
                            doActionAsync("THU.LabSystemBP.Agent.SearchDeviceMapListBPProxy", { AttrubuteList: ["SN", "Device.Name", "House.Name"], SearchTxt: value }, function (data) {
                                if (data) {
                                    $("#txtSearchDevice").searchgrid("loadData", data);

                                }
                            }, null, null, false);
                        } else {
                            $("#txtSearchDevice").searchgrid("hidePanel");
                        }
                    }
                });
            },
            data: {

                initData: function () {
                    var args = {};
                    args.PageIndex = 1;
                    args.PageSize = 20;
                    args.StartTime = $("#txtBeginTime").datebox("getText");
                    args.EndTime = $("#txtEndTime").datebox("getText");
                    args.DeviceKey = $("#txtSearchDevice").searchgrid("getValue");
                    Easyui.TreeGrid.GetTreeGridList("#useDeviceList", "THU.LabSystemBP.Agent.GetDeviceUseReportBPProxy", args, function () {
                        this.attributes = {};
                        this.attributes.TeacherKey = this.TeacherKey;
                        this.id = Util.Guid.New();
                        this.iconCls = "icon-merchant";
                        this.state = "closed";
                    }, null, null, null, true);


                }
            }
        }
    }
})(jQuery);

 