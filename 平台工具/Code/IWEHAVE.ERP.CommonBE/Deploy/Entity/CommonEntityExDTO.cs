using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class CommonEntityExDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 数据量
/// </summary>
private int  _ListCount ;
/// <summary>
/// 数据量
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListCount",Description = "数据量",EntityRefrence=false,IsViewer=false)]
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
private IWEHAVE.ERP.CommonBE.Deploy.CommonEntityDTO _ListData ;
/// <summary>
/// 数据
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ListData",Description = "数据",EntityRefrence=true,IsViewer=false)]
public virtual IWEHAVE.ERP.CommonBE.Deploy.CommonEntityDTO ListData
{
get{
return _ListData;
}
set{
this._ListData=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ListCount" :
	this._ListCount = this.TransferValue<int>(obj);
	break;
case "ListData" :
	this._ListData = this.TransferValue<IWEHAVE.ERP.CommonBE.Deploy.CommonEntityDTO>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
