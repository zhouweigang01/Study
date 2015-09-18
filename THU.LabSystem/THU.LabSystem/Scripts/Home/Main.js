(function ($) {
    //动态菜单数据
    window.$PageGuid = "THU.LabSystem.Main";
    $(document).ready(function () {
        window.Main.fn.initPage();
        $(".pro_con ul li").click(function () {
            $(this).parent().find("li").removeClass("hover");
            $(this).addClass("hover");
            var target = $(this).attr("target");
            $(".lyz_tab_right>div").hide();
            $("#" + target).show();
            $("#" + target).children("div").layout("resize");
            $('#calendar').fullCalendar('render');

        });
        ///一分钟刷新一次
        setInterval(window.Main.data.reloadAll, 60 * 1000);

    });
    window.Main = {
        fn: {
            initPage: function () {
                $("#applyDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        if (row.IsCompleted) {
                            return "background-color:#aaa;";
                        }
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
                });

                $("#appointDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        if (row.IsUsing) {
                            return "background-color:#f00;color:#fff;";
                        }
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
                            { field: 'EndTime', title: '结束时间', align: 'center', width: 100, formatter: function (value, rowData, rowIndex) {
                                if (value) {
                                    return Util.DateTime.DateToStr(value, "yyyy-MM-dd hh:mm:ss");
                                } else {
                                    return "-";
                                }
                            }
                            }
                        ]]
                });

                $("#repairDeviceList").datagrid({
                    fitColumns: true,
                    singleSelect: true,
                    columns: [[
                            { field: 'UserName', title: '使用人', width: 100, align: 'center' },
                            { field: 'UserTel', title: '联系电话', width: 100, align: 'center' },
                            { field: 'DeviceSN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '所属房间', width: 100, align: 'center' },
                            { field: 'ReportMemo', title: '报修原因', width: 100, align: 'center' },
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
                args.PageSize = 20;
                args.PageIndex = 1;
                args.IsAppoint = false;
                Easyui.DataGrid.GetDataGridList("#applyDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy");
            },
            loadDeviceAppoint: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                args.IsAppoint = true;
                Easyui.DataGrid.GetDataGridList("#appointDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy");
            },
            loadDeviceRepair: function () {
                var args = {};
                args.PageSize = 20;
                args.PageIndex = 1;
                Easyui.DataGrid.GetDataGridList("#repairDeviceList", args, "THU.LabSystemBP.Agent.GetDeviceRepairRecordBPProxy");
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
                // CURSOR
                var chartCursor = new AmCharts.ChartCursor();
                chartCursor.cursorPosition = "mouse";
                chart.addChartCursor(chartCursor);
                // WRITE
                chart.write("chartdiv");

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
})(jQuery);
