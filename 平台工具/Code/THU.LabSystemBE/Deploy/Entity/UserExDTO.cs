using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class UserExDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 用户数据
/// </summary>
private List<THU.LabSystemBE.Deploy.UserDTO> _ListData = new List<THU.LabSystemBE.Deploy.UserDTO>();
/// <summary>
/// 用户数据
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListData",Description = "用户数据",EntityRefrence=true,IsViewer=false)]
public virtual List<THU.LabSystemBE.Deploy.UserDTO> ListData
{
   get { 
   return _ListData; 
   }
  set { 
		_ListData =value;
	}
 }
/// <summary>
/// 用户数量
/// </summary>
private int  _Count ;
/// <summary>
/// 用户数量
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Count",Description = "用户数量",EntityRefrence=false,IsViewer=false)]
public virtual int  Count
{
get{
return _Count;
}
set{
this._Count=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ListData" :
	this._ListData = this.TransferValue<List<THU.LabSystemBE.Deploy.UserDTO> >(obj);
	break;

case "Count" :
	this._Count = this.TransferValue<int>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
