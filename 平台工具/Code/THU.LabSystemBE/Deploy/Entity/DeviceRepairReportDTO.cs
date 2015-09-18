using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceRepairReportDTO : NHExt.Runtime.Model.BaseDTO
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
/// 所属房间
/// </summary>
private string  _HouseName ;
/// <summary>
/// 所属房间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="HouseName",Description = "所属房间",EntityRefrence=false,IsViewer=false)]
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
/// 操作时间
/// </summary>
private string  _StartTime ;
/// <summary>
/// 操作时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="StartTime",Description = "操作时间",EntityRefrence=false,IsViewer=false)]
public virtual string  StartTime
{
get{
return _StartTime;
}
set{
this._StartTime=value;
}
}
/// <summary>
/// 费用
/// </summary>
private decimal  _Fee ;
/// <summary>
/// 费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fee",Description = "费用",EntityRefrence=false,IsViewer=false)]
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
/// 备注
/// </summary>
private string  _Memo ;
/// <summary>
/// 备注
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Memo",Description = "备注",EntityRefrence=false,IsViewer=false)]
public virtual string  Memo
{
get{
return _Memo;
}
set{
this._Memo=value;
}
}
/// <summary>
/// 次数
/// </summary>
private int  _Number ;
/// <summary>
/// 次数
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Number",Description = "次数",EntityRefrence=false,IsViewer=false)]
public virtual int  Number
{
get{
return _Number;
}
set{
this._Number=value;
}
}
/// <summary>
/// 设备KEY
/// </summary>
private long  _DeviceKey ;
/// <summary>
/// 设备KEY
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="DeviceKey",Description = "设备KEY",EntityRefrence=false,IsViewer=false)]
public virtual long  DeviceKey
{
get{
return _DeviceKey;
}
set{
this._DeviceKey=value;
}
}
/// <summary>
/// 维修备注
/// </summary>
private string  _RepairMemo ;
/// <summary>
/// 维修备注
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="RepairMemo",Description = "维修备注",EntityRefrence=false,IsViewer=false)]
public virtual string  RepairMemo
{
get{
return _RepairMemo;
}
set{
this._RepairMemo=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "DeviceName" :
	this._DeviceName = this.TransferValue<string>(obj);
	break;
case "HouseName" :
	this._HouseName = this.TransferValue<string>(obj);
	break;
case "SN" :
	this._SN = this.TransferValue<string>(obj);
	break;
case "StartTime" :
	this._StartTime = this.TransferValue<string>(obj);
	break;
case "Fee" :
	this._Fee = this.TransferValue<decimal>(obj);
	break;
case "Memo" :
	this._Memo = this.TransferValue<string>(obj);
	break;
case "Number" :
	this._Number = this.TransferValue<int>(obj);
	break;
case "DeviceKey" :
	this._DeviceKey = this.TransferValue<long>(obj);
	break;
case "RepairMemo" :
	this._RepairMemo = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
