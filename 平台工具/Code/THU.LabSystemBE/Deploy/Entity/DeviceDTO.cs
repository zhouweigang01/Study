using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace THU.LabSystemBE.Deploy{
 [Serializable]
public partial class DeviceDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 设备名称
/// </summary>
private string  _Name ;
/// <summary>
/// 设备名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "设备名称",EntityRefrence=false,IsViewer=false)]
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
/// 设备类型
/// </summary>
private int  _Type ;
/// <summary>
/// 设备类型
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "设备类型",EntityRefrence=true,IsViewer=false)]
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
/// 计费方式
/// </summary>
private string  _Expression ;
/// <summary>
/// 计费方式
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Expression",Description = "计费方式",EntityRefrence=false,IsViewer=false)]
public virtual string  Expression
{
get{
return _Expression;
}
set{
this._Expression=value;
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
/// 设备价格
/// </summary>
private decimal ? _Price ;
/// <summary>
/// 设备价格
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Price",Description = "设备价格",EntityRefrence=false,IsViewer=false)]
public virtual decimal ? Price
{
get{
return _Price;
}
set{
this._Price=value;
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
case "Expression" :
	this._Expression = this.TransferValue<string>(obj);
	break;
case "Tag" :
	this._Tag = this.TransferValue<string>(obj);
	break;
case "Price" :
	this._Price = this.TransferValue<decimal?>(obj);
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
