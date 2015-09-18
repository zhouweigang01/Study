using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class LoginLoggerDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 登陆用户
/// </summary>
private long  _User ;
/// <summary>
/// 登陆用户
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "登陆用户",EntityRefrence=false,IsViewer=false)]
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
/// 姓名
/// </summary>
private string  _Name ;
/// <summary>
/// 姓名
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "姓名",EntityRefrence=false,IsViewer=false)]
public virtual string  Name
{
get{
return _Name;
}
set{
this._Name=value;
}
}
/// <summary>
/// 登陆IP
/// </summary>
private string  _IP ;
/// <summary>
/// 登陆IP
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IP",Description = "登陆IP",EntityRefrence=false,IsViewer=false)]
public virtual string  IP
{
get{
return _IP;
}
set{
this._IP=value;
}
}
/// <summary>
/// 是否成功
/// </summary>
private bool  _Success ;
/// <summary>
/// 是否成功
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Success",Description = "是否成功",EntityRefrence=false,IsViewer=false)]
public virtual bool  Success
{
get{
return _Success;
}
set{
this._Success=value;
}
}
/// <summary>
/// 错误原因
/// </summary>
private string  _ErrorMsg ;
/// <summary>
/// 错误原因
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ErrorMsg",Description = "错误原因",EntityRefrence=false,IsViewer=false)]
public virtual string  ErrorMsg
{
get{
return _ErrorMsg;
}
set{
this._ErrorMsg=value;
}
}
/// <summary>
/// 登录时间
/// </summary>
private DateTime  _LoginDate ;
/// <summary>
/// 登录时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="LoginDate",Description = "登录时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime  LoginDate
{
get{
return _LoginDate;
}
set{
this._LoginDate=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "User" :
	this._User = this.TransferValue<long>(obj);
	break;
case "Name" :
	this._Name = this.TransferValue<string>(obj);
	break;
case "IP" :
	this._IP = this.TransferValue<string>(obj);
	break;
case "Success" :
	this._Success = this.TransferValue<bool>(obj);
	break;
case "ErrorMsg" :
	this._ErrorMsg = this.TransferValue<string>(obj);
	break;
case "LoginDate" :
	this._LoginDate = this.TransferValue<DateTime>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
