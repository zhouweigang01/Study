using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class GetAllDeviceMapBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="119c272b-c053-4ff6-b533-274c1be1bcbf";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.GetAllDeviceMapBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 页大小
/// </summary>
private int  _PageSize ;
/// <summary>
/// 页大小
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
/// 也数量
/// </summary>
private int  _PageIndex ;
/// <summary>
/// 也数量
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
/// 使用状态
/// </summary>
private int  _UseStatus ;
/// <summary>
/// 使用状态
/// </summary>
public virtual int UseStatus
{
get{
return _UseStatus;
}
set{
 _UseStatus= value;
}
}

/// <summary>
/// 设备状态
/// </summary>
private int  _DeviceStatus ;
/// <summary>
/// 设备状态
/// </summary>
public virtual int DeviceStatus
{
get{
return _DeviceStatus;
}
set{
 _DeviceStatus= value;
}
}

public GetAllDeviceMapBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "GetAllDeviceMapBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._PageSize);
	this.invoker.ParamList.Add(this._PageIndex);
	this.invoker.ParamList.Add(this._UseStatus);
	this.invoker.ParamList.Add(this._DeviceStatus);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.DeviceMapExDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.DeviceMapExDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.DeviceMapExDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.DeviceMapExDTO Do()
	{
		 THU.LabSystemBE.Deploy.DeviceMapExDTO obj = ( THU.LabSystemBE.Deploy.DeviceMapExDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "PageSize" :
	this._PageSize = this.TransferValue<int>(obj);
	break;
case "PageIndex" :
	this._PageIndex = this.TransferValue<int>(obj);
	break;
case "UseStatus" :
	this._UseStatus = this.TransferValue<int>(obj);
	break;
case "DeviceStatus" :
	this._DeviceStatus = this.TransferValue<int>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

