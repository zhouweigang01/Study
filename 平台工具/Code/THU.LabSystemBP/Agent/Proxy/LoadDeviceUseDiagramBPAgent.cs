using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class LoadDeviceUseDiagramBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="d8db2c58-1137-4828-865a-d9b39c4e1646";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.LoadDeviceUseDiagramBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 年
/// </summary>
private int  _Year ;
/// <summary>
/// 年
/// </summary>
public virtual int Year
{
get{
return _Year;
}
set{
 _Year= value;
}
}

/// <summary>
/// 月
/// </summary>
private int  _Month ;
/// <summary>
/// 月
/// </summary>
public virtual int Month
{
get{
return _Month;
}
set{
 _Month= value;
}
}

/// <summary>
/// 是否预约
/// </summary>
private bool  _IsAppoint ;
/// <summary>
/// 是否预约
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

public LoadDeviceUseDiagramBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "LoadDeviceUseDiagramBP";
}

 public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._Year);
	this.invoker.ParamList.Add(this._Month);
	this.invoker.ParamList.Add(this._IsAppoint);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO> result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO>>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO>)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;
	}
	public List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO> Do()
	{
		List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO> obj = (List<THU.LabSystemBE.Deploy.DeviceUseDiagramDTO>)this.DoProxy();
		return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Year" :
	this._Year = this.TransferValue<int>(obj);
	break;
case "Month" :
	this._Month = this.TransferValue<int>(obj);
	break;
case "IsAppoint" :
	this._IsAppoint = this.TransferValue<bool>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

