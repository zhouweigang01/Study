using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceUseReportExDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 数量
/// </summary>
private int  _ListCount ;
/// <summary>
/// 数量
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListCount",Description = "数量",EntityRefrence=false,IsViewer=false)]
public virtual int  ListCount
{
get{
return _ListCount;
}
set{
this._ListCount=value;
}
}
/// <summary>
/// 数据
/// </summary>
private List<THU.LabSystemBE.Deploy.DeviceUseReportDTO> _ListData = new List<THU.LabSystemBE.Deploy.DeviceUseReportDTO>();
/// <summary>
/// 数据
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListData",Description = "数据",EntityRefrence=true,IsViewer=false)]
public virtual List<THU.LabSystemBE.Deploy.DeviceUseReportDTO> ListData
{
   get { 
   return _ListData; 
   }
  set { 
		_ListData =value;
	}
 }
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ListCount" :
	this._ListCount = this.TransferValue<int>(obj);
	break;
case "ListData" :
	this._ListData = this.TransferValue<List<THU.LabSystemBE.Deploy.DeviceUseReportDTO> >(obj);
	break;

		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
