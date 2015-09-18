using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class AppointDeviceBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="2d799aaa-a7a8-4cb9-8d2c-6808e3b48081";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.AppointDeviceBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 设备号
/// </summary>
private long  _ID ;
/// <summary>
/// 设备号
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

/// <summary>
/// 开始时间
/// </summary>
private DateTime  _BeginTime ;
/// <summary>
/// 开始时间
/// </summary>
public virtual DateTime BeginTime
{
get{
return _BeginTime;
}
set{
 _BeginTime= value;
}
}

/// <summary>
/// 结束时间
/// </summary>
private DateTime  _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
public virtual DateTime EndTime
{
get{
return _EndTime;
}
set{
 _EndTime= value;
}
}

public AppointDeviceBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "AppointDeviceBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._ID);
	this.invoker.ParamList.Add(this._BeginTime);
	this.invoker.ParamList.Add(this._EndTime);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.DeviceUseRecordDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.DeviceUseRecordDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.DeviceUseRecordDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.DeviceUseRecordDTO Do()
	{
		 THU.LabSystemBE.Deploy.DeviceUseRecordDTO obj = ( THU.LabSystemBE.Deploy.DeviceUseRecordDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ID" :
	this._ID = this.TransferValue<long>(obj);
	break;
case "BeginTime" :
	this._BeginTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

