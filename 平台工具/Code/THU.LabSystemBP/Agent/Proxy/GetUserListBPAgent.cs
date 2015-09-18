using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class GetUserListBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="a86f63b9-2790-43f7-be3c-0ca79f2e00ed";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.GetUserListBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 用户类别
/// </summary>
private int  _Type ;
/// <summary>
/// 用户类别
/// </summary>
public virtual int Type
{
get{
return _Type;
}
set{
 _Type= value;
}
}

/// <summary>
/// 页面数量
/// </summary>
private int  _PageSize ;
/// <summary>
/// 页面数量
/// </summary>
public virtual int PageSize
{
get{
return _PageSize;
}
set{
 _PageSize= value;
}
}

/// <summary>
/// 页数
/// </summary>
private int  _PageIndex ;
/// <summary>
/// 页数
/// </summary>
public virtual int PageIndex
{
get{
return _PageIndex;
}
set{
 _PageIndex= value;
}
}

/// <summary>
/// 查询客户ID
/// </summary>
private long  _ID ;
/// <summary>
/// 查询客户ID
/// </summary>
public virtual long ID
{
get{
return _ID;
}
set{
 _ID= value;
}
}

public GetUserListBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "GetUserListBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._Type);
	this.invoker.ParamList.Add(this._PageSize);
	this.invoker.ParamList.Add(this._PageIndex);
	this.invoker.ParamList.Add(this._ID);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.UserExDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.UserExDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.UserExDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.UserExDTO Do()
	{
		 THU.LabSystemBE.Deploy.UserExDTO obj = ( THU.LabSystemBE.Deploy.UserExDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Type" :
	this._Type = this.TransferValue<int>(obj);
	break;
case "PageSize" :
	this._PageSize = this.TransferValue<int>(obj);
	break;
case "PageIndex" :
	this._PageIndex = this.TransferValue<int>(obj);
	break;
case "ID" :
	this._ID = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

