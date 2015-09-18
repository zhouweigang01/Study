using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceMapDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 房间
/// </summary>
private long  _House ;
/// <summary>
/// 房间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="House",Description = "房间",EntityRefrence=true,IsViewer=false)]
public virtual long  House
{
get{
return _House;
}
set{
this._House=value;
}
}
/// <summary>
/// 设备号
/// </summary>
private string  _SN ;
/// <summary>
/// 设备号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="SN",Description = "设备号",EntityRefrence=false,IsViewer=false)]
public virtual string  SN
{
get{
return _SN;
}
set{
this._SN=value;
}
}
/// <summary>
/// 设备状态
/// </summary>
private int  _DeviceStatus ;
/// <summary>
/// 设备状态
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="DeviceStatus",Description = "设备状态",EntityRefrence=true,IsViewer=false)]
public virtual int  DeviceStatus
{
get{
return _DeviceStatus;
}
set{
this._DeviceStatus=value;
}
}
/// <summary>
/// 使用状态
/// </summary>
private int  _UseStatus ;
/// <summary>
/// 使用状态
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="UseStatus",Description = "使用状态",EntityRefrence=true,IsViewer=false)]
public virtual int  UseStatus
{
get{
return _UseStatus;
}
set{
this._UseStatus=value;
}
}
/// <summary>
/// 设备单价
/// </summary>
private decimal ? _Price ;
/// <summary>
/// 设备单价
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Price",Description = "设备单价",EntityRefrence=false,IsViewer=false)]
public virtual decimal ? Price
{
get{
return _Price;
}
set{
this._Price=value;
}
}
/// <summary>
/// 计算公式
/// </summary>
private string  _Expression ;
/// <summary>
/// 计算公式
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Expression",Description = "计算公式",EntityRefrence=false,IsViewer=false)]
public virtual string  Expression
{
get{
return _Expression;
}
set{
this._Expression=value;
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
/// <summary>
/// 关联设备
/// </summary>
private long  _Device ;
/// <summary>
/// 关联设备
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Device",Description = "关联设备",EntityRefrence=true,IsViewer=false)]
public virtual long  Device
{
get{
return _Device;
}
set{
this._Device=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "House" :
	this._House = this.TransferValue<long>(obj);
	break;
case "SN" :
	this._SN = this.TransferValue<string>(obj);
	break;
case "DeviceStatus" :
	this._DeviceStatus = this.TransferValue<int>(obj);
	break;
case "UseStatus" :
	this._UseStatus = this.TransferValue<int>(obj);
	break;
case "Price" :
	this._Price = this.TransferValue<decimal?>(obj);
	break;
case "Expression" :
	this._Expression = this.TransferValue<string>(obj);
	break;
case "IsDelete" :
	this._IsDelete = this.TransferValue<bool>(obj);
	break;
case "Device" :
	this._Device = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
