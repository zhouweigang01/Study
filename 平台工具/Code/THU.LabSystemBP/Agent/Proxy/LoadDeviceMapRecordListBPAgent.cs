using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class LoadDeviceMapRecordListBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="afcbf8bb-f441-402f-8da9-ef42a56d523d";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.LoadDeviceMapRecordListBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 日期
/// </summary>
private DateTime  _Date ;
/// <summary>
/// 日期
/// </summary>
public virtual DateTime Date
{
get{
return _Date;
}
set{
 _Date= value;
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

public LoadDeviceMapRecordListBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "LoadDeviceMapRecordListBP";
}

 public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._Date);
	this.invoker.ParamList.Add(this._DeviceKey);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO>>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO>)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;
	}
	public List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> Do()
	{
		List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO> obj = (List<THU.LabSystemBE.Deploy.DeviceUseRecordDTO>)this.DoProxy();
		return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Date" :
	this._Date = this.TransferValue<DateTime>(obj);
	break;
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

