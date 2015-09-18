using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class ValidateAdminUserBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="7ea9a330-aadc-49e9-ab63-a411a3783fba";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.ValidateAdminUserBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 编码
/// </summary>
private string  _Code ;
/// <summary>
/// 编码
/// </summary>
public virtual string Code
{
get{
return _Code;
}
set{
 _Code= value;
}
}

/// <summary>
/// 密码
/// </summary>
private string  _Password ;
/// <summary>
/// 密码
/// </summary>
public virtual string Password
{
get{
return _Password;
}
set{
 _Password= value;
}
}

/// <summary>
/// 组织
/// </summary>
private string  _Org ;
/// <summary>
/// 组织
/// </summary>
public virtual string Org
{
get{
return _Org;
}
set{
 _Org= value;
}
}

public ValidateAdminUserBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "ValidateAdminUserBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._Code);
	this.invoker.ParamList.Add(this._Password);
	this.invoker.ParamList.Add(this._Org);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.UserDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.UserDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.UserDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.UserDTO Do()
	{
		 THU.LabSystemBE.Deploy.UserDTO obj = ( THU.LabSystemBE.Deploy.UserDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "Code" :
	this._Code = this.TransferValue<string>(obj);
	break;
case "Password" :
	this._Password = this.TransferValue<string>(obj);
	break;
case "Org" :
	this._Org = this.TransferValue<string>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

