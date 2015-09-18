using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class GroupEnumDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 枚举类别
/// </summary>
private int  _Type ;
/// <summary>
/// 枚举类别
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "枚举类别",EntityRefrence=false,IsViewer=false)]
public virtual int  Type
{
get{
return _Type;
}
set{
this._Type=value;
}
}
/// <summary>
/// 枚举列表
/// </summary>
private List<THU.LabSystemBE.Deploy.CommonEnumDTO> _EnumList = new List<THU.LabSystemBE.Deploy.CommonEnumDTO>();
/// <summary>
/// 枚举列表
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EnumList",Description = "枚举列表",EntityRefrence=true,IsViewer=false)]
public virtual List<THU.LabSystemBE.Deploy.CommonEnumDTO> EnumList
{
   get { 
   return _EnumList; 
   }
  set { 
		_EnumList =value;
	}
 }
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Type" :
	this._Type = this.TransferValue<int>(obj);
	break;
case "EnumList" :
	this._EnumList = this.TransferValue<List<THU.LabSystemBE.Deploy.CommonEnumDTO> >(obj);
	break;

		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
