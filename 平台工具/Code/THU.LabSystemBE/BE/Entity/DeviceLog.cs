using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.DeviceLog",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_DEVICE_LOG")]
public partial class DeviceLog : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<DeviceLog> _key;
  public new virtual EntityKey<DeviceLog> Key
   {
      get
    {
       return this.GetEntityKey<DeviceLog>(ref _key);
  }
  }
  public static new string Guid ="e0c346db-c277-445e-82cd-c26df5879cb0";
  ///是否多组织数据处理
   public override NHExt.Runtime.Enums.ViewRangeEnum Range
        {
            get
            {
                return NHExt.Runtime.Enums.ViewRangeEnum.UPPER;
            }
        }
  ///数据是否按照根组织进行过滤
  public override bool OrgFilter {
	get{
		return true;
	}
  }

/// <summary>
/// 生成实体默认创建代码
/// </summary>
  public static new DeviceLog Create(){
		return Create(true);
  }
  private static DeviceLog Create(bool inList){
  	DeviceLog entity = new DeviceLog();
    entity.ID = NHExt.Runtime.Util.EntityGuidHelper.New();
    entity.EntityState = NHExt.Runtime.Enums.EntityState.Add;
	if(inList){
		if(Session.Current != null){
			Session.Current.InList(entity);
		}
	}
	return entity;
  }
	/// <summary>
	/// 实体私有数据，记录上次提交缓存之前的数据，只有在实体内部可用
	/// </summary>
	public new virtual DeviceLog OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as DeviceLog;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<DeviceLog> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<DeviceLog>(hql ,paramList,startIndex ,recordCount);
	}
	public static DeviceLog Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<DeviceLog>(hql ,paramList,startIndex);
	}
	public static DeviceLog FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<DeviceLog>(id);
	} 
}
#endregion 

#region CRUD相关操作
 protected override void SetDefaultValue()
{
   this.OnSetDefaultValue();
   base.SetDefaultValue();
 }
 protected override void Validate()
{
  this.OnValidate();
  base.Validate();
 }
 protected override void Inserting()
{
  this.OnInserting();
  base.Inserting();
}
 protected override void Inserted()
{
    this.OnInserted();
	base.Inserted();
}
protected override void Updating()
{
   this.OnUpdating();
   base.Updating();
 }
protected override void Updated()
{
   this.OnUpdated();
   base.Updated();
}
protected override void Deleting()
{
    this.OnDeleting();
	base.Deleting();
 }
protected override void Deleted()
{
   this.OnDeleted();
   base.Deleted();
}

#endregion

public DeviceLog():base()
 {
  this._entityName = "THU.LabSystemBE.DeviceLog";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	DeviceLog cloneObj = new DeviceLog();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(DeviceLog cloneObj) {
    base.Clone(cloneObj);




if(this.Device != null){
	cloneObj.Device = new THU.LabSystemBE.DeviceMap();
	cloneObj.Device.ID = this.Device.ID;
}else{
	cloneObj.Device = null;
}



if(this.Operator != null){
	cloneObj.Operator = new THU.LabSystemBE.User();
	cloneObj.Operator.ID = this.Operator.ID;
}else{
	cloneObj.Operator = null;
}



if(this.Status != null){
	cloneObj.Status = new THU.LabSystemBE.DeviceStatusEnum();
	cloneObj.Status.EnumValue = this.Status.EnumValue;
	cloneObj.Status.Code = this.Status.Code;
	cloneObj.Status.Name = this.Status.Name;
}else{
	cloneObj.Status = null;
}

}

/// <summary>
/// 关联设备
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.DeviceMap")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Device",Description = "关联设备",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.DeviceMap Device
{
get{
 return this.GetRefrence<THU.LabSystemBE.DeviceMap>("Device");
}
set{
 this.SetRefrence<THU.LabSystemBE.DeviceMap>("Device",value);
}
}
/// <summary>
/// 关联设备实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.DeviceMap> DeviceKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.DeviceMap>("Device");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.DeviceMap>("Device",value);
  }
}

/// <summary>
/// 操作人
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.User")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Operator",Description = "操作人",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.User Operator
{
get{
 return this.GetRefrence<THU.LabSystemBE.User>("Operator");
}
set{
 this.SetRefrence<THU.LabSystemBE.User>("Operator",value);
}
}
/// <summary>
/// 操作人实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.User> OperatorKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.User>("Operator");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.User>("Operator",value);
  }
}

/// <summary>
/// 设备状态
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.DeviceStatusEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Status",Description = "设备状态",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.DeviceStatusEnum Status
{
get{
  return this.GetEnum<THU.LabSystemBE.DeviceStatusEnum>("Status");
}
set{
  this.SetEnum<THU.LabSystemBE.DeviceStatusEnum>("Status",value);
	}
}
 public new virtual THU.LabSystemBE.Deploy.DeviceLogDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.DeviceLogDTO dto = new THU.LabSystemBE.Deploy.DeviceLogDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.DeviceLogDTO dto)
	{
		  base.ToDTO(dto);
		if (this.DeviceKey != null)
		{
			dto.Device = this.DeviceKey.ID;
		}

		if (this.OperatorKey != null)
		{
			dto.Operator = this.OperatorKey.ID;
		}

		if (this.Status != null)
        {
           dto.Status = this.Status.EnumValue;
        }
	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceLogDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceLogDTO dto , THU.LabSystemBE.DeviceLog entity){
		base.FromDTO(dto,entity);

		if(dto.Device <=0){
			entity.DeviceKey = null;
		}
		else {
			entity.DeviceKey = new EntityKey<THU.LabSystemBE.DeviceMap>(dto.Device);
		}

		if(dto.Operator <=0){
			entity.OperatorKey = null;
		}
		else {
			entity.OperatorKey = new EntityKey<THU.LabSystemBE.User>(dto.Operator);
		}

		if(dto.Status > 0)
		{
			entity.Status=(THU.LabSystemBE.DeviceStatusEnum)dto.Status;
		}

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

