using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class CommonEnumDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 枚举名称
/// </summary>
private string  _Name ;
/// <summary>
/// 枚举名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "枚举名称",EntityRefrence=false,IsViewer=false)]
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
/// 类别
/// </summary>
private int  _Type ;
/// <summary>
/// 类别
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "类别",EntityRefrence=true,IsViewer=false)]
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
case "Type" :
	this._Type = this.TransferValue<int>(obj);
	break;
case "Code" :
	this._Code = this.TransferValue<string>(obj);
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
