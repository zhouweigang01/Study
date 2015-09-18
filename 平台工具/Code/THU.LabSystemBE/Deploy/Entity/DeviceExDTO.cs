using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceExDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 数量
/// </summary>
private int  _Count ;
/// <summary>
/// 数量
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Count",Description = "数量",EntityRefrence=false,IsViewer=false)]
public virtual int  Count
{
get{
return _Count;
}
set{
this._Count=value;
}
}
/// <summary>
/// 数据
/// </summary>
private List<THU.LabSystemBE.Deploy.DeviceDTO> _ListData = new List<THU.LabSystemBE.Deploy.DeviceDTO>();
/// <summary>
/// 数据
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListData",Description = "数据",EntityRefrence=true,IsViewer=false)]
public virtual List<THU.LabSystemBE.Deploy.DeviceDTO> ListData
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
case "Count" :
	this._Count = this.TransferValue<int>(obj);
	break;
case "ListData" :
	this._ListData = this.TransferValue<List<THU.LabSystemBE.Deploy.DeviceDTO> >(obj);
	break;

		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
