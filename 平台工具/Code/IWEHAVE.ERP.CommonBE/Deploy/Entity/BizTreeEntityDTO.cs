using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class BizTreeEntityDTO : IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO
{
/// <summary>
/// 父节点ID
/// </summary>
private long ? _PID ;
/// <summary>
/// 父节点ID
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="PID",Description = "父节点ID",EntityRefrence=false,IsViewer=false)]
public virtual long ? PID
{
get{
return _PID;
}
set{
this._PID=value;
}
}
/// <summary>
/// 节点名称
/// </summary>
private string  _Name ;
/// <summary>
/// 节点名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "节点名称",EntityRefrence=false,IsViewer=false)]
public virtual string  Name
{
get{
return _Name;
}
set{
this._Name=value;
}
}
/// <summary>
/// 节点全路径
/// </summary>
private string  _FullName ;
/// <summary>
/// 节点全路径
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="FullName",Description = "节点全路径",EntityRefrence=false,IsViewer=false)]
public virtual string  FullName
{
get{
return _FullName;
}
set{
this._FullName=value;
}
}
/// <summary>
/// 节点层级
/// </summary>
private int  _Level ;
/// <summary>
/// 节点层级
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Level",Description = "节点层级",EntityRefrence=false,IsViewer=false)]
public virtual int  Level
{
get{
return _Level;
}
set{
this._Level=value;
}
}
/// <summary>
/// 同级顺序号
/// </summary>
private int  _OrderNo ;
/// <summary>
/// 同级顺序号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="OrderNo",Description = "同级顺序号",EntityRefrence=false,IsViewer=false)]
public virtual int  OrderNo
{
get{
return _OrderNo;
}
set{
this._OrderNo=value;
}
}
/// <summary>
/// 是否叶节点
/// </summary>
private bool  _Leaf ;
/// <summary>
/// 是否叶节点
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Leaf",Description = "是否叶节点",EntityRefrence=false,IsViewer=false)]
public virtual bool  Leaf
{
get{
return _Leaf;
}
set{
this._Leaf=value;
}
}
/// <summary>
/// 是否删除
/// </summary>
private bool  _IsDelete ;
/// <summary>
/// 是否删除
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsDelete",Description = "是否删除",EntityRefrence=false,IsViewer=false)]
public virtual bool  IsDelete
{
get{
return _IsDelete;
}
set{
this._IsDelete=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "PID" :
	this._PID = this.TransferValue<long?>(obj);
	break;
case "Name" :
	this._Name = this.TransferValue<string>(obj);
	break;
case "FullName" :
	this._FullName = this.TransferValue<string>(obj);
	break;
case "Level" :
	this._Level = this.TransferValue<int>(obj);
	break;
case "OrderNo" :
	this._OrderNo = this.TransferValue<int>(obj);
	break;
case "Leaf" :
	this._Leaf = this.TransferValue<bool>(obj);
	break;
case "IsDelete" :
	this._IsDelete = this.TransferValue<bool>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
