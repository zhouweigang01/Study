$.extend($.messager.defaults, {
    ok: "确定",
    cancel: "取消"
});
$.extend($.fn.validatebox.defaults.rules, {
    NumberCheck: {
        validator: function (value, param) {
            var input = $("#" + param[0] + "");
            var min, max = -1;
            if (input.attr("max") != "") {
                max = parseInt(input.attr("max"));
            }
            if (input.attr("min") != "") {
                min = parseInt(input.attr("min"));
            }
            try {
                var re = /^\d*$/;
                if (!input.val().match(re)) {
                    this.message = "必须录入数字";
                    return false;
                }
                var v = parseInt(input.val());
                if (min >= 0) {
                    if (min > v) {
                        this.message = "不能小于" + min.toString();
                        return false;
                    }
                }
                if (max >= 0) {
                    if (max < v) {
                        this.message = "必须大于" + max.toString();
                        return false;
                    }
                }
            } catch (e) {
                this.message = "必须录入数字";
                return false;
            }
            return true;

        },
        message: '非法数据'
    }
});

(function ($) {
    function buildControl(target) {
        var opts = $.data(target, 'refrencebutton').options;
        if(!$(target).hasClass("easyui-ref-input")){
            $(target).addClass("easyui-ref-input");
        }
        //只有当前上层没有dom结构包裹的时候才进行dom包裹
        if(!$(target).parent().hasClass("easyui-ref-ifr")){
            var wrap = "<span class='easyui-ref-ifr'></span>";
            $(target).wrap(wrap);
            var bar = "<span class='easyui-ref-btn easyui-ref-clear'></span><span class='easyui-ref-btn easyui-ref-search'></span>";
           
            var clr ="<div style='clear:both'></div>";
            var append = bar + clr;
            $(append).insertAfter(target);
            //绑定事件
            bindEvent(target);
        }
       
        if (opts.id) {
            $(target).attr('id', opts.id);
        } else {
            $(target).attr('id', '');
        }
        setReadOnly.call(target,opts.readonly);
    }
    function bindEvent(target){
        $(target).parent().find(".easyui-ref-btn").hover(function(){
            if(isreadonly.call($(this).parent().find(".easyui-ref-input"))){return;}
            $(this).css("background-position-x","-68px");
        },function(){
        $(this).css("background-position-x","-51px");
        });
         $(target).parent().find(".easyui-ref-btn").mousedown(function(){
            if(isreadonly.call($(this).parent().find(".easyui-ref-input"))){return;}
            $(this).css("background-position-x","-34px");
        });
        $(target).parent().find(".easyui-ref-btn").mouseup(function(){
            if(isreadonly.call($(this).parent().find(".easyui-ref-input"))){return;}
            $(this).css("background-position-x","-68px");
        });
        $(target).parent().find(".easyui-ref-btn").bind("click",function(){
            if(isreadonly.call($(this).parent().find(".easyui-ref-input"))){return;}
            var opts = $.data(target, 'refrencebutton').options;
            if($(this).hasClass("easyui-ref-clear")){
               var result = opts.clearHandler.call(target ,getOpts.call(target));
               if(result == null || result == undefined || result ==true){
                    if(!isreadonly.call(target))
                    {
                        clear(target);
                    }
               }
            }else if($(this).hasClass("easyui-ref-search")){
                opts.selectHandler.call(target ,getOpts.call(target));
            }
        });
        $(target).mouseup(function(e){
            $(this).select();
            e.preventDefault();
        });

        $(target).focus(function(){
           var data = $.data(this,"refrencebutton").data;
           $(target).val(data.value);
        });
        $(target).blur(function(){
            var data = $.data(this,"refrencebutton").data;
           $(target).val(data.text);
        });
        $(target).keydown(function(e){

            if(isreadonly.call(this))
            {
               return false;
            }
            if(e.keyCode ==8){
                clear(this);
            }
            return false;
        });
    }
    function clear(target){
        $(target).val("");
        setOpts.call(target,{key:-1,value:"",text:""});
    }

    function setReadOnly(readonly){
        if(readonly){
            $(this).attr("readonly","readonly");
            $(this).css("background-color","rgb(235, 235, 228)");
            $(this).parent().find(".easyui-ref-btn").css("cursor","default");

        }else{
            $(this).removeAttr("readonly");
            $(this).css("background-color","#fff");
            $(this).parent().find(".easyui-ref-btn").css("cursor","pointer");
        }
    }
     function setOpts(opts){
        if(opts == null || opts == undefined)return false;
        if(!opts.key)return false;
        if(!opts.value)opts.value = "";
        if(!opts.text)opts.text = "";
         var state = $.data(this, 'refrencebutton');
         if(!state){
                 $.data(
                        this, 
                        'refrencebutton', 
                        {
                            options: $.extend({}, $.fn.refrencebutton.defaults, $.fn.refrencebutton.parseOptions(this), {data:opts})
                        }
                        );
                         
                 bindEvent(this);
        }
        $.data(this, "refrencebutton").data =opts;
        if(isfocus.call(this)){
            $(this).val(opts.value);
            $(this).select();
        }else{
            $(this).val(opts.text);
        }
        return true;
    }
    function getOpts(){
        var data = $.data(this, "refrencebutton").data;
        return data;
    }
    function isfocus(){
        return false;
    }
    function isreadonly(){
         return $(this).attr("readonly");
    }

    $.fn.refrencebutton = function (options, param) {
        if (typeof options == 'string') {
            return $.fn.refrencebutton.methods[options](this, param);
        }
        options = options || {};
        return this.each(function () {
            var state = $.data(this, 'refrencebutton');
            if (state) {
                $.extend(state.options, options);
            } else {
                $.data(this, 'refrencebutton', {
                    options: $.extend({}, $.fn.refrencebutton.defaults, $.fn.refrencebutton.parseOptions(this), options)
                });
                $(this).removeAttr('disabled');
            }

            buildControl(this);
        });
    };

    $.fn.refrencebutton.methods = {
        options: function (jq) {
            return $.data(jq[0], 'refrencebutton').options;
        },
        clear: function(jq){
             return jq.each(function(){
				clear(this);
			});
        },
        readOnly:function(jq,r){
            return jq.each(function(){
				setReadOnly.call(this, r);
			});
        },
        getOpts:function(jq){
          var opts = null;
          jq.each(function(){
			opts = getOpts.call(this);
		  });
        if(opts == null){
            opts={key:-1,value:'',text:''};
        }
        return opts;
        },
        setOpts:function(jq ,opts){
         return jq.each(function(){
				setOpts.call(this, opts);
			});
        }
    };

    $.fn.refrencebutton.parseOptions = function (target) {
        var t = $(target);
        return $.extend({}, $.parser.parseOptions(target, ['id','keyField','valueField','textField']), { });
    };

    $.fn.refrencebutton.defaults = {
        id: null,
        key:-1,
        value:"",
        text:"",
        readonly:false,
        clearHandler:function(opts){
            return true;   
        },
        selectHandler:function(opts){
            return true;
        }
    };

})(jQuery);

