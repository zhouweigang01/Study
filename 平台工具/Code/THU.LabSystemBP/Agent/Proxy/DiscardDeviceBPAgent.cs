using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class DiscardDeviceBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="11c64da9-5519-4f35-b0ad-f10d5972bffb";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.DiscardDeviceBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 设备id
/// </summary>
private long  _ID ;
/// <summary>
/// 设备id
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

public DiscardDeviceBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "DiscardDeviceBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._ID);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	bool result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<bool>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (bool)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public bool Do()
	{
		 bool obj = ( bool)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
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

