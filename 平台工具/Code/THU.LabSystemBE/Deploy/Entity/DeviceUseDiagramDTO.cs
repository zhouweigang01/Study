using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceUseDiagramDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 日期
/// </summary>
private string  _Date ;
/// <summary>
/// 日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Date",Description = "日期",EntityRefrence=false,IsViewer=false)]
public virtual string  Date
{
get{
return _Date;
}
set{
this._Date=value;
}
}
/// <summary>
/// 总时间
/// </summary>
private decimal  _TotalHours ;
/// <summary>
/// 总时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="TotalHours",Description = "总时间",EntityRefrence=false,IsViewer=false)]
public virtual decimal  TotalHours
{
get{
return _TotalHours;
}
set{
this._TotalHours=value;
}
}
/// <summary>
/// 数据明细
/// </summary>
private List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> _ListData = new List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO>();
/// <summary>
/// 数据明细
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListData",Description = "数据明细",EntityRefrence=true,IsViewer=false)]
public virtual List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> ListData
{
   get { 
   return _ListData; 
   }
  set { 
		_ListData =value;
	}
 }
/// <summary>
/// 总费用
/// </summary>
private decimal  _TotalFee ;
/// <summary>
/// 总费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="TotalFee",Description = "总费用",EntityRefrence=false,IsViewer=false)]
public virtual decimal  TotalFee
{
get{
return _TotalFee;
}
set{
this._TotalFee=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Date" :
	this._Date = this.TransferValue<string>(obj);
	break;
case "TotalHours" :
	this._TotalHours = this.TransferValue<decimal>(obj);
	break;
case "ListData" :
	this._ListData = this.TransferValue<List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> >(obj);
	break;

case "TotalFee" :
	this._TotalFee = this.TransferValue<decimal>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
