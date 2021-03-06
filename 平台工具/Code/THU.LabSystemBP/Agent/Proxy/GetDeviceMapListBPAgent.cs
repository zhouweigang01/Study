using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class GetDeviceMapListBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="3b5e22f1-cb7b-4c53-af40-b9689c7e1dd4";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.GetDeviceMapListBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 设备key
/// </summary>
private long  _DeviceKey ;
/// <summary>
/// 设备key
/// </summary>
public virtual long DeviceKey
{
get{
return _DeviceKey;
}
set{
 _DeviceKey= value;
}
}

public GetDeviceMapListBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "GetDeviceMapListBP";
}

 public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._DeviceKey);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	List<THU.LabSystemBE.Deploy.DeviceMapDTO> result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<List<THU.LabSystemBE.Deploy.DeviceMapDTO>>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (List<THU.LabSystemBE.Deploy.DeviceMapDTO>)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;
	}
	public List<THU.LabSystemBE.Deploy.DeviceMapDTO> Do()
	{
		List<THU.LabSystemBE.Deploy.DeviceMapDTO> obj = (List<THU.LabSystemBE.Deploy.DeviceMapDTO>)this.DoProxy();
		return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "DeviceKey" :
	this._DeviceKey = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

