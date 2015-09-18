(function ($) {
    $(document).ready(function () {
        window.$PageGuid = "THU.LabSystem.DeviceList";

        UI.fn.initPage();
        UI.fn.data.initData();
        UI.fn.mapData.loadCombo();
    });

    UI = {
        fn: {
            initPage: function () {
                $("#deviceList").datagrid({
                    // title: '设备类别',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[

                            { field: 'Name', title: '名称', width: 100, align: 'center' },
                            { field: 'TypeName', title: '类型', width: 100, align: 'center' },
                            { field: 'Price', title: '单价', width: 100, align: 'center' },
                            { field: 'Expression', title: '计费公式', width: 100, align: 'center' }

                        ]]
                        , toolbar: [
                            {
                                id: 'btnAdd',
                                text: '新增',
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editType.ClearEdit();
                                    $("#editForm").dialog({ title: '新增设备信息' }).dialog("open");
                                }

                            }, {
                                id: 'btnEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#deviceList").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editType.isEdit = true;
                                        UI.fn.editType.ClearEdit();
                                        UI.fn.data.dataBind(row);
                                        $("#editForm").dialog({ title: '编辑设备信息' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除当前设备信息？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#deviceList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteDeviceBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#deviceList').datagrid('deleteRow', $('#deviceList').datagrid('getRowIndex', rowData));
                                                    $("#btnEdit").linkbutton({ disabled: true });
                                                    $("#btnDelete").linkbutton({ disabled: true });
                                                    UI.fn.mapData.loadCombo();
                                                }
                                            });

                                        } else {
                                            $.messager.alert("温馨提示", "请选择要删除的类别信息", "error");
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
                                UI.fn.mapData.loadCombo();
                            }
                        },
                        '|',
                        "<span class=\"datagrid-toolbar-label\">设备类型</span><select id=\"txtDeviceType\" style=\"width:60px\"><option value=\"-1\" selected=\"selected\">全部</option><option value=\"1\">单用户</option><option value=\"2\">多用户</option></select>",
                        "<span class=\"datagrid-toolbar-label\">搜索</span><select id=\"txtSearchDevice\" style=\"width:120px\"></select>"
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnEdit").linkbutton({ disabled: false });
                        $("#btnDelete").linkbutton({ disabled: false });
                        $("#btnMapAdd").linkbutton({ disabled: false });
                        UI.fn.mapData.initData(rowData.ID);
                    }
                });
                $("#deviceMapList").datagrid({
                    //  title: '实验室设备',
                    fitColumns: true,
                    singleSelect: true,
                    frozenColumns: [[
                            { field: 'ck', checkbox: true }
                        ]],
                    columns: [[
                            { field: 'HouseName', title: '房间号', width: 100, align: 'center' },
                            { field: 'DeviceName', title: '设备名称', width: 150, align: 'center' },
                            { field: 'SN', title: '设备号', width: 100, align: 'center' },
                            { field: 'DeviceStatusName', title: '设备状态', width: 100, align: 'center' },
                            { field: 'UseStatusName', title: '使用状态', width: 100, align: 'center' },
                            { field: 'Price', title: '单价', width: 100, align: 'center' },
                            { field: 'Expression', title: '计费公式', width: 100, align: 'center' }

                        ]],
                    toolbar: [
                            {
                                id: 'btnMapAdd',
                                text: '新增',
                                iconCls: 'icon-add',
                                handler: function () {
                                    UI.fn.editMapType.isEdit = false;
                                    UI.fn.editMapType.ClearEdit();
                                    UI.fn.mapData.dataBind();
                                    $("#editMapForm").dialog({ title: '新增实验室设备信息' }).dialog("open");
                                }

                            }, {
                                id: 'btnMapEdit',
                                text: '编辑',
                                disabled: true,
                                iconCls: 'icon-edit',
                                handler: function () {
                                    var row = $("#deviceMapList").datagrid("getSelected");
                                    if (row) {
                                        UI.fn.editMapType.isEdit = true;
                                        UI.fn.editMapType.ClearEdit();
                                        UI.fn.mapData.dataBind(row);
                                        $("#editMapForm").dialog({ title: '编辑实验室设备信息' }).dialog("open");
                                    }
                                }

                            },
                        {
                            id: 'btnMapDelete',
                            text: '删除',
                            disabled: true,
                            iconCls: 'icon-remove',
                            handler: function () {
                                $.messager.confirm("温馨提示：", "确认删除实验室设备信息？", function (judge) {
                                    if (!judge) { return false; } else {
                                        var rowData = $("#deviceMapList").datagrid("getSelected");
                                        if (rowData) {
                                            var args = {};
                                            args.ID = rowData.ID;
                                            doActionAsync("THU.LabSystemBP.Agent.DeleteDeviceMapBPProxy", args, function (del) {
                                                if (del != undefined && del) {
                                                    $('#deviceMapList').datagrid('deleteRow', $('#deviceMapList').datagrid('getRowIndex', rowData));
                                                    $("#btnMapEdit").linkbutton({ disabled: true });
                                                    $("#btnMapDelete").linkbutton({ disabled: true });
                                                }
                                            });

                                        } else {
                                            $.messager.alert("温馨提示", "请选择要删除的实验室设备信息", "error");
                                            return false;
                                        }
                                    }
                                });
                            }
                        },
                           {
                               id: 'btnOperator',
                               text: '操作',
                               iconCls: 'icon-list',
                               type: 'menubutton',
                               menu: '#mm1'
                           }
                        ],
                    onSelect: function (rowIndex, rowData) {
                        $("#btnMapEdit").linkbutton({ disabled: false });
                        $("#btnMapDelete").linkbutton({ disabled: false });
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

                $("#editMapForm").dialog({
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
                            UI.fn.editMapType.EditOK();
                        }
                    },
                    {
                        iconCls: 'icon-cancel',
                        text: '取消',
                        handler: function () {
                            UI.fn.editMapType.EditCancel();
                        }
                    }]
                });

                $("#txtSearchDevice").searchgrid({
                    panelWidth: 330,
                    panelHeight: 200,
                    idField: 'ID',
                    textField: 'Name',
                    columns: [[
                             { field: 'Name', title: '名称', width: 200, align: 'center' },
                             { field: 'TypeName', title: '类型', width: 100, align: 'center' }
                    ]],
                    searchHandler: function (value) {
                        if (value != "") {
                            doActionAsync("THU.LabSystemBP.Agent.SearchDeviceListBPProxy", { AttrubuteList: ["Name", "Tag"], SearchTxt: value }, function (data) {
                                if (data) {
                                    $("#txtSearchDevice").searchgrid("loadData", data);

                                }
                            }, null, null, false);
                        } else {
                            $("#txtSearchDevice").searchgrid("hidePanel");
                            UI.fn.data.initData();

                        }
                    },
                    onClickRow: function (rowIndex, rowData) {
                        UI.fn.data.initData($("#txtSearchDevice").searchgrid("getValue"));
                    }
                });
                $("#txtDeviceType").combobox({
                    panelHeight: 80,
                    onSelect: function (rowData) {
                        UI.fn.data.initData(-1, rowData.value);
                    }
                });

                $("#txtMapHouse").searchgrid({
                    panelWidth: 270,
                    panelHeight: 120,
                    idField: 'ID',
                    textField: 'Name',
                    columns: [[
                             { field: 'Code', title: '编号', width: 100, align: 'center' },
                             { field: 'Name', title: '名称', width: 150, align: 'center' }
                    ]],
                    searchHandler: function (value) {
                        if (value != "") {
                            doActionAsync("THU.LabSystemBP.Agent.SearchEnumListBPProxy", { Type: 5, SearchTxt: value }, function (data) {
                                if (data) {
                                    $("#txtMapHouse").searchgrid("loadData", data);

                                }
                            }, null, null, false);
                        } else {
                            $("#txtMapHouse").searchgrid("hidePanel");
                        }
                    }
                });

                $("#mm1").menu({
                    onClick: function (item) {
                        var row = $("#deviceMapList").datagrid("getSelected");
                        if (!row) {
                            $.messager.alert("提示", "没有选中任何试验设备", "info");
                            return;
                        }
                        if (item.id == "btnRepair") { //报修
                            proxy = "THU.LabSystemBP.Agent.ApplyRepairBPProxy";
                            $("#txtKey").val(row.ID);
                            $("#txtMemo").val("");
                            $("#repairForm").dialog("open");

                        }
                        else if (item.id == "btnDiscard") {//报废
                            $.messager.confirm("提示", "确认报废当前设备“" + item.DeviceName + "”?", function (r) {
                                if (r) {
                                    var args = { ID: row.ID };
                                    doActionAsync("THU.LabSystemBP.Agent.DiscardDeviceBPProxy", args, function (data) {
                                        if (data) {
                                            var row = $("#deviceMapList").datagrid("getSelected");
                                            if (row) {
                                                row.DeviceStatusName = data.DeviceStatusName;
                                                row.UseStatusName = data.UseStatusName;
                                                $("#deviceMapList").datagrid("refreshRow", $('#deviceMapList').datagrid('getRowIndex', row));
                                            }
                                        }
                                    });
                                }
                            });
                        }
                    }
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
                                    $("#repairForm").dialog("close");

                                    $("#btnEdit").linkbutton({ disabled: false });
                                    $("#btnDelete").linkbutton({ disabled: false });
                                    $("#btnMapAdd").linkbutton({ disabled: false });

                                    var rowData = $("#deviceList").datagrid("getSelected");
                                    if (rowData) {
                                        UI.fn.mapData.initData(rowData.ID);
                                    }
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
            },
            mapData: {
                exchangeData: {},
                loadCombo: function () {
                    var args = {};
                    args.TypeList = [5];
                    doActionAsync("THU.LabSystemBP.Agent.GetGroupEnumListBPProxy", args, function (data) {
                        if (data) {
                            $.each(data, function (i, item) {
                                if (item.Type == 5) {
                                    $("#txtMapHouse").searchgrid("loadData", item.EnumList);
                                }
                            });
                        }
                    });
                    $("#deviceMapList").datagrid("loadData", []);
                    $("#btnMapAdd").linkbutton({ disabled: true });
                    $("#btnMapEdit").linkbutton({ disabled: true });
                    $("#btnMapDelete").linkbutton({ disabled: true });
                },
                initData: function (key) {
                    var args = {};
                    args.DeviceKey = key;
                    doActionAsync("THU.LabSystemBP.Agent.GetDeviceMapListBPProxy", args, function (data) {
                        if (data) {
                            $("#deviceMapList").datagrid("loadData", data);
                        }
                    });

                    $("#btnMapEdit").linkbutton({ disabled: true });
                    $("#btnMapDelete").linkbutton({ disabled: true });
                },
                dataCollect: function () {
                    UI.fn.mapData.exchangeData.SN = $("#txtMapSN").val();
                    UI.fn.mapData.exchangeData.House = $("#txtMapHouse").searchgrid("getValue");
                    UI.fn.mapData.exchangeData.Price = $("#txtMapPrice").numberbox("getValue");
                    UI.fn.mapData.exchangeData.Expression = $("#txtMapExpression").val();

                    if (!UI.fn.editType.isEdit) {
                        var device = $("#deviceList").datagrid("getSelected");
                        if (device) {
                            UI.fn.mapData.exchangeData.Device = device.ID;
                        }
                    }
                    if (UI.fn.mapData.exchangeData.SN == "") {
                        $.messager.alert("提示", "实验室设备编号不能为空", "info");
                        return false;
                    }
                    if (UI.fn.mapData.exchangeData.House == "") {
                        $.messager.alert("提示", "实验室设备所属房间不能为空", "info");
                        return false;
                    }
                    if (UI.fn.mapData.exchangeData.Price == "") {
                        $.messager.alert("提示", "实验室设备单价不能为空", "info");
                        return false;
                    }
                    if (UI.fn.mapData.exchangeData.Device <= 0) {
                        $.messager.alert("提示", "所属设备不能为空", "info");
                        return false;
                    }
                    return true;
                },
                dataBind: function (row) {
                    if (row) {
                        UI.fn.mapData.exchangeData = row;
                    }
                    var device = $("#deviceList").datagrid("getSelected");
                    if (device) {
                        $("#txtMapName").val(device.Name);
                        $("#txtMapPrice").numberbox("setValue", device.Price);
                        $("#txtMapExpression").val(device.Expression);

                    }
                    if (UI.fn.editMapType.isEdit) {
                        $("#txtMapSN").val(row.SN);
                        $("#txtMapPrice").numberbox("setValue", row.Price);
                        $("#txtMapExpression").val(row.Expression);
                        $("#txtMapHouse").searchgrid("setValue", row.House)
                        $("#txtMapHouse").searchgrid("setText", row.HouseName)
                    }
                }
            },
            data: {
                exchangeData: {},
                initData: function (id, type) {
                    var args = {};
                    args.Type = 1;
                    args.PageIndex = 1;
                    args.PageSize = 20;
                    args.ID = id;
                    args.Type = type;
                    Easyui.DataGrid.GetDataGridList("#deviceList", args, "THU.LabSystemBP.Agent.GetDeviceListBPProxy");
                    $("#deviceMapList").datagrid("loadData", []);
                    $("#btnEdit").linkbutton({ disabled: true });
                    $("#btnDelete").linkbutton({ disabled: true });
                },
                dataCollect: function () {
                    UI.fn.data.exchangeData.Name = $("#txtName").val();
                    UI.fn.data.exchangeData.Type = $("#txtType").combobox("getValue");
                    UI.fn.data.exchangeData.Price = $("#txtPrice").numberbox("getValue");
                    UI.fn.data.exchangeData.Expression = $("#txtExpression").val();
                    if (UI.fn.data.exchangeData.Name == "") {
                        $.messager.alert("提示", "设备名称不能为空", "info");
                        return false;
                    }
                    if (UI.fn.data.exchangeData.Type == "") {
                        $.messager.alert("提示", "设备类型不能为空", "info");
                        return false;
                    }
                    if (UI.fn.data.exchangeData.Price == "") {
                        $.messager.alert("提示", "设备单价不能为空", "info");
                        return false;
                    }

                    return true;
                },
                dataBind: function (row) {
                    UI.fn.data.exchangeData = row;
                    $("#txtName").val(row.Name);
                    $("#txtType").combobox("setValue", row.Type)
                    $("#txtPrice").numberbox("setValue", row.Price);
                    $("#txtExpression").val(row.Expression);
                }
            },
            editType: {
                isEdit: false,
                EditOK: function () {
                    if (UI.fn.data.dataCollect()) {
                        var args = {};
                        if (UI.fn.editType.isEdit && UI.fn.data.exchangeData.ID > 0) {
                            //编辑
                            args.DeviceDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyDeviceBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#deviceList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#deviceList").datagrid("refreshRow", $('#deviceList').datagrid('getRowIndex', row));
                                    UI.fn.editType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.DeviceDTO = UI.fn.data.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertDeviceBPProxy", args, function (data) {
                                if (data) {
                                    $("#deviceList").datagrid('appendRow', data);
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
                    UI.fn.data.exchangeData = {};
                    $("#txtName").val("");
                    $("#txtType").combobox("setValue", 1)
                    $("#txtPrice").numberbox("setValue", 0);
                    $("#txtExpression").val("");
                }
            },
            editMapType: {
                isEdit: false,
                EditOK: function () {
                    if (UI.fn.mapData.dataCollect()) {
                        var args = {};
                        if (UI.fn.editMapType.isEdit && UI.fn.mapData.exchangeData.ID > 0) {
                            //编辑
                            args.DeviceMapDTO = UI.fn.mapData.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.ModifyDeviceMapBPProxy", args, function (data) {
                                if (data) {
                                    var row = $("#deviceMapList").datagrid("getSelected");
                                    for (var i in data) {
                                        row[i] = data[i];
                                    }
                                    $("#deviceMapList").datagrid("refreshRow", $('#deviceMapList').datagrid('getRowIndex', row));
                                    UI.fn.editMapType.EditCancel();
                                }
                            });

                        } else {
                            //新增
                            args.DeviceMapDTO = UI.fn.mapData.exchangeData;
                            doActionAsync("THU.LabSystemBP.Agent.InsertDeviceMapBPProxy", args, function (data) {
                                if (data) {
                                    $("#deviceMapList").datagrid('appendRow', data);
                                    UI.fn.editMapType.EditCancel();
                                }
                            });

                        }
                    }
                },
                EditCancel: function () {
                    UI.fn.editMapType.ClearEdit();
                    UI.fn.editMapType.isEdit = false;
                    UI.fn.mapData.exchangeData = {};
                    $("#editMapForm").window("close");

                },
                ClearEdit: function () {
                    UI.fn.mapData.exchangeData = {};
                    $("#txtMapName").val("");
                    $("#txtMapSN").val("");
                    $("#txtMapHouse").searchgrid("setValue", "")
                    $("#txtMapHouse").searchgrid("setText", "")
                    $("#txtMapPrice").numberbox("setValue", 0);
                    $("#txtMapExpression").val("");
                }
            }
        }
    }
})(jQuery);