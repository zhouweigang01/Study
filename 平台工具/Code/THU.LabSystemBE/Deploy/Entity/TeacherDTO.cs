using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class TeacherDTO : NHExt.Runtime.Model.BaseDTO
{
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
/// 性别
/// </summary>
private int  _Sex ;
/// <summary>
/// 性别
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Sex",Description = "性别",EntityRefrence=true,IsViewer=false)]
public virtual int  Sex
{
get{
return _Sex;
}
set{
this._Sex=value;
}
}
/// <summary>
/// 职位
/// </summary>
private long  _Position ;
/// <summary>
/// 职位
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Position",Description = "职位",EntityRefrence=true,IsViewer=false)]
public virtual long  Position
{
get{
return _Position;
}
set{
this._Position=value;
}
}
/// <summary>
/// 所属院系
/// </summary>
private long ? _Department ;
/// <summary>
/// 所属院系
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Department",Description = "所属院系",EntityRefrence=true,IsViewer=false)]
public virtual long ? Department
{
get{
return _Department;
}
set{
this._Department=value;
}
}
/// <summary>
/// 搜索码
/// </summary>
private string  _Tag ;
/// <summary>
/// 搜索码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Tag",Description = "搜索码",EntityRefrence=false,IsViewer=false)]
public virtual string  Tag
{
get{
return _Tag;
}
set{
this._Tag=value;
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
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Name" :
	this._Name = this.TransferValue<string>(obj);
	break;
case "Sex" :
	this._Sex = this.TransferValue<int>(obj);
	break;
case "Position" :
	this._Position = this.TransferValue<long>(obj);
	break;
case "Department" :
	this._Department = this.TransferValue<long?>(obj);
	break;
case "Tag" :
	this._Tag = this.TransferValue<string>(obj);
	break;
case "IsDelete" :
	this._IsDelete = this.TransferValue<bool>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
