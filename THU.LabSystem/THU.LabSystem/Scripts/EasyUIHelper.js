Easyui = {
    getResult: function (dataUrl, arg, callback, callbackArgs, asynccallback, displayLoading) {
        var _data = null;
        var args = {};
        args = arg;
        if (asynccallback) {
            doActionAsync(dataUrl, args, function (result) {
                if (result == null) {
                    _data = null;
                }
                else {
                    _data = result;
                    if (result.ListCount == undefined) {
                        //整理数据
                        $.each(_data, function (i, item) {
                            if (callback) {
                                callback.call(item, callbackArgs);
                            }
                        });
                    }
                }
                asynccallback(_data);
            }, null, null, displayLoading);
        } else {
            doAction(dataUrl, args, function (result) {
                if (result == null) {
                    _data = null;
                }
                else {
                    _data = result;
                    if (result.ListCount == undefined) {
                        //整理数据
                        $.each(_data, function (i, item) {
                            if (callback) {
                                callback.call(item, callbackArgs);
                            }
                        });
                    }
                }
            }, null, null, displayLoading);
        }
        return _data;
    },
    Tree: {//获取树型结构pid:选择器名称，dataUrl:请求数据地址，args:参数,typeEnum：控件类型
        Append: function (pid, _data, node, treeEnum) {
            if (treeEnum == "tree") {//一般树
                $(pid).tree('append', {
                    parent: node.target,
                    data: _data
                });
            } else if (treeEnum == "combotree") {//下拉列表树
                $(pid).combotree('tree').tree('append', {
                    parent: node.target,
                    data: _data
                });
            } else if (treeEnum == "treegrid") {
                $(pid).treegrid('append', {
                    parent: node.id,
                    data: _data
                });
            }
        },
        GetChildren: function (pid, node, dataUrl, arg, treeEnum, callback, callbackArgs) {
            if (node) {
                Easyui.getResult(dataUrl, arg, callback, callbackArgs, function (_data) {
                    if (_data != null) {
                        //格式化数据
                        //追加子节点
                        //-------treegrid分页新加代码
                        if (_data.ListData != undefined) {
                            _data = _data.ListData;
                            if (callback) {
                                $.each(_data, function (i, item) {
                                    callback.call(item, callbackArgs);
                                });
                            }
                        }
                        //---------------------
                        var children = [];
                        if (node.target != undefined) {
                            children = $(pid).tree('getChildren', node.target);
                        } else if (node.children != undefined) {
                            children = node.children;
                        }
                        if (children.length > 0) {
                            $.each(children, function (i, item) {
                                for (var j = 0; j < _data.length; j++) {
                                    if (item.ID != undefined) {
                                        if (item.ID == _data[j].ID) {
                                            _data = Util.ArrayHelper.removeAt(_data, j);
                                        }
                                    } else {
                                        if (item.id == _data[j].ID) {
                                            _data = Util.ArrayHelper.removeAt(_data, j);
                                        }
                                    }
                                }
                            });

                        }
                        Easyui.Tree.Append(pid, _data, node, treeEnum);

                    }
                });

            }
        },
        GetTreeNode: function (pid, dataUrl, args, treeEnum, callback, callbackArgs, loadedCallback, afterloadCallback) {
            Easyui.getResult(dataUrl, args, callback, callbackArgs, function (result) {
                if (result != null) {
                    if (loadedCallback) {
                        loadedCallback(result);
                    }
                    //树
                    if (treeEnum == "tree") {
                        $(pid).tree({
                            animate: true,
                            onBeforeExpand: function (node) {
                                args.ID = parseInt(node.id);
                                if (!node.attributes.hasExpand) {
                                    node.attributes.hasExpand = true;
                                    Easyui.Tree.GetChildren(pid, node, dataUrl, args, treeEnum, callback, callbackArgs);
                                }
                            }
                        }).tree("loadData", result);

                    } else if (treeEnum == "combotree") {//下拉列表树
                        //下拉组织
                        $(pid).combotree({
                            onBeforeExpand: function (node) {
                                args.ID = parseInt(node.id);
                                if (!node.attributes.hasExpand) {
                                    node.attributes.hasExpand = true;
                                    Easyui.Tree.GetChildren(pid, node, dataUrl, args, treeEnum, callback, callbackArgs);
                                }

                            }
                        }).combotree('loadData', result);
                    } else if (treeEnum == "treegrid") {//树列表
                        $(pid).treegrid({
                            onBeforeExpand: function (node) {
                                if (!node.attributes.hasExpand) {
                                    args.ID = node.ID;
                                    node.attributes.hasExpand = true;
                                    Easyui.Tree.GetChildren(pid, node, dataUrl, args, treeEnum, callback, callbackArgs);
                                }
                            }
                        }).treegrid('loadData', result);

                    }
                    if (afterloadCallback) {
                        afterloadCallback(result);
                    }
                }
            });
        }
    },
    ComboGrid: {//获取ComboGrid列表数据
        GetComboGridList: function (pid, args, dataUrl, callback) {
            Easyui.getResult(dataUrl, args, null, null, function (result) {
                var _callback = callback;
                if (result != null) {
                    var _dataCount = result.ListCount;
                    var _data = result.ListData;
                    if (callback) {
                        callback(_data);
                    }
                    $(pid).combogrid("grid").datagrid('loadData', _data);
                    $(pid).combogrid("grid").datagrid('getPager').pagination({
                        pageSize: args.PageSize,
                        total: _dataCount,
                        pageNumber: args.PageIndex,
                        onSelectPage: function (pageNumber, pageSize) {
                            $(pid).parent().find("div .datagrid-header-check").children("input[type='checkbox']").eq(0).attr("checked", false);
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.ComboGrid.GetComboGridList(pid, args, dataUrl, _callback);
                        },
                        onRefresh: function (pageNumber, pageSize) {
                            $(pid).parent().find("div .datagrid-header-check").children("input[type='checkbox']").eq(0).attr("checked", false);
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.ComboGrid.GetComboGridList(pid, args, dataUrl, _callback);
                        }
                    });

                }
            });
        }
    },
    DataGrid: {//获取DataGrid列表数据
        GetDataGridList: function (pid, args, dataUrl, callback, loadedCallback, displayLoading) {
            Easyui.getResult(dataUrl, args, null, null, function (result) {
                if (result != null && result.ListData != null) {
                    var _dataCount = result.ListCount;
                    var _data = result.ListData;
                    if (callback) {
                        callback(_data);
                    }
                    if (_data == "") {
                        _data = [];
                    }
                    $(pid).datagrid('loadData', _data);
                    $(pid).datagrid('getPager').pagination({
                        pageSize: args.PageSize,
                        total: _dataCount,
                        pageNumber: args.PageIndex,
                        onSelectPage: function (pageNumber, pageSize) {
                            $(pid).parent().find("div .datagrid-header-check").children("input[type='checkbox']").eq(0).attr("checked", false);
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.DataGrid.GetDataGridList(pid, args, dataUrl, callback, loadedCallback, displayLoading);
                        },
                        onRefresh: function (pageNumber, pageSize) {
                            $(pid).parent().find("div .datagrid-header-check").children("input[type='checkbox']").eq(0).attr("checked", false);
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.DataGrid.GetDataGridList(pid, args, dataUrl, callback, loadedCallback, displayLoading);
                        }
                    });
                    if (loadedCallback) {
                        loadedCallback(_data);
                    }

                }
            }, displayLoading);

        },
        GetDataGridPagerSize: function (id) {
            var pagerSize = {};
            var pager = $("#" + id).datagrid("getPager");
            if (pager) {
                pagerSize.Size = pager.pagination("options").pageSize;
                pagerSize.Page = pager.pagination("options").pageNumber;
            }
            return pagerSize;
        }
    },
    TreeGrid: {//treegrid分页
        GetTreeGridList: function (pid, dataUrl, args, callback, callbackArgs, loadedCallback, afterloadCallback, isPecial) {
            Easyui.getResult(dataUrl, args, callback, callbackArgs, function (result) {
                if (result != null && result.ListData != null) {
                    var _dataCount = result.ListCount;
                    var _data = result.ListData;

                    if (callback) {
                        $.each(_data, function (i, item) {
                            callback.call(item, callbackArgs);
                        });
                    }

                    if (_data == "") {
                        _data = [];
                    }
                    $(pid).treegrid('loadData', []);

                    if (isPecial) {
                        //特殊页面：如toolbar上有combobox之类的，自定义的onBeforeExpand事件的,只需要加载数据就行
                        $(pid).treegrid('loadData', _data);
                    } else {
                        $(pid).treegrid({
                            onBeforeExpand: function (node) {
                                if (!node.attributes.hasExpand) {
                                    args.ID = node.ID;
                                    node.attributes.hasExpand = true;
                                    //展开子节点不需要分页
                                    args.PageIndex = 0;
                                    args.PageSize = 0;
                                    Easyui.Tree.GetChildren(pid, node, dataUrl, args, "treegrid", callback, callbackArgs);
                                }
                            }
                        }).treegrid('loadData', _data);
                    }
                    $(pid).treegrid('getPager').pagination({
                        pageSize: args.PageSize,
                        total: _dataCount,
                        pageNumber: args.PageIndex,
                        onSelectPage: function (pageNumber, pageSize) {
                            args.ID = 0;
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.TreeGrid.GetTreeGridList(pid, dataUrl, args, callback, callbackArgs, loadedCallback, afterloadCallback, isPecial);
                        },
                        onRefresh: function (pageNumber, pageSize) {
                            args.ID = 0;
                            args.PageIndex = pageNumber;
                            args.PageSize = pageSize;
                            Easyui.TreeGrid.GetTreeGridList(pid, dataUrl, args, callback, callbackArgs, loadedCallback, afterloadCallback, isPecial);
                        }
                    });

                    if (loadedCallback) {
                        loadedCallback(_data);
                    }

                }
            });

        }
    }

}