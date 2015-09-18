(function ($) {
    window.$PageGuid = "THU.LabSystem.User.DeviceAppoint";
    var DeviceMapData = null;
    $(document).ready(function () {

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
                displayMsg();
                $('#calendar').fullCalendar('removeEvents');
                $('#calendar').fullCalendar('refetchEvents');
            },
            onClickRow: function (rowIndex, rowData) {
                displayMsg(rowData);
                refreshCalendar(rowData.ID);
            }
        });
        function displayMsg(data) {

            if (data) {
                DeviceMapData = data;
                $("#txtSN").html(data.SN);
                $("#txtName").html(data.DeviceName);
                $("#txtStatus").html(data.DeviceStatusName);
                $("#txtType").html(data.DeviceTypeName);
                $("#txtHouse").html(data.HouseName);
            } else {
                DeviceMapData = null;
                $("#txtSN").html("");
                $("#txtName").html("");
                $("#txtStatus").html("");
                $("#txtType").html("");
                $("#txtHouse").html("");
            }
        }
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
            eventLimit: true, // allow "more" link when too many events
            dayClick: function (date, jsEvent, view) {
                if (DeviceMapData != null) {
                    $('#txtStartTime,#txtEndTime').datebox("setValue", dateformatter(date.toDate()));
                    $("#txtSTHour,#txtETHour,#txtSTMinute,#txtETMinute").combobox("setValue", 0);
                    $("#txtDeviceName").val($("#txtName").html());
                    if (DeviceMapData.DeviceStatus != 1) {
                        if (DeviceMapData.DeviceStatus == 4) {
                            $.messager.alert("提示", "当前设备状态为“" + DeviceMapData.DeviceStatusName + "”，无法预约当前设备！", "error");
                        }
                        else {
                            $.messager.confirm("提示", "当前设备状态为“" + DeviceMapData.DeviceStatusName + "”，你确认要预约当前设备么?", function (r) {
                                if (r) {
                                    $("#appointForm").dialog("open");
                                }
                            });
                        }
                    } else {
                        $("#appointForm").dialog("open");
                    }
                }
                else {
                    $.messager.alert("提示", "请选择你需要预约的设备", "info");
                }

            },
            eventRender: function (event, element, view) {
                element.qtip({
                    content: {
                        text: event.desc
                    },
                    position: {
                        // target: "mouse",
                        at: 'bottom right'
                    }
                });
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
                var deviceKey = $("#txtSelectDevice").combogrid("getValue");
                if (deviceKey <= 0) {
                    deviceKey = $("#txtSearchDevice").searchgrid("getValue");
                }
                refreshCalendar(deviceKey);
            }
        });

        $('#txtStartTime,#txtEndTime').datebox({
            parser: dateparser,
            formatter: dateformatter
        });
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
        function refreshCalendar(deviceKey) {
            if (!deviceKey) {
                $('#calendar').fullCalendar('removeEvents');
            } else {
                var dateStr = $('#calendar').fullCalendar('getDate').format();
                var args = {};
                args.DeviceKey = deviceKey;
                args.Date = dateStr;
                doActionAsync("THU.LabSystemBP.Agent.LoadDeviceMapRecordListBPProxy", args, function (data) {
                    $.each(data, function (i, item) {
                        formatDeviceMapRecord.call(item);
                    });
                    $('#calendar').fullCalendar('removeEvents');
                    $('#calendar').fullCalendar('addEventSource', data);
                }, null, null, false);
            }
        }
        function formatDeviceMapRecord() {
            var btStr = this.BeginDateStr.substring(0, 10);
            var etStr = this.EndDateStr.substring(0, 10);
            if (btStr == etStr) {
                this.title = this.UserName + "(" + this.BeginDateStr.substring(11, 16) + "-" + this.EndDateStr.substring(11, 16) + ")";
            } else {
                this.title = this.UserName + "(" + this.BeginDateStr.substring(5, 16) + "-" + this.EndDateStr.substring(5, 16) + ")";
            }
            this.start = this.BeginDateStr;
            this.end = this.EndDateStr;
            this.allDay = true;
            this.desc = "";
            this.desc += "<div class='qtip-content'><span style='display:inline-block;width:60px;text-align:right;'>使用者：</span><span style='font-weight:bold;'>" + this.UserName + "</span></div>";
            this.desc += "<div class='qtip-content'><span style='display:inline-block;width:60px;text-align:right;'>开始时间：</span><span style='font-weight:bold;'>" + Util.DateTime.DateToStr(this.BeginTime, "yyyy-MM-dd hh:mm:ss") + "</span></div>";
            if (this.end) {
                this.desc += "<div class='qtip-content'><span style='display:inline-block;width:60px;text-align:right;'>结束时间：</span><span style='font-weight:bold;'>" + Util.DateTime.DateToStr(this.EndTime, "yyyy-MM-dd hh:mm:ss") + "</span></div>";
            }
            if (this.IsAppoint) {
                this.desc += "<div class='qtip-content'><span style='display:inline-block;width:60px;text-align:right;'>使用方式：</span><span style='font-weight:bold;'>预约使用</span></div>";
            }
            this.desc += "<div class='qtip-content'><span style='display:inline-block;width:60px;text-align:right;'>联系方式：</span><span style='font-weight:bold;'>" + this.UserTel + "</span></div>";
        }
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
                    var beginStr = $('#txtStartTime').datebox("getText") + " " + $('#txtSTHour').combobox("getText") + ":" + $('#txtSTMinute').combobox("getText") + ":00";
                    var endStr = $('#txtEndTime').datebox("getText") + " " + $('#txtETHour').combobox("getText") + ":" + $('#txtETMinute').combobox("getText") + ":00";
                    var beginDate = new Date(beginStr.replace(/-/g, "/"));
                    var endDate = new Date(endStr.replace(/-/g, "/"));
                    if (beginDate >= endDate) {
                        $.messager.alert("提示", "预约设备的结束时间必须大于开始预约设备时间", "error");
                    } else {
                        $.messager.confirm("确认", "确认预约从“" + beginStr + "”到“" + endStr + "”时间段的设备", function (r) {
                            if (r) {
                                var args = {};
                                args.ID = DeviceMapData.ID;
                                args.BeginTime = beginStr;
                                args.EndTime = endStr;
                                doActionAsync("THU.LabSystemBP.Agent.AppointDeviceBPProxy", args, function (data) {
                                    if (data) {
                                        formatDeviceMapRecord.call(data);
                                    }

                                    $('#calendar').fullCalendar('renderEvent', data, true);
                                    $("#appointForm").dialog("close");
                                });
                            } else {
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


        $(".pro_con ul li").click(function () {
            $(this).parent().find("li").removeClass("hover");
            $(this).addClass("hover");
            var target = $(this).attr("target");
            $(".lyz_tab_right>div").hide();
            $("#" + target).show();

            $("#txtSelectHouse").combobox("setValue", -1);
            $("#txtSelectHouse").combobox("setText", "");

            $("#txtSelectDevice").combogrid("setValue", -1);
            $("#txtSelectDevice").combogrid("setText", "");

            $("#txtSearchDevice").searchgrid("setValue", -1);
            $("#txtSearchDevice").searchgrid("setText", "");

            displayMsg();
            refreshCalendar();

        });
        $("#txtSelectHouse").combobox({
            panelWidth: 250,
            panelHeight: 160,
            valueField: 'ID',
            textField: 'Name',
            onSelect: function (rowData) {
                $("#txtSelectDevice").combogrid("setValue", -1);
                $("#txtSelectDevice").combogrid("setText", "");
                displayMsg();
                refreshCalendar();
                doActionAsync("THU.LabSystemBP.Agent.GetDeviceMapByHouseBPProxy", { HouseKey: rowData.ID }, function (data) {
                    if (data) {
                        $("#txtSelectDevice").combogrid("grid").datagrid("loadData", data);
                    }
                }, null, null, false);
            }
        });

        $("#txtSelectDevice").combogrid({
            panelWidth: 320,
            panelHeight: 220,
            idField: 'ID',
            textField: 'DeviceName',
            columns: [[
                             { field: 'SN', title: '设备号', width: 100, align: 'center' },
                             { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                             { field: 'DeviceStatusName', title: '状态', width: 100, align: 'center' }
                    ]],
            onClickRow: function (rowIndex, rowData) {
                displayMsg(rowData);
                refreshCalendar(rowData.ID);
            }
        });

        doActionAsync("THU.LabSystemBP.Agent.GetEnumListBPProxy", { Type: 5 }, function (data) {
            if (data) {
                $("#txtSelectHouse").combobox("loadData", data);
            }
        }, null, null, false);


    });
})(jQuery);