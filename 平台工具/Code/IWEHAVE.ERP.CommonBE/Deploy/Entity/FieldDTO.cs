using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class FieldDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 列标识
/// </summary>
private string  _FieldKey ;
/// <summary>
/// 列标识
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="FieldKey",Description = "列标识",EntityRefrence=false,IsViewer=false)]
public virtual string  FieldKey
{
get{
return _FieldKey;
}
set{
this._FieldKey=value;
}
}
/// <summary>
/// 列值
/// </summary>
private object  _FieldValue ;
/// <summary>
/// 列值
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="FieldValue",Description = "列值",EntityRefrence=false,IsViewer=false)]
public virtual object  FieldValue
{
get{
return _FieldValue;
}
set{
this._FieldValue=value;
}
}
/// <summary>
/// 列类型
/// </summary>
private string  _FieldType ;
/// <summary>
/// 列类型
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="FieldType",Description = "列类型",EntityRefrence=false,IsViewer=false)]
public virtual string  FieldType
{
get{
return _FieldType;
}
set{
this._FieldType=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "FieldKey" :
	this._FieldKey = this.TransferValue<string>(obj);
	break;
case "FieldValue" :
	this._FieldValue = this.TransferValue<object>(obj);
	break;
case "FieldType" :
	this._FieldType = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
