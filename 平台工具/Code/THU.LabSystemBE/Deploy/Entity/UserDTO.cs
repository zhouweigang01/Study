using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class UserDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 学号
/// </summary>
private string  _SN ;
/// <summary>
/// 学号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="SN",Description = "学号",EntityRefrence=false,IsViewer=false)]
public virtual string  SN
{
get{
return _SN;
}
set{
this._SN=value;
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
/// 电话
/// </summary>
private string  _Tel ;
/// <summary>
/// 电话
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Tel",Description = "电话",EntityRefrence=false,IsViewer=false)]
public virtual string  Tel
{
get{
return _Tel;
}
set{
this._Tel=value;
}
}
/// <summary>
/// 密码
/// </summary>
private string  _Password ;
/// <summary>
/// 密码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Password",Description = "密码",EntityRefrence=false,IsViewer=false)]
public virtual string  Password
{
get{
return _Password;
}
set{
this._Password=value;
}
}
/// <summary>
/// 学历
/// </summary>
private long ? _Degree ;
/// <summary>
/// 学历
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Degree",Description = "学历",EntityRefrence=true,IsViewer=false)]
public virtual long ? Degree
{
get{
return _Degree;
}
set{
this._Degree=value;
}
}
/// <summary>
/// 身份
/// </summary>
private long ? _Status ;
/// <summary>
/// 身份
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Status",Description = "身份",EntityRefrence=true,IsViewer=false)]
public virtual long ? Status
{
get{
return _Status;
}
set{
this._Status=value;
}
}
/// <summary>
/// 用户类别
/// </summary>
private int  _Type ;
/// <summary>
/// 用户类别
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "用户类别",EntityRefrence=true,IsViewer=false)]
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
/// 邮件
/// </summary>
private string  _Email ;
/// <summary>
/// 邮件
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Email",Description = "邮件",EntityRefrence=false,IsViewer=false)]
public virtual string  Email
{
get{
return _Email;
}
set{
this._Email=value;
}
}
/// <summary>
/// 登录名
/// </summary>
private string  _Code ;
/// <summary>
/// 登录名
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Code",Description = "登录名",EntityRefrence=false,IsViewer=false)]
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
/// 是否删除
/// </summary>
private bool  _IsDelete ;
/// <summary>
/// 是否删除
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsDelete",Description = "是否删除",EntityRefrence=false,IsViewer=false)]
public virtual bool  IsDelete
{
get{
return _IsDelete;
}
set{
this._IsDelete=value;
}
}
/// <summary>
/// 启用时间
/// </summary>
private DateTime ? _BeginTime ;
/// <summary>
/// 启用时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="BeginTime",Description = "启用时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? BeginTime
{
get{
return _BeginTime;
}
set{
this._BeginTime=value;
}
}
/// <summary>
/// 停用时间
/// </summary>
private DateTime ? _EndTime ;
/// <summary>
/// 停用时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "停用时间",EntityRefrence=false,IsViewer=false)]
public virtual DateTime ? EndTime
{
get{
return _EndTime;
}
set{
this._EndTime=value;
}
}
/// <summary>
/// 导师
/// </summary>
private long ? _Teacher ;
/// <summary>
/// 导师
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Teacher",Description = "导师",EntityRefrence=true,IsViewer=false)]
public virtual long ? Teacher
{
get{
return _Teacher;
}
set{
this._Teacher=value;
}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "SN" :
	this._SN = this.TransferValue<string>(obj);
	break;
case "Name" :
	this._Name = this.TransferValue<string>(obj);
	break;
case "Tel" :
	this._Tel = this.TransferValue<string>(obj);
	break;
case "Password" :
	this._Password = this.TransferValue<string>(obj);
	break;
case "Degree" :
	this._Degree = this.TransferValue<long?>(obj);
	break;
case "Status" :
	this._Status = this.TransferValue<long?>(obj);
	break;
case "Type" :
	this._Type = this.TransferValue<int>(obj);
	break;
case "Email" :
	this._Email = this.TransferValue<string>(obj);
	break;
case "Code" :
	this._Code = this.TransferValue<string>(obj);
	break;
case "IsDelete" :
	this._IsDelete = this.TransferValue<bool>(obj);
	break;
case "BeginTime" :
	this._BeginTime = this.TransferValue<DateTime?>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime?>(obj);
	break;
case "Teacher" :
	this._Teacher = this.TransferValue<long?>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
