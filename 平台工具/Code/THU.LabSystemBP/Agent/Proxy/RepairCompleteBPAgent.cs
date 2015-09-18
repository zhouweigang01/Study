using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class RepairCompleteBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="36d07414-c958-4193-bdb8-7ecc9864c0a8";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.RepairCompleteBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 设备地图id
/// </summary>
private long  _ID ;
/// <summary>
/// 设备地图id
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
/// 维修费用
/// </summary>
private decimal  _Fee ;
/// <summary>
/// 维修费用
/// </summary>
public virtual decimal Fee
{
get{
return _Fee;
}
set{
 _Fee= value;
}
}

/// <summary>
/// 备注
/// </summary>
private string  _Memo ;
/// <summary>
/// 备注
/// </summary>
public virtual string Memo
{
get{
return _Memo;
}
set{
 _Memo= value;
}
}

public RepairCompleteBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "RepairCompleteBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._ID);
	this.invoker.ParamList.Add(this._Fee);
	this.invoker.ParamList.Add(this._Memo);
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
case "Fee" :
	this._Fee = this.TransferValue<decimal>(obj);
	break;
case "Memo" :
	this._Memo = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

