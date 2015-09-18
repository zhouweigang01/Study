using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class GetDeviceRepairReportBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="71cd2d6f-e081-4b70-93f6-69dcf2d699ff";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.GetDeviceRepairReportBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 设备KEY
/// </summary>
private long  _DeviceKey ;
/// <summary>
/// 设备KEY
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

/// <summary>
/// 层级
/// </summary>
private int  _Level ;
/// <summary>
/// 层级
/// </summary>
public virtual int Level
{
get{
return _Level;
}
set{
 _Level= value;
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
/// 开始时间
/// </summary>
private DateTime  _StartTime ;
/// <summary>
/// 开始时间
/// </summary>
public virtual DateTime StartTime
{
get{
return _StartTime;
}
set{
 _StartTime= value;
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

/// <summary>
/// 排序字段
/// </summary>
private string  _OrderField ;
/// <summary>
/// 排序字段
/// </summary>
public virtual string OrderField
{
get{
return _OrderField;
}
set{
 _OrderField= value;
}
}

public GetDeviceRepairReportBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "GetDeviceRepairReportBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._DeviceKey);
	this.invoker.ParamList.Add(this._Level);
	this.invoker.ParamList.Add(this._PageSize);
	this.invoker.ParamList.Add(this._PageIndex);
	this.invoker.ParamList.Add(this._StartTime);
	this.invoker.ParamList.Add(this._EndTime);
	this.invoker.ParamList.Add(this._OrderField);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.DeviceRepairReportExDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.DeviceRepairReportExDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.DeviceRepairReportExDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.DeviceRepairReportExDTO Do()
	{
		 THU.LabSystemBE.Deploy.DeviceRepairReportExDTO obj = ( THU.LabSystemBE.Deploy.DeviceRepairReportExDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "DeviceKey" :
	this._DeviceKey = this.TransferValue<long>(obj);
	break;
case "Level" :
	this._Level = this.TransferValue<int>(obj);
	break;
case "PageSize" :
	this._PageSize = this.TransferValue<int>(obj);
	break;
case "PageIndex" :
	this._PageIndex = this.TransferValue<int>(obj);
	break;
case "StartTime" :
	this._StartTime = this.TransferValue<DateTime>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
case "OrderField" :
	this._OrderField = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

