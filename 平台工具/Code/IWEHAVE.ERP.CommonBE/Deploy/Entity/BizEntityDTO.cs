using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class BizEntityDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 创建人
/// </summary>
private long  _Creator ;
/// <summary>
/// 创建人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Creator",Description = "创建人",EntityRefrence=false,IsViewer=false)]
public virtual long  Creator
{
get{
return _Creator;
}
set{
this._Creator=value;
}
}
/// <summary>
/// 所属根组织
/// </summary>
private long  _Orgnization ;
/// <summary>
/// 所属根组织
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Orgnization",Description = "所属根组织",EntityRefrence=false,IsViewer=false)]
public virtual long  Orgnization
{
get{
return _Orgnization;
}
set{
this._Orgnization=value;
}
}
/// <summary>
/// 创建日期
/// </summary>
private DateTime ? _CreateDate ;
/// <summary>
/// 创建日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CreateDate",Description = "创建日期",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? CreateDate
{
get{
return _CreateDate;
}
set{
this._CreateDate=value;
}
}
/// <summary>
/// 修改日期
/// </summary>
private DateTime ? _ModifyDate ;
/// <summary>
/// 修改日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ModifyDate",Description = "修改日期",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? ModifyDate
{
get{
return _ModifyDate;
}
set{
this._ModifyDate=value;
}
}
/// <summary>
/// 所属子组织
/// </summary>
private long  _OrgnizationC ;
/// <summary>
/// 所属子组织
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="OrgnizationC",Description = "所属子组织",EntityRefrence=false,IsViewer=false)]
public virtual long  OrgnizationC
{
get{
return _OrgnizationC;
}
set{
this._OrgnizationC=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Creator" :
	this._Creator = this.TransferValue<long>(obj);
	break;
case "Orgnization" :
	this._Orgnization = this.TransferValue<long>(obj);
	break;
case "CreateDate" :
	this._CreateDate = this.TransferValue<DateTime?>(obj);
	break;
case "ModifyDate" :
	this._ModifyDate = this.TransferValue<DateTime?>(obj);
	break;
case "OrgnizationC" :
	this._OrgnizationC = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
