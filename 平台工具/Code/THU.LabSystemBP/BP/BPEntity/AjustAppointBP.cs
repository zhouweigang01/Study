using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class AjustAppointBP : NHExt.Runtime.Model.BizProxy
    {
		private string _guid ="7af5e2f6-f0fd-46a8-80e7-afedc767b019";
		public override string Guid {
			get{
				return this._guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.AjustAppointBP";
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
/// 预约记录
/// </summary>
private long  _ID ;
/// <summary>
/// 预约记录
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

internal bool Do()
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
private bool DoCommon(NHExt.Runtime.Proxy.ProxyContext ctx)
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

private bool TypeConvert(bool obj)
{

return obj;

}
protected override void InitParameter(NHExt.Runtime.Proxy.ProxyContext ctx){
	base.InitParameter(ctx);
	if(ctx != null){
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._ID = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<long >(ctx.ParamList[0].ToString());
	ctx.ParamList[0] = this._ID;
}
else{
	if(ctx.ParamList.Count > 0){
	this._ID = (long )ctx.ParamList[0];
	}else{
		ctx.ParamList.Add(this._ID);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._EndTime = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<DateTime >(ctx.ParamList[1].ToString());
	ctx.ParamList[1] = this._EndTime;
}
else{
	if(ctx.ParamList.Count > 1){
	this._EndTime = (DateTime )ctx.ParamList[1];
	}else{
		ctx.ParamList.Add(this._EndTime);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._BeginTime = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<DateTime >(ctx.ParamList[2].ToString());
	ctx.ParamList[2] = this._BeginTime;
}
else{
	if(ctx.ParamList.Count > 2){
	this._BeginTime = (DateTime )ctx.ParamList[2];
	}else{
		ctx.ParamList.Add(this._BeginTime);
	}
}
	}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "ID" :
	this._ID = this.TransferValue<long>(obj);
	break;
case "EndTime" :
	this._EndTime = this.TransferValue<DateTime>(obj);
	break;
case "BeginTime" :
	this._BeginTime = this.TransferValue<DateTime>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

}
}
