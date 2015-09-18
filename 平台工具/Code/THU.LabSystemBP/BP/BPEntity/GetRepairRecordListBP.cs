using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetRepairRecordListBP : NHExt.Runtime.Model.BizProxy
    {
		private string _guid ="c8d10e0f-b653-4fd8-877d-6d32ac5a3fbd";
		public override string Guid {
			get{
				return this._guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.GetRepairRecordListBP";
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
/// 是否已完成
/// </summary>
private bool ? _IsCompleted ;
/// <summary>
/// 是否已完成
/// </summary>
public virtual bool? IsCompleted
{
get{
return _IsCompleted;
}
set{
 _IsCompleted= value;
}
}

/// <summary>
/// 大小
/// </summary>
private int  _PageSize ;
/// <summary>
/// 大小
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
/// 用户key
/// </summary>
private long  _UserKey ;
/// <summary>
/// 用户key
/// </summary>
public virtual long UserKey
{
get{
return _UserKey;
}
set{
 _UserKey= value;
}
}

/// <summary>
/// 设备key
/// </summary>
private long  _DeviceKey ;
/// <summary>
/// 设备key
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

internal THU.LabSystemBE.Deploy.DeviceRepairExDTO Do()
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
private THU.LabSystemBE.Deploy.DeviceRepairExDTO DoCommon(NHExt.Runtime.Proxy.ProxyContext ctx)
{
	Exception errEx = null;
	try{
		using (NHExt.Runtime.Session.Transaction trans = NHExt.Runtime.Session.Transaction.New(NHExt.Runtime.Enums.TransactionSupport.Support, ctx.UseReadDB))
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

private THU.LabSystemBE.Deploy.DeviceRepairExDTO TypeConvert(THU.LabSystemBE.Deploy.DeviceRepairExDTO obj)
{

return obj;

}
protected override void InitParameter(NHExt.Runtime.Proxy.ProxyContext ctx){
	base.InitParameter(ctx);
	if(ctx != null){
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._IsCompleted = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<bool ?>(ctx.ParamList[0].ToString());
	ctx.ParamList[0] = this._IsCompleted;
}
else{
	if(ctx.ParamList.Count > 0){
	this._IsCompleted = (bool ?)ctx.ParamList[0];
	}else{
		ctx.ParamList.Add(this._IsCompleted);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._PageSize = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<int >(ctx.ParamList[1].ToString());
	ctx.ParamList[1] = this._PageSize;
}
else{
	if(ctx.ParamList.Count > 1){
	this._PageSize = (int )ctx.ParamList[1];
	}else{
		ctx.ParamList.Add(this._PageSize);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._PageIndex = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<int >(ctx.ParamList[2].ToString());
	ctx.ParamList[2] = this._PageIndex;
}
else{
	if(ctx.ParamList.Count > 2){
	this._PageIndex = (int )ctx.ParamList[2];
	}else{
		ctx.ParamList.Add(this._PageIndex);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._UserKey = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<long >(ctx.ParamList[3].ToString());
	ctx.ParamList[3] = this._UserKey;
}
else{
	if(ctx.ParamList.Count > 3){
	this._UserKey = (long )ctx.ParamList[3];
	}else{
		ctx.ParamList.Add(this._UserKey);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._DeviceKey = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<long >(ctx.ParamList[4].ToString());
	ctx.ParamList[4] = this._DeviceKey;
}
else{
	if(ctx.ParamList.Count > 4){
	this._DeviceKey = (long )ctx.ParamList[4];
	}else{
		ctx.ParamList.Add(this._DeviceKey);
	}
}
	}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "IsCompleted" :
	this._IsCompleted = this.TransferValue<bool?>(obj);
	break;
case "PageSize" :
	this._PageSize = this.TransferValue<int>(obj);
	break;
case "PageIndex" :
	this._PageIndex = this.TransferValue<int>(obj);
	break;
case "UserKey" :
	this._UserKey = this.TransferValue<long>(obj);
	break;
case "DeviceKey" :
	this._DeviceKey = this.TransferValue<long>(obj);
	break;
		default:
			base.SetValue(obj,memberName);
			break;
		}
	}

}
}
