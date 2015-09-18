using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceUseReportDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 设备名称
/// </summary>
private string  _DeviceName ;
/// <summary>
/// 设备名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="DeviceName",Description = "设备名称",EntityRefrence=false,IsViewer=false)]
public virtual string  DeviceName
{
get{
return _DeviceName;
}
set{
this._DeviceName=value;
}
}
/// <summary>
/// 设备编码
/// </summary>
private string  _SN ;
/// <summary>
/// 设备编码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="SN",Description = "设备编码",EntityRefrence=false,IsViewer=false)]
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
/// 开始时间
/// </summary>
private DateTime  _StartTime ;
/// <summary>
/// 开始时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="StartTime",Description = "开始时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  StartTime
{
get{
return _StartTime;
}
set{
this._StartTime=value;
}
}
/// <summary>
/// 结束时间
/// </summary>
private DateTime  _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "结束时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  EndTime
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
/// 使用人
/// </summary>
private string  _UserName ;
/// <summary>
/// 使用人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="UserName",Description = "使用人",EntityRefrence=false,IsViewer=false)]
public virtual string  UserName
{
get{
return _UserName;
}
set{
this._UserName=value;
}
}
/// <summary>
/// 导师名称
/// </summary>
private string  _TeacherName ;
/// <summary>
/// 导师名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="TeacherName",Description = "导师名称",EntityRefrence=false,IsViewer=false)]
public virtual string  TeacherName
{
get{
return _TeacherName;
}
set{
this._TeacherName=value;
}
}
/// <summary>
/// 教师key
/// </summary>
private long  _TeacherKey ;
/// <summary>
/// 教师key
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="TeacherKey",Description = "教师key",EntityRefrence=false,IsViewer=false)]
public virtual long  TeacherKey
{
get{
return _TeacherKey;
}
set{
this._TeacherKey=value;
}
}
/// <summary>
/// 房间名称
/// </summary>
private string  _HouseName ;
/// <summary>
/// 房间名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="HouseName",Description = "房间名称",EntityRefrence=false,IsViewer=false)]
public virtual string  HouseName
{
get{
return _HouseName;
}
set{
this._HouseName=value;
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
/// 时长
/// </summary>
private double  _Hours ;
/// <summary>
/// 时长
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Hours",Description = "时长",EntityRefrence=false,IsViewer=false)]
public virtual double  Hours
{
get{
return _Hours;
}
set{
this._Hours=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "DeviceName" :
	this._DeviceName = this.TransferValue<string>(obj);
	break;
case "SN" :
	this._SN = this.TransferValue<string>(obj);
	break;
case "StartTime" :
	this._StartTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
case "Fee" :
	this._Fee = this.TransferValue<decimal>(obj);
	break;
case "UserName" :
	this._UserName = this.TransferValue<string>(obj);
	break;
case "TeacherName" :
	this._TeacherName = this.TransferValue<string>(obj);
	break;
case "TeacherKey" :
	this._TeacherKey = this.TransferValue<long>(obj);
	break;
case "HouseName" :
	this._HouseName = this.TransferValue<string>(obj);
	break;
case "Price" :
	this._Price = this.TransferValue<decimal>(obj);
	break;
case "Hours" :
	this._Hours = this.TransferValue<double>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
