using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceLogDTO : NHExt.Runtime.Model.BaseDTO
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
/// 操作人
/// </summary>
private long  _Operator ;
/// <summary>
/// 操作人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Operator",Description = "操作人",EntityRefrence=true,IsViewer=false)]
public virtual long  Operator
{
get{
return _Operator;
}
set{
this._Operator=value;
}
}
/// <summary>
/// 设备状态
/// </summary>
private int  _Status ;
/// <summary>
/// 设备状态
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Status",Description = "设备状态",EntityRefrence=true,IsViewer=false)]
public virtual int  Status
{
get{
return _Status;
}
set{
this._Status=value;
}
}
/// <summary>
/// 业务日期
/// </summary>
private DateTime  _BizDate ;
/// <summary>
/// 业务日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="BizDate",Description = "业务日期",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  BizDate
{
get{
return _BizDate;
}
set{
this._BizDate=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Device" :
	this._Device = this.TransferValue<long>(obj);
	break;
case "Operator" :
	this._Operator = this.TransferValue<long>(obj);
	break;
case "Status" :
	this._Status = this.TransferValue<int>(obj);
	break;
case "BizDate" :
	this._BizDate = this.TransferValue<DateTime>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
