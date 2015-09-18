using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class GetDeviceUseRecordBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="aa91f016-d4a9-4232-a944-71c77ba748f6";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.GetDeviceUseRecordBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 是否预约记录
/// </summary>
private bool  _IsAppoint ;
/// <summary>
/// 是否预约记录
/// </summary>
public virtual bool IsAppoint
{
get{
return _IsAppoint;
}
set{
 _IsAppoint= value;
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
/// 大小
/// </summary>
private int  _PageSize ;
/// <summary>
/// 大小
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
/// 用户
/// </summary>
private long  _UserKey ;
/// <summary>
/// 用户
/// </summary>
public virtual long UserKey
{
get{
return _UserKey;
}
set{
 _UserKey= value;
}
}

public GetDeviceUseRecordBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "GetDeviceUseRecordBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._IsAppoint);
	this.invoker.ParamList.Add(this._PageIndex);
	this.invoker.ParamList.Add(this._PageSize);
	this.invoker.ParamList.Add(this._UserKey);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.DeviceUseExDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.DeviceUseExDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.DeviceUseExDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.DeviceUseExDTO Do()
	{
		 THU.LabSystemBE.Deploy.DeviceUseExDTO obj = ( THU.LabSystemBE.Deploy.DeviceUseExDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "IsAppoint" :
	this._IsAppoint = this.TransferValue<bool>(obj);
	break;
case "PageIndex" :
	this._PageIndex = this.TransferValue<int>(obj);
	break;
case "PageSize" :
	this._PageSize = this.TransferValue<int>(obj);
	break;
case "UserKey" :
	this._UserKey = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

