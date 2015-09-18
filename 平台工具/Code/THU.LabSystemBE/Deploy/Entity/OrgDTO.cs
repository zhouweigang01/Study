using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class OrgDTO : IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO
{
/// <summary>
/// 编码
/// </summary>
private string  _Code ;
/// <summary>
/// 编码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Code",Description = "编码",EntityRefrence=false,IsViewer=false)]
public virtual string  Code
{
get{
return _Code;
}
set{
this._Code=value;
}
}
/// <summary>
/// 名称
/// </summary>
private string  _Name ;
/// <summary>
/// 名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "名称",EntityRefrence=false,IsViewer=false)]
public virtual string  Name
{
get{
return _Name;
}
set{
this._Name=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Code" :
	this._Code = this.TransferValue<string>(obj);
	break;
case "Name" :
	this._Name = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
