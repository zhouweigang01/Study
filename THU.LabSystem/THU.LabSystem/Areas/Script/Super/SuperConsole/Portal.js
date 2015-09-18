(function ($) {
    //动态菜单数据
    window.$PageGuid = "THU.LabSystem.Console";
    $(document).ready(function () {
        var treeData = [
    {
        text: "组织管理",
        children: [
        {
            text: "组织设置",
            iconCls: "icon-menu",
            attributes:
            {
                url: "/Super/SuperConsole/Org"
            }
        },
        {
            text: "组织用户",
            iconCls: "icon-menu",
            attributes:
            {
                url: "/Super/SuperConsole/OrgUser"
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
            tabs.tabs("close", curTabTitle);
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
