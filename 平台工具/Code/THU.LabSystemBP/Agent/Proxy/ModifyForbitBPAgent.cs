using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class ModifyForbitBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="4b09ae96-0be1-474e-b8af-9efaaf673ef3";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.ModifyForbitBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 惩罚记录DTO
/// </summary>
private THU.LabSystemBE.Deploy.ForbidUserDTO  _ForbitDTO ;
/// <summary>
/// 惩罚记录DTO
/// </summary>
public virtual THU.LabSystemBE.Deploy.ForbidUserDTO ForbitDTO
{
get{
return _ForbitDTO;
}
set{
 _ForbitDTO= value;
}
}
public ModifyForbitBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "ModifyForbitBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._ForbitDTO);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.ForbidUserDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.ForbidUserDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.ForbidUserDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.ForbidUserDTO Do()
	{
		 THU.LabSystemBE.Deploy.ForbidUserDTO obj = ( THU.LabSystemBE.Deploy.ForbidUserDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ForbitDTO" :
	this._ForbitDTO = this.TransferValue<THU.LabSystemBE.Deploy.ForbidUserDTO>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

