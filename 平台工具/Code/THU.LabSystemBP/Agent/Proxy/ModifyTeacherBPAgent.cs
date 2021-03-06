using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP.Agent
{
    public partial class ModifyTeacherBPProxy : NHExt.Runtime.Model.BizAgent
    {
		private string _guid ="514c1255-0d57-4bd1-9924-3150b9a28c0c";
		public override string Guid {
			get{
				return _guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.Agent.ModifyTeacherBPProxy";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}

/// <summary>
/// 教师信息DTO
/// </summary>
private THU.LabSystemBE.Deploy.TeacherDTO  _TeacherDTO ;
/// <summary>
/// 教师信息DTO
/// </summary>
public virtual THU.LabSystemBE.Deploy.TeacherDTO TeacherDTO
{
get{
return _TeacherDTO;
}
set{
 _TeacherDTO= value;
}
}
public ModifyTeacherBPProxy()
{
	this.invoker.RemoteIP = this.RemoteIP;
	this.invoker.DllName = "THU.LabSystemBP.dll";
    this.invoker.NS = "THU.LabSystemBP";
    this.invoker.ProxyName = "ModifyTeacherBP";
}

public override object DoProxy()
{
	this.invoker.SourcePage = this.SourcePage;
	this.invoker.ParamList.Add(this._TeacherDTO);
	List<NHExt.Runtime.AOP.IAgentAspect> aspectList = NHExt.Runtime.AOP.AspectManager.BuildAgentAspect(this.ProxyName);
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList) {
		aspect.BeforeDo(this,invoker.ParamList);
	}
	object obj = this.invoker.Do();
	THU.LabSystemBE.Deploy.TeacherDTO result;
	if (this.invoker.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF)
	{
		string xml = string.Empty;
		if(obj != null){
			xml = obj.ToString();
		}
		NHExt.Runtime.Logger.LoggerHelper.Info("远程wcf返回数据为:" + xml, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
		try{
			result = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.TeacherDTO>(xml);
		}
		catch(Exception ex){
			NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
			throw ex;
		}
	}
	else
	{
		result= (THU.LabSystemBE.Deploy.TeacherDTO)obj;
	}
	foreach (NHExt.Runtime.AOP.IAgentAspect aspect in aspectList)
	{
		aspect.AfterDo(this,result);
	}
	return result;


	}
	public THU.LabSystemBE.Deploy.TeacherDTO Do()
	{
		 THU.LabSystemBE.Deploy.TeacherDTO obj = ( THU.LabSystemBE.Deploy.TeacherDTO)this.DoProxy();
		 return obj;
	}

	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "TeacherDTO" :
	this._TeacherDTO = this.TransferValue<THU.LabSystemBE.Deploy.TeacherDTO>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

 
    }
}

