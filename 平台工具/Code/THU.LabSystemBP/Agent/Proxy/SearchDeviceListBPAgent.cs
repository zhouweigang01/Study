using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class SearchDeviceListBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="c95eb1ec-df50-4168-a3bd-101422255242";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.SearchDeviceListBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 查询属性
/// </summary>
private List<string> _AttrubuteList ;
/// <summary>
/// 查询属性
/// </summary>
public virtual List<string> AttrubuteList
{
get{
return _AttrubuteList;
}
set{
 _AttrubuteList= value;
}
}

/// <summary>
/// 查询字段
/// </summary>
private string  _SearchTxt ;
/// <summary>
/// 查询字段
/// </summary>
public virtual string SearchTxt
{
get{
return _SearchTxt;
}
set{
 _SearchTxt= value;
}
}

public SearchDeviceListBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "SearchDeviceListBP";
}

 public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._AttrubuteList);
	this.invoker.ParamList.Add(this._SearchTxt);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	List<THU.LabSystemBE.Deploy.DeviceDTO> result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<List<THU.LabSystemBE.Deploy.DeviceDTO>>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (List<THU.LabSystemBE.Deploy.DeviceDTO>)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;
	}
	public List<THU.LabSystemBE.Deploy.DeviceDTO> Do()
	{
		List<THU.LabSystemBE.Deploy.DeviceDTO> obj = (List<THU.LabSystemBE.Deploy.DeviceDTO>)this.DoProxy();
		return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "AttrubuteList" :
	this._AttrubuteList = this.TransferValue<List<string> >(obj);
	break;
case "SearchTxt" :
	this._SearchTxt = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

