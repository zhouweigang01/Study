using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace THU.LabSystemBP
{
    public partial class GetDeviceUseReportBP : NHExt.Runtime.Model.BizProxy
    {
		private string _guid ="88d0efa6-9ee0-4985-a484-cc62aca6f62c";
		public override string Guid {
			get{
				return this._guid;
			}
		}
		private string _proxyName = "THU.LabSystemBP.GetDeviceUseReportBP";
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
/// 导师
/// </summary>
private long  _TeacherKey ;
/// <summary>
/// 导师
/// </summary>
public virtual long TeacherKey
{
get{
return _TeacherKey;
}
set{
 _TeacherKey= value;
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
/// 页数量
/// </summary>
private int  _PageIndex ;
/// <summary>
/// 页数量
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

internal THU.LabSystemBE.Deploy.DeviceUseReportExDTO Do()
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
private THU.LabSystemBE.Deploy.DeviceUseReportExDTO DoCommon(NHExt.Runtime.Proxy.ProxyContext ctx)
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

private THU.LabSystemBE.Deploy.DeviceUseReportExDTO TypeConvert(THU.LabSystemBE.Deploy.DeviceUseReportExDTO obj)
{

return obj;

}
protected override void InitParameter(NHExt.Runtime.Proxy.ProxyContext ctx){
	base.InitParameter(ctx);
	if(ctx != null){
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._TeacherKey = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<long >(ctx.ParamList[0].ToString());
	ctx.ParamList[0] = this._TeacherKey;
}
else{
	if(ctx.ParamList.Count > 0){
	this._TeacherKey = (long )ctx.ParamList[0];
	}else{
		ctx.ParamList.Add(this._TeacherKey);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._Level = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<int >(ctx.ParamList[1].ToString());
	ctx.ParamList[1] = this._Level;
}
else{
	if(ctx.ParamList.Count > 1){
	this._Level = (int )ctx.ParamList[1];
	}else{
		ctx.ParamList.Add(this._Level);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._PageSize = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<int >(ctx.ParamList[2].ToString());
	ctx.ParamList[2] = this._PageSize;
}
else{
	if(ctx.ParamList.Count > 2){
	this._PageSize = (int )ctx.ParamList[2];
	}else{
		ctx.ParamList.Add(this._PageSize);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._PageIndex = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<int >(ctx.ParamList[3].ToString());
	ctx.ParamList[3] = this._PageIndex;
}
else{
	if(ctx.ParamList.Count > 3){
	this._PageIndex = (int )ctx.ParamList[3];
	}else{
		ctx.ParamList.Add(this._PageIndex);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._StartTime = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<DateTime >(ctx.ParamList[4].ToString());
	ctx.ParamList[4] = this._StartTime;
}
else{
	if(ctx.ParamList.Count > 4){
	this._StartTime = (DateTime )ctx.ParamList[4];
	}else{
		ctx.ParamList.Add(this._StartTime);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._EndTime = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<DateTime >(ctx.ParamList[5].ToString());
	ctx.ParamList[5] = this._EndTime;
}
else{
	if(ctx.ParamList.Count > 5){
	this._EndTime = (DateTime )ctx.ParamList[5];
	}else{
		ctx.ParamList.Add(this._EndTime);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._OrderField = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<string >(ctx.ParamList[6].ToString());
	ctx.ParamList[6] = this._OrderField;
}
else{
	if(ctx.ParamList.Count > 6){
	this._OrderField = (string )ctx.ParamList[6];
	}else{
		ctx.ParamList.Add(this._OrderField);
	}
}
if(this.CallerType == NHExt.Runtime.Session.CallerTypeEnum.WCF){
	this._DeviceKey = NHExt.Runtime.Serialize.XmlSerialize.DeSerialize<long >(ctx.ParamList[7].ToString());
	ctx.ParamList[7] = this._DeviceKey;
}
else{
	if(ctx.ParamList.Count > 7){
	this._DeviceKey = (long )ctx.ParamList[7];
	}else{
		ctx.ParamList.Add(this._DeviceKey);
	}
}
	}
}
	public override void SetValue(object obj, string memberName)
	{
		switch(memberName){
case "TeacherKey" :
	this._TeacherKey = this.TransferValue<long>(obj);
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
