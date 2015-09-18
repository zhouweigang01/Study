using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceUseDescDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 标题
/// </summary>
private string  _Title ;
/// <summary>
/// 标题
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Title",Description = "标题",EntityRefrence=false,IsViewer=false)]
public virtual string  Title
{
get{
return _Title;
}
set{
this._Title=value;
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
/// <summary>
/// 描述
/// </summary>
private string  _Desc ;
/// <summary>
/// 描述
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Desc",Description = "描述",EntityRefrence=false,IsViewer=false)]
public virtual string  Desc
{
get{
return _Desc;
}
set{
this._Desc=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Title" :
	this._Title = this.TransferValue<string>(obj);
	break;
case "StartTime" :
	this._StartTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
case "Desc" :
	this._Desc = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
