using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class InsertTeacherBP : NHExt.Runtime.Model.BizProxy
    {
		private string _guid ="a5644821-0c25-4e48-9227-a4715a6d8a39";
		public override string Guid {
			get{
				return this._guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.InsertTeacherBP";
		public override string ProxyName{
			get{
				return this._proxyName;
			}
		}
		private NHExt.Runtime.Session.CallerTypeEnum _callerType = NHExt.Runtime.Session.CallerTypeEnum.Reflect;

        public override NHExt.Runtime.Session.CallerTypeEnum CallerType
        {
			get{
				 return this._callerType;
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
internal THU.LabSystemBE.Deploy.TeacherDTO Do()
{
    NHExt.Runtime.Proxy.ProxyContext ctx = new NHExt.Runtime.Proxy.ProxyContext();
    ctx.ProxyGuid = this._guid;
    return this.DoCommon(ctx);
}

internal void DoTask(bool autoRun = false)
{
	this._callerType = NHExt.Runtime.Session.CallerTypeEnum.Reflect;
	NHExt.Runtime.Proxy.ProxyContext ctx = new NHExt.Runtime.Proxy.ProxyContext();
    ctx.ProxyGuid = this._guid;
	NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger.Info("系统调度任务，使用线程调度服务");
    NHExt.Runtime.Proxy.TaskThreadPool.ThreadPool.AddThreadItem((state) =>
    {
        NHExt.Runtime.Proxy.ProxyContext pCtx = state as NHExt.Runtime.Proxy.ProxyContext;
		this.DoCommon(pCtx);
    }, ctx , autoRun);
}

public override object Do(NHExt.Runtime.Proxy.ProxyContext ctx)
{
	this._callerType = NHExt.Runtime.Session.CallerTypeEnum.Reflect;
	var obj = this.TypeConvert(this.DoCommon(ctx));
	return obj;
}

public override NHExt.Runtime.Model.WCFCallDTO DoWCF(NHExt.Runtime.Proxy.ProxyContext ctx)
{
	string xml = string.Empty;
	NHExt.Runtime.Model.WCFCallDTO callDTO = new NHExt.Runtime.Model.WCFCallDTO();
	try
	{
		this._callerType = NHExt.Runtime.Session.CallerTypeEnum.WCF;
		var obj = this.TypeConvert(this.DoCommon(ctx));
		if (obj != null) {
			xml = NHExt.Runtime.Serialize.XmlSerialize.Serialize(obj);
		}else{
			xml = string.Empty;
		}
		callDTO.Success = true;
	}
	catch(Exception ex){
		xml = ex.Message;
	}
	callDTO.Result = xml;
	return callDTO;
}
private THU.LabSystemBE.Deploy.TeacherDTO DoCommon(NHExt.Runtime.Proxy.ProxyContext ctx)
{
	Exception errEx = null;
	try{
		using (NHExt.Runtime.Session.Transaction trans = NHExt.Runtime.Session.Transaction.New(NHExt.Runtime.Enums.TransactionSupport.Required, ctx.UseReadDB))
		{
			List<NHExt.Runtime.AOP.IProxyAspect> aspectList = new List<NHExt.Runtime.AOP.IProxyAspect>();
			try
			{
				this.InitParameter(ctx);
				ctx.ProxyStack.Add(new NHExt.Runtime.Auth.ProxyProperty() { ProxyGuid = this.Guid, ProxyName = this.ProxyName });
				aspectList = NHExt.Runtime.AOP.AspectManager.BuildProxyAspect(this.ProxyName);
				foreach (NHExt.Runtime.AOP.IProxyAspect insector in aspectList)
				{
					insector.BeforeDo(this,ctx);
				}
				var obj = this.DoExtend();

				NHExt.Runtime.Session.Session.Current.Commit();
				 
				foreach (NHExt.Runtime.AOP.IProxyAspect insector in aspectList)
				{
					insector.AfterDo(this,obj);
				}
				trans.Commit();
				return obj;
			}
			catch (Exception ex)
			{
				errEx = ex;
				trans.RollBack();
				NHExt.Runtime.Logger.LoggerHelper.Error(ex, NHExt.Runtime.Logger.LoggerInstance.RuntimeLogger);
				throw ex;
			}
			finally{
				ctx.ProxyStack.RemoveAt(ctx.ProxyStack.Count -1);
			}
		}
	}
	catch(Exception err){
		if(errEx != null){
			throw errEx;
		}else{
			throw err;
		}
	}
}

private THU.LabSystemBE.Deploy.TeacherDTO TypeConvert(THU.LabSystemBE.Deploy.TeacherDTO obj)
{

return obj;

}
protected override void InitParameter(NHExt.Runtime.Proxy.ProxyContext ctx){
	base.InitParameter(ctx);
	if(ctx != null){
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._TeacherDTO = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<THU.LabSystemBE.Deploy.TeacherDTO >(ctx.ParamList[0].ToString());
	ctx.ParamList[0] = this._TeacherDTO;
}
else{
	if(ctx.ParamList.Count > 0){
	this._TeacherDTO = (THU.LabSystemBE.Deploy.TeacherDTO )ctx.ParamList[0];
	}else{
		ctx.ParamList.Add(this._TeacherDTO);
	}
}
	}
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
