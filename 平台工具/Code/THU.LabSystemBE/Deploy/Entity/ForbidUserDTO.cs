using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class ForbidUserDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 用户
/// </summary>
private long  _User ;
/// <summary>
/// 用户
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "用户",EntityRefrence=true,IsViewer=false)]
public virtual long  User
{
get{
return _User;
}
set{
this._User=value;
}
}
/// <summary>
/// 开始时间
/// </summary>
private DateTime  _StartTime ;
/// <summary>
/// 开始时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="StartTime",Description = "开始时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  StartTime
{
get{
return _StartTime;
}
set{
this._StartTime=value;
}
}
/// <summary>
/// 结束时间
/// </summary>
private DateTime  _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "结束时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  EndTime
{
get{
return _EndTime;
}
set{
this._EndTime=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "User" :
	this._User = this.TransferValue<long>(obj);
	break;
case "StartTime" :
	this._StartTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