(function ($) {
    function bindControl(target) {
        var _opts = $.data(target, "searchgrid").options;
        $(target).combogrid(_opts);
        var _grid=$.data(target, "combogrid").grid;
        if(_grid){
            $.data(target, "searchgrid").grid=_grid;  
        }
        var _combo=$.data(target,"combo").combo;
        if(_combo){
           var  _comboarrow=$(_combo).find(".combo-arrow");
            if(_comboarrow){
                $(_comboarrow).addClass("combogrid-arrow");
            }
        }
    }

    $.fn.searchgrid = function (_options, _param) {
        if (typeof _options == "string") {
            var _target=$.fn.searchgrid.methods[_options];
            if(_target){
                return _target(this,_param);
            }else{
                return $.fn.combo.methods[_options](this, _param);
            }
        }
        _options = _options || {};
        return this.each(function () {
            var _state = $.data(this, "searchgrid");
            if (_state) {
                $.extend(_state.options, _options);
            } else {
                _state = $.data(this, "searchgrid", { options: $.extend({}, $.fn.searchgrid.defaults, $.fn.searchgrid.parseOptions(this), _options) });
            }
            bindControl(this);

        });
    }

    $.fn.searchgrid.methods = {
        options: function (jq) {
            return $.data(jq[0], "searchgrid").options;
        },
        grid:function(jq){
            return $.data(jq[0],"searchgrid").grid;
        },
        loadData:function(jq,data){
           return $.data(jq[0],"searchgrid").grid.datagrid("loadData", data);
        }

    };

    $.fn.searchgrid.parseOptions = function (a) {
        var t = $(a);
        return $.extend({},$.fn.combogrid.parseOptions(a), $.parser.parseOptions(a, ["idField", "textField"]));
    }

    $.fn.searchgrid.defaults = $.extend({},$.fn.combogrid.defaults, { idField: null, textField: null,delay: 500,mode:"remote",keyHandler:{
        query:function(q){
            _query(this,q);
        },
        up:function(){
            _up(this);
        },
        down:function(){
            _down(this);
        },
        enter:function(){
           _enter(this);
        }
    },
    searchHandler:function(value){
        
    }
    });

    //查询事件
     function _query(target, q) {
        var _opts = $.data(target, "searchgrid").options;
        var _grid = $.data(target, "searchgrid").grid;
        $.data(target, "searchgrid").remainText = true;
        if (_opts.multiple && !q) {
            _1c(target, [], true);
        } else {
            _1c(target, [q], true);
        }
        if (_opts.mode == "remote") {
            _grid.datagrid("clearSelections");
            _grid.datagrid("loadData",[]);
             _opts.searchHandler.call(target,q);
            
        } else {
            if (!q) {
                return;
            }
            var _rows = _grid.datagrid("getRows");
            for (var i = 0; i < _rows.length; i++) {
                if (_opts.filter.call(target, q, _rows[i])) {
                    _grid.datagrid("clearSelections");
                    _grid.datagrid("selectRow", i);
                    return;
                }
            }
        }
    };
     function _1c(target, _q, _1f) {
        var _opts = $.data(target, "searchgrid").options;
        var _grid = $.data(target, "searchgrid").grid;
        var _rows = _grid.datagrid("getRows");
        if(_rows.length>0){
            var isExist=false;
            for(var i=0;i<_rows.length;i++){
                var text=_rows[i][_opts.textField];
                if(text==_q){
                isExist=true;
                    //1.选中列表
                    _grid.datagrid("selectRow", _grid.datagrid("getRowIndex",_rows[i]));
                    //2.combo赋值
                    var value=_rows[i][_opts.idField];
                    $(target).combo("setValue",value);
                    $(target).combo("setText",text);
                }
            }
            if(!isExist){
                $(target).combo("setValue","");
            }
        }else{
            $(target).combo("setValue","");
        }
    };

    //键盘上下键事件
    //上键
    function _up(target){
         var _grid=$.data(target, "searchgrid").grid;
        var _row=_grid.datagrid("getSelected");
        var _index=_grid.datagrid("getRowIndex",_row);
        if(_index!=undefined){
            _index-=1;//上一行
        }else{
            _index=0;//第一行
        }
         _rows=_grid.datagrid("getRows");
        if(_index<0){
            _index=_rows.length-1;
        }
        _grid.datagrid("selectRow",_index);
    }
    //下键
     function _down(target) {
        var _grid=$.data(target, "searchgrid").grid;
        var _row=_grid.datagrid("getSelected");
        var _index=_grid.datagrid("getRowIndex",_row);
        if(_index!=undefined){
            _index+=1;//下一行
        }else{
            _index=0;//第一行
        }
        _rows=_grid.datagrid("getRows");
        if(_rows.length&&_index>=_rows.length){
            _index=0;
        }
        _grid.datagrid("selectRow",_index);
    };

    function _enter(target){
        $(target).combo("hidePanel");
        var _opts=$.data(target, "searchgrid").options;
        var _grid=$.data(target, "searchgrid").grid;
        var _row=_grid.datagrid("getSelected");
        if(_row){
         //         var value=_row[_opts.idField];
//         var text=_row[_opts.textField];
//         $(target).combo("setValue",value);
//         $(target).combo("setText",text);
           var index=_grid.datagrid("getRowIndex",_row);
          _opts.onClickRow.call(target, index, _row);
        }else{
         $(target).combo("setValue","");
         $(target).combo("setText","");
        }
    };
})(jQuery);