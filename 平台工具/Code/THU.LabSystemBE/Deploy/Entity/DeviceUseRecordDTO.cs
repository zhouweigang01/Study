using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceUseRecordDTO : NHExt.Runtime.Model.BaseDTO
{
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
/// <summary>
/// 开始时间
/// </summary>
private DateTime  _BeginTime ;
/// <summary>
/// 开始时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="BeginTime",Description = "开始时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  BeginTime
{
get{
return _BeginTime;
}
set{
this._BeginTime=value;
}
}
/// <summary>
/// 结束时间
/// </summary>
private DateTime ? _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "结束时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? EndTime
{
get{
return _EndTime;
}
set{
this._EndTime=value;
}
}
/// <summary>
/// 使用费用
/// </summary>
private decimal  _Fee ;
/// <summary>
/// 使用费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fee",Description = "使用费用",EntityRefrence=false,IsViewer=false)]
public virtual decimal  Fee
{
get{
return _Fee;
}
set{
this._Fee=value;
}
}
/// <summary>
/// 使用者
/// </summary>
private long ? _User ;
/// <summary>
/// 使用者
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "使用者",EntityRefrence=true,IsViewer=false)]
public virtual long ? User
{
get{
return _User;
}
set{
this._User=value;
}
}
/// <summary>
/// 是否预约
/// </summary>
private bool  _IsAppoint ;
/// <summary>
/// 是否预约
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsAppoint",Description = "是否预约",EntityRefrence=false,IsViewer=false)]
public virtual bool  IsAppoint
{
get{
return _IsAppoint;
}
set{
this._IsAppoint=value;
}
}
/// <summary>
/// 关联导师
/// </summary>
private long  _Teacher ;
/// <summary>
/// 关联导师
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Teacher",Description = "关联导师",EntityRefrence=true,IsViewer=false)]
public virtual long  Teacher
{
get{
return _Teacher;
}
set{
this._Teacher=value;
}
}
/// <summary>
/// 是否完成
/// </summary>
private bool  _IsCompleted ;
/// <summary>
/// 是否完成
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsCompleted",Description = "是否完成",EntityRefrence=false,IsViewer=false)]
public virtual bool  IsCompleted
{
get{
return _IsCompleted;
}
set{
this._IsCompleted=value;
}
}
/// <summary>
/// 所属房间
/// </summary>
private long  _House ;
/// <summary>
/// 所属房间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="House",Description = "所属房间",EntityRefrence=true,IsViewer=false)]
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
/// 是否正在使用
/// </summary>
private bool  _IsUsing ;
/// <summary>
/// 是否正在使用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsUsing",Description = "是否正在使用",EntityRefrence=false,IsViewer=false)]
public virtual bool  IsUsing
{
get{
return _IsUsing;
}
set{
this._IsUsing=value;
}
}
/// <summary>
/// 单价
/// </summary>
private decimal  _Price ;
/// <summary>
/// 单价
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Price",Description = "单价",EntityRefrence=false,IsViewer=false)]
public virtual decimal  Price
{
get{
return _Price;
}
set{
this._Price=value;
}
}
/// <summary>
/// 使用时间
/// </summary>
private double  _TotalTime ;
/// <summary>
/// 使用时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="TotalTime",Description = "使用时间",EntityRefrence=false,IsViewer=false)]
public virtual double  TotalTime
{
get{
return _TotalTime;
}
set{
this._TotalTime=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Device" :
	this._Device = this.TransferValue<long>(obj);
	break;
case "BeginTime" :
	this._BeginTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime?>(obj);
	break;
case "Fee" :
	this._Fee = this.TransferValue<decimal>(obj);
	break;
case "User" :
	this._User = this.TransferValue<long?>(obj);
	break;
case "IsAppoint" :
	this._IsAppoint = this.TransferValue<bool>(obj);
	break;
case "Teacher" :
	this._Teacher = this.TransferValue<long>(obj);
	break;
case "IsCompleted" :
	this._IsCompleted = this.TransferValue<bool>(obj);
	break;
case "House" :
	this._House = this.TransferValue<long>(obj);
	break;
case "IsUsing" :
	this._IsUsing = this.TransferValue<bool>(obj);
	break;
case "Price" :
	this._Price = this.TransferValue<decimal>(obj);
	break;
case "TotalTime" :
	this._TotalTime = this.TransferValue<double>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
