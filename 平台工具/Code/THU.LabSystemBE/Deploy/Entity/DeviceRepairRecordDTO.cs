using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceRepairRecordDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 设备
/// </summary>
private long  _Device ;
/// <summary>
/// 设备
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Device",Description = "设备",EntityRefrence=true,IsViewer=false)]
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
/// 报修人
/// </summary>
private long  _User ;
/// <summary>
/// 报修人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "报修人",EntityRefrence=true,IsViewer=false)]
public virtual long  User
{
get{
return _User;
}
set{
this._User=value;
}
}
/// <summary>
/// 导师
/// </summary>
private long ? _Teacher ;
/// <summary>
/// 导师
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Teacher",Description = "导师",EntityRefrence=true,IsViewer=false)]
public virtual long ? Teacher
{
get{
return _Teacher;
}
set{
this._Teacher=value;
}
}
/// <summary>
/// 报告日期
/// </summary>
private DateTime  _ReportDate ;
/// <summary>
/// 报告日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ReportDate",Description = "报告日期",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  ReportDate
{
get{
return _ReportDate;
}
set{
this._ReportDate=value;
}
}
/// <summary>
/// 是否已经处理
/// </summary>
private bool  _IsCompleted ;
/// <summary>
/// 是否已经处理
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsCompleted",Description = "是否已经处理",EntityRefrence=false,IsViewer=false)]
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
/// 完成时间
/// </summary>
private DateTime ? _CompleteDate ;
/// <summary>
/// 完成时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CompleteDate",Description = "完成时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? CompleteDate
{
get{
return _CompleteDate;
}
set{
this._CompleteDate=value;
}
}
/// <summary>
/// 处理人
/// </summary>
private long ? _CompleteUser ;
/// <summary>
/// 处理人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CompleteUser",Description = "处理人",EntityRefrence=true,IsViewer=false)]
public virtual long ? CompleteUser
{
get{
return _CompleteUser;
}
set{
this._CompleteUser=value;
}
}
/// <summary>
/// 维修费用
/// </summary>
private decimal ? _Fee ;
/// <summary>
/// 维修费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fee",Description = "维修费用",EntityRefrence=false,IsViewer=false)]
public virtual decimal ? Fee
{
get{
return _Fee;
}
set{
this._Fee=value;
}
}
/// <summary>
/// 报修原因
/// </summary>
private string  _ReportMemo ;
/// <summary>
/// 报修原因
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ReportMemo",Description = "报修原因",EntityRefrence=false,IsViewer=false)]
public virtual string  ReportMemo
{
get{
return _ReportMemo;
}
set{
this._ReportMemo=value;
}
}
/// <summary>
/// 维修时间
/// </summary>
private DateTime ? _RepairDate ;
/// <summary>
/// 维修时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="RepairDate",Description = "维修时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? RepairDate
{
get{
return _RepairDate;
}
set{
this._RepairDate=value;
}
}
/// <summary>
/// 提示用户
/// </summary>
private bool  _AlarmUser ;
/// <summary>
/// 提示用户
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="AlarmUser",Description = "提示用户",EntityRefrence=false,IsViewer=false)]
public virtual bool  AlarmUser
{
get{
return _AlarmUser;
}
set{
this._AlarmUser=value;
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
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Device" :
	this._Device = this.TransferValue<long>(obj);
	break;
case "User" :
	this._User = this.TransferValue<long>(obj);
	break;
case "Teacher" :
	this._Teacher = this.TransferValue<long?>(obj);
	break;
case "ReportDate" :
	this._ReportDate = this.TransferValue<DateTime>(obj);
	break;
case "IsCompleted" :
	this._IsCompleted = this.TransferValue<bool>(obj);
	break;
case "CompleteDate" :
	this._CompleteDate = this.TransferValue<DateTime?>(obj);
	break;
case "CompleteUser" :
	this._CompleteUser = this.TransferValue<long?>(obj);
	break;
case "Fee" :
	this._Fee = this.TransferValue<decimal?>(obj);
	break;
case "ReportMemo" :
	this._ReportMemo = this.TransferValue<string>(obj);
	break;
case "RepairDate" :
	this._RepairDate = this.TransferValue<DateTime?>(obj);
	break;
case "AlarmUser" :
	this._AlarmUser = this.TransferValue<bool>(obj);
	break;
case "House" :
	this._House = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
