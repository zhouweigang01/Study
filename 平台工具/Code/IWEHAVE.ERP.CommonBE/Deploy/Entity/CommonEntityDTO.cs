using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.Model;
namespace IWEHAVE.ERP.CommonBE.Deploy{
 [Serializable]
public partial class CommonEntityDTO : NHExt.Runtime.Model.BaseDTO
{
/// <summary>
/// 名称
/// </summary>
private List<string> _ColumnName = new List<string>();
/// <summary>
/// 名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ColumnName",Description = "名称",EntityRefrence=false,IsViewer=false)]
public virtual List<string> ColumnName
{
   get { 
   return _ColumnName; 
   }
  set { 
		_ColumnName =value;
	}
 }
/// <summary>
/// 值
/// </summary>
private List<object> _ColumnValue = new List<object>();
/// <summary>
/// 值
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ColumnValue",Description = "值",EntityRefrence=false,IsViewer=false)]
public virtual List<object> ColumnValue
{
   get { 
   return _ColumnValue; 
   }
  set { 
		_ColumnValue =value;
	}
 }
/// <summary>
/// 编码
/// </summary>
private List<string> _ColumnCode = new List<string>();
/// <summary>
/// 编码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ColumnCode",Description = "编码",EntityRefrence=false,IsViewer=false)]
public virtual List<string> ColumnCode
{
   get { 
   return _ColumnCode; 
   }
  set { 
		_ColumnCode =value;
	}
 }
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ColumnName" :
	this._ColumnName = this.TransferValue<List<string> >(obj);
	break;

case "ColumnValue" :
	this._ColumnValue = this.TransferValue<List<object> >(obj);
	break;

case "ColumnCode" :
	this._ColumnCode = this.TransferValue<List<string> >(obj);
	break;

		default:
			base.SetValue(obj,memberName);
			break;
		}
	}


 }
}
