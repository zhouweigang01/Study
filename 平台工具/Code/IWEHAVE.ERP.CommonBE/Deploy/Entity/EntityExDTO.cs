using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class EntityExDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 实体类名称
/// </summary>
private string  _EntityClass ;
/// <summary>
/// 实体类名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EntityClass",Description = "实体类名称",EntityRefrence=false,IsViewer=false)]
public virtual string  EntityClass
{
get{
return _EntityClass;
}
set{
this._EntityClass=value;
}
}
/// <summary>
/// 实体ID
/// </summary>
private long  _EntityKey ;
/// <summary>
/// 实体ID
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EntityKey",Description = "实体ID",EntityRefrence=false,IsViewer=false)]
public virtual long  EntityKey
{
get{
return _EntityKey;
}
set{
this._EntityKey=value;
}
}
/// <summary>
/// 实体列数据
/// </summary>
private List<IWEHAVE.ERP.CommonBE.Deploy.FieldDTO> _Fields = new List<IWEHAVE.ERP.CommonBE.Deploy.FieldDTO>();
/// <summary>
/// 实体列数据
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fields",Description = "实体列数据",EntityRefrence=true,IsViewer=false)]
public virtual List<IWEHAVE.ERP.CommonBE.Deploy.FieldDTO> Fields
{
   get { 
   return _Fields; 
   }
  set { 
		_Fields =value;
	}
 }
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "EntityClass" :
	this._EntityClass = this.TransferValue<string>(obj);
	break;
case "EntityKey" :
	this._EntityKey = this.TransferValue<long>(obj);
	break;
case "Fields" :
	this._Fields = this.TransferValue<List<IWEHAVE.ERP.CommonBE.Deploy.FieldDTO> >(obj);
	break;

		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
