(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.DeviceApply";
        UI.fn.initPage();
        UI.data.initData();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#deviceList").datagrid({
                    title: '设备列表',
                    fitColumns: true,
                    singleSelect: true,
                    rowStyler: function (index, row) {
                        if (!row.CanUse) {
                            return "background:#f00;color:#fff;";
                        } else {
                            //使用中
                            if (row.UseStatus == 1) {
                                return "background:#0ff;";
                            }
                        }
                    },
                    frozenColumns: [[
                            { field: 'operator', title: '操作', width: 80, align: 'center', formatter: function (value, rowData, rowIndex) {
                                if (rowData.CanUse) {
                                    return "<a class=\"btn btn-enable\" key=\"" + rowData.ID + "\" txt=\"" + rowData.DeviceName + "\" onclick=\"UI.fn.applyDevice(this)\"><span>申请使用</span></a>";
                                } else {
                                    return "<a class=\"btn btn-disable\"><span>无法申请</span></a>";
                                }
                            }
                            }
                        ]],
                    columns: [[

                            { field: 'SN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'HouseName', title: '设备名称', width: 100, align: 'center' },
                            { field: 'DeviceStatusName', title: '设备状态', width: 100, align: 'center' },
                            { field: 'UseStatusName', title: '使用状态', width: 100, align: 'center' }

                        ]],
                    toolbar: [
                        {
                            id: 'btnReload',
                            iconCls: 'icon-reload',
                            text: '刷新',
                            handler: function () {
                                $("#txtSelectHouse").combobox("setValue", -1);
                                $("#txtSelectHouse").combobox("setText", "");
                                UI.data.initData();
                            }
                        },
                        "|",
                        "<span class=\"datagrid-toolbar-label\">房间号</span><select id=\"txtSelectHouse\" style=\"width:120px\"></select>"
                        ]

                });

                $("#txtSelectHouse").combobox({
                    panelWidth: 250,
                    panelHeight: 160,
                    valueField: 'ID',
                    textField: 'Name',
                    onSelect: function (rowData) {
                        doActionAsync("THU.LabSystemBP.Agent.GetDeviceMapByHouseBPProxy", { HouseKey: rowData.ID }, function (data) {
                            if (data) {
                                $("#deviceList").datagrid("loadData", data);
                            }
                        }, null, null, false);
                    }
                });
                doActionAsync("THU.LabSystemBP.Agent.GetEnumListBPProxy", { Type: 5 }, function (data) {
                    if (data) {
                        $("#txtSelectHouse").combobox("loadData", data);
                    }
                }, null, null, false);
            },
            applyDevice: function (obj) {
                var key = $(obj).attr("key");
                var txt = $(obj).attr("txt");
                $.messager.confirm("提示", "确认申请使用当前设备“" + txt + "”么?", function (r) {
                    if (r) {
                        doActionAsync("THU.LabSystemBP.Agent.ApplyDeviceBPProxy", { ID: key }, function (data) {
                            if (data) {
                                $.messager.alert("提示", "设备申请使用成功", "info");
                                UI.data.initData();
                            }
                        }, null, null, false);
                    }
                });
            }
        },
        data: {
            initData: function () {

                var args = {};
                args.PageIndex = 1;
                args.PageSize = 20;
                // args.UseStatus = 2;
                // args.DeviceStatus = 1;
                Easyui.DataGrid.GetDataGridList("#deviceList", args, "THU.LabSystemBP.Agent.GetAllDeviceMapBPProxy");
            }
        }
    }

})(jQuery);

 