using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.DeviceUseRecord",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_DEVICE_USE_RECORD")]
public partial class DeviceUseRecord : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<DeviceUseRecord> _key;
  public new virtual EntityKey<DeviceUseRecord> Key
   {
      get
    {
       return this.GetEntityKey<DeviceUseRecord>(ref _key);
  }
  }
  public static new string Guid ="574aa9bc-55a0-464b-9507-0f66c4207a9d";
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
  public static new DeviceUseRecord Create(){
		return Create(true);
  }
  private static DeviceUseRecord Create(bool inList){
  	DeviceUseRecord entity = new DeviceUseRecord();
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
	public new virtual DeviceUseRecord OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as DeviceUseRecord;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<DeviceUseRecord> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<DeviceUseRecord>(hql ,paramList,startIndex ,recordCount);
	}
	public static DeviceUseRecord Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<DeviceUseRecord>(hql ,paramList,startIndex);
	}
	public static DeviceUseRecord FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<DeviceUseRecord>(id);
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

public DeviceUseRecord():base()
 {
  this._entityName = "THU.LabSystemBE.DeviceUseRecord";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	DeviceUseRecord cloneObj = new DeviceUseRecord();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(DeviceUseRecord cloneObj) {
    base.Clone(cloneObj);




if(this.Device != null){
	cloneObj.Device = new THU.LabSystemBE.DeviceMap();
	cloneObj.Device.ID = this.Device.ID;
}else{
	cloneObj.Device = null;
}



cloneObj.BeginTime = this.BeginTime;


cloneObj.EndTime = this.EndTime;


cloneObj.Fee = this.Fee;


if(this.User != null){
	cloneObj.User = new THU.LabSystemBE.User();
	cloneObj.User.ID = this.User.ID;
}else{
	cloneObj.User = null;
}



cloneObj.IsAppoint = this.IsAppoint;


if(this.Teacher != null){
	cloneObj.Teacher = new THU.LabSystemBE.Teacher();
	cloneObj.Teacher.ID = this.Teacher.ID;
}else{
	cloneObj.Teacher = null;
}



cloneObj.IsCompleted = this.IsCompleted;


if(this.House != null){
	cloneObj.House = new THU.LabSystemBE.CommonEnum();
	cloneObj.House.ID = this.House.ID;
}else{
	cloneObj.House = null;
}



cloneObj.IsUsing = this.IsUsing;


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
/// 开始时间
/// </summary>
//private DateTime  _BeginTime ;
/// <summary>
/// 开始时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="BeginTime",Description = "开始时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual DateTime BeginTime
{
get{
 return this.GetValue<DateTime>("BeginTime");
}
set{
this.SetValue<DateTime>("BeginTime", value);}
}

/// <summary>
/// 结束时间
/// </summary>
//private DateTime ? _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "结束时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? EndTime
{
get{
 return this.GetValue<DateTime?>("EndTime");
}
set{
this.SetValue<DateTime?>("EndTime", value);}
}

/// <summary>
/// 使用费用
/// </summary>
//private decimal  _Fee ;
/// <summary>
/// 使用费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fee",Description = "使用费用",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual decimal Fee
{
get{
 return this.GetValue<decimal>("Fee");
}
set{
this.SetValue<decimal>("Fee", value);}
}

/// <summary>
/// 使用者
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.User")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "使用者",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual THU.LabSystemBE.User User
{
get{
 return this.GetRefrence<THU.LabSystemBE.User>("User");
}
set{
 this.SetRefrence<THU.LabSystemBE.User>("User",value);
}
}
/// <summary>
/// 使用者实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.User> UserKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.User>("User");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.User>("User",value);
  }
}

/// <summary>
/// 是否预约
/// </summary>
//private bool  _IsAppoint ;
/// <summary>
/// 是否预约
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsAppoint",Description = "是否预约",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool IsAppoint
{
get{
 return this.GetValue<bool>("IsAppoint");
}
set{
this.SetValue<bool>("IsAppoint", value);}
}

/// <summary>
/// 关联导师
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.Teacher")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Teacher",Description = "关联导师",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.Teacher Teacher
{
get{
 return this.GetRefrence<THU.LabSystemBE.Teacher>("Teacher");
}
set{
 this.SetRefrence<THU.LabSystemBE.Teacher>("Teacher",value);
}
}
/// <summary>
/// 关联导师实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.Teacher> TeacherKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.Teacher>("Teacher");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.Teacher>("Teacher",value);
  }
}

/// <summary>
/// 是否完成
/// </summary>
//private bool  _IsCompleted ;
/// <summary>
/// 是否完成
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsCompleted",Description = "是否完成",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool IsCompleted
{
get{
 return this.GetValue<bool>("IsCompleted");
}
set{
this.SetValue<bool>("IsCompleted", value);}
}

/// <summary>
/// 所属房间
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="House",Description = "所属房间",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.CommonEnum House
{
get{
 return this.GetRefrence<THU.LabSystemBE.CommonEnum>("House");
}
set{
 this.SetRefrence<THU.LabSystemBE.CommonEnum>("House",value);
}
}
/// <summary>
/// 所属房间实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.CommonEnum> HouseKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.CommonEnum>("House");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.CommonEnum>("House",value);
  }
}

/// <summary>
/// 是否正在使用
/// </summary>
//private bool  _IsUsing ;
/// <summary>
/// 是否正在使用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsUsing",Description = "是否正在使用",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool IsUsing
{
get{
 return this.GetValue<bool>("IsUsing");
}
set{
this.SetValue<bool>("IsUsing", value);}
}

 public new virtual THU.LabSystemBE.Deploy.DeviceUseRecordDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.DeviceUseRecordDTO dto = new THU.LabSystemBE.Deploy.DeviceUseRecordDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.DeviceUseRecordDTO dto)
	{
		  base.ToDTO(dto);
		if (this.DeviceKey != null)
		{
			dto.Device = this.DeviceKey.ID;
		}

		dto.BeginTime = this.BeginTime;

		dto.EndTime = this.EndTime;

		dto.Fee = this.Fee;

		if (this.UserKey != null)
		{
			dto.User = this.UserKey.ID;
		}

		dto.IsAppoint = this.IsAppoint;

		if (this.TeacherKey != null)
		{
			dto.Teacher = this.TeacherKey.ID;
		}

		dto.IsCompleted = this.IsCompleted;

		if (this.HouseKey != null)
		{
			dto.House = this.HouseKey.ID;
		}

		dto.IsUsing = this.IsUsing;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceUseRecordDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceUseRecordDTO dto , THU.LabSystemBE.DeviceUseRecord entity){
		base.FromDTO(dto,entity);

		if(dto.Device <=0){
			entity.DeviceKey = null;
		}
		else {
			entity.DeviceKey = new EntityKey<THU.LabSystemBE.DeviceMap>(dto.Device);
		}

		entity.BeginTime = dto.BeginTime;

		entity.EndTime = dto.EndTime;

		entity.Fee = dto.Fee;

		if(dto.User <=0){
			entity.UserKey = null;
		}
		else {
			entity.UserKey = new EntityKey<THU.LabSystemBE.User>(dto.User);
		}

		entity.IsAppoint = dto.IsAppoint;

		if(dto.Teacher <=0){
			entity.TeacherKey = null;
		}
		else {
			entity.TeacherKey = new EntityKey<THU.LabSystemBE.Teacher>(dto.Teacher);
		}

		entity.IsCompleted = dto.IsCompleted;

		if(dto.House <=0){
			entity.HouseKey = null;
		}
		else {
			entity.HouseKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.House);
		}

		entity.IsUsing = dto.IsUsing;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

