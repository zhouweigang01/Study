using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.DeviceRepairRecord",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_DEVICE_REPAIR_RECORD")]
public partial class DeviceRepairRecord : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<DeviceRepairRecord> _key;
  public new virtual EntityKey<DeviceRepairRecord> Key
   {
      get
    {
       return this.GetEntityKey<DeviceRepairRecord>(ref _key);
  }
  }
  public static new string Guid ="de992b7d-abd9-4215-b486-c36f49458b97";
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
  public static new DeviceRepairRecord Create(){
		return Create(true);
  }
  private static DeviceRepairRecord Create(bool inList){
  	DeviceRepairRecord entity = new DeviceRepairRecord();
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
	public new virtual DeviceRepairRecord OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as DeviceRepairRecord;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<DeviceRepairRecord> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<DeviceRepairRecord>(hql ,paramList,startIndex ,recordCount);
	}
	public static DeviceRepairRecord Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<DeviceRepairRecord>(hql ,paramList,startIndex);
	}
	public static DeviceRepairRecord FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<DeviceRepairRecord>(id);
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

public DeviceRepairRecord():base()
 {
  this._entityName = "THU.LabSystemBE.DeviceRepairRecord";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	DeviceRepairRecord cloneObj = new DeviceRepairRecord();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(DeviceRepairRecord cloneObj) {
    base.Clone(cloneObj);




if(this.Device != null){
	cloneObj.Device = new THU.LabSystemBE.DeviceMap();
	cloneObj.Device.ID = this.Device.ID;
}else{
	cloneObj.Device = null;
}



if(this.User != null){
	cloneObj.User = new THU.LabSystemBE.User();
	cloneObj.User.ID = this.User.ID;
}else{
	cloneObj.User = null;
}



if(this.Teacher != null){
	cloneObj.Teacher = new THU.LabSystemBE.Teacher();
	cloneObj.Teacher.ID = this.Teacher.ID;
}else{
	cloneObj.Teacher = null;
}



cloneObj.ReportDate = this.ReportDate;


cloneObj.IsCompleted = this.IsCompleted;


cloneObj.CompleteDate = this.CompleteDate;


if(this.CompleteUser != null){
	cloneObj.CompleteUser = new THU.LabSystemBE.User();
	cloneObj.CompleteUser.ID = this.CompleteUser.ID;
}else{
	cloneObj.CompleteUser = null;
}



cloneObj.Fee = this.Fee;


cloneObj.ReportMemo = this.ReportMemo;


cloneObj.RepairDate = this.RepairDate;


cloneObj.AlarmUser = this.AlarmUser;


if(this.House != null){
	cloneObj.House = new THU.LabSystemBE.CommonEnum();
	cloneObj.House.ID = this.House.ID;
}else{
	cloneObj.House = null;
}



}

/// <summary>
/// 设备
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.DeviceMap")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Device",Description = "设备",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
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
/// 设备实体Key
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
/// 报修人
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.User")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "报修人",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
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
/// 报修人实体Key
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
/// 导师
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.Teacher")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Teacher",Description = "导师",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
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
/// 导师实体Key
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
/// 报告日期
/// </summary>
//private DateTime  _ReportDate ;
/// <summary>
/// 报告日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ReportDate",Description = "报告日期",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual DateTime ReportDate
{
get{
 return this.GetValue<DateTime>("ReportDate");
}
set{
this.SetValue<DateTime>("ReportDate", value);}
}

/// <summary>
/// 是否已经处理
/// </summary>
//private bool  _IsCompleted ;
/// <summary>
/// 是否已经处理
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsCompleted",Description = "是否已经处理",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool IsCompleted
{
get{
 return this.GetValue<bool>("IsCompleted");
}
set{
this.SetValue<bool>("IsCompleted", value);}
}

/// <summary>
/// 完成时间
/// </summary>
//private DateTime ? _CompleteDate ;
/// <summary>
/// 完成时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CompleteDate",Description = "完成时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? CompleteDate
{
get{
 return this.GetValue<DateTime?>("CompleteDate");
}
set{
this.SetValue<DateTime?>("CompleteDate", value);}
}

/// <summary>
/// 处理人
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.User")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CompleteUser",Description = "处理人",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual THU.LabSystemBE.User CompleteUser
{
get{
 return this.GetRefrence<THU.LabSystemBE.User>("CompleteUser");
}
set{
 this.SetRefrence<THU.LabSystemBE.User>("CompleteUser",value);
}
}
/// <summary>
/// 处理人实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.User> CompleteUserKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.User>("CompleteUser");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.User>("CompleteUser",value);
  }
}

/// <summary>
/// 维修费用
/// </summary>
//private decimal ? _Fee ;
/// <summary>
/// 维修费用
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Fee",Description = "维修费用",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual decimal? Fee
{
get{
 return this.GetValue<decimal?>("Fee");
}
set{
this.SetValue<decimal?>("Fee", value);}
}

/// <summary>
/// 报修原因
/// </summary>
//private string  _ReportMemo ;
/// <summary>
/// 报修原因
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ReportMemo",Description = "报修原因",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string ReportMemo
{
get{
 return this.GetValue<string>("ReportMemo");
}
set{
this.SetValue<string>("ReportMemo", value);}
}

/// <summary>
/// 维修时间
/// </summary>
//private DateTime ? _RepairDate ;
/// <summary>
/// 维修时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="RepairDate",Description = "维修时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? RepairDate
{
get{
 return this.GetValue<DateTime?>("RepairDate");
}
set{
this.SetValue<DateTime?>("RepairDate", value);}
}

/// <summary>
/// 提示用户
/// </summary>
//private bool  _AlarmUser ;
/// <summary>
/// 提示用户
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="AlarmUser",Description = "提示用户",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool AlarmUser
{
get{
 return this.GetValue<bool>("AlarmUser");
}
set{
this.SetValue<bool>("AlarmUser", value);}
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

 public new virtual THU.LabSystemBE.Deploy.DeviceRepairRecordDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.DeviceRepairRecordDTO dto = new THU.LabSystemBE.Deploy.DeviceRepairRecordDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.DeviceRepairRecordDTO dto)
	{
		  base.ToDTO(dto);
		if (this.DeviceKey != null)
		{
			dto.Device = this.DeviceKey.ID;
		}

		if (this.UserKey != null)
		{
			dto.User = this.UserKey.ID;
		}

		if (this.TeacherKey != null)
		{
			dto.Teacher = this.TeacherKey.ID;
		}

		dto.ReportDate = this.ReportDate;

		dto.IsCompleted = this.IsCompleted;

		dto.CompleteDate = this.CompleteDate;

		if (this.CompleteUserKey != null)
		{
			dto.CompleteUser = this.CompleteUserKey.ID;
		}

		dto.Fee = this.Fee;

		dto.ReportMemo = this.ReportMemo;

		dto.RepairDate = this.RepairDate;

		dto.AlarmUser = this.AlarmUser;

		if (this.HouseKey != null)
		{
			dto.House = this.HouseKey.ID;
		}

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceRepairRecordDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceRepairRecordDTO dto , THU.LabSystemBE.DeviceRepairRecord entity){
		base.FromDTO(dto,entity);

		if(dto.Device <=0){
			entity.DeviceKey = null;
		}
		else {
			entity.DeviceKey = new EntityKey<THU.LabSystemBE.DeviceMap>(dto.Device);
		}

		if(dto.User <=0){
			entity.UserKey = null;
		}
		else {
			entity.UserKey = new EntityKey<THU.LabSystemBE.User>(dto.User);
		}

		if(dto.Teacher <=0){
			entity.TeacherKey = null;
		}
		else {
			entity.TeacherKey = new EntityKey<THU.LabSystemBE.Teacher>(dto.Teacher);
		}

		entity.ReportDate = dto.ReportDate;

		entity.IsCompleted = dto.IsCompleted;

		entity.CompleteDate = dto.CompleteDate;

		if(dto.CompleteUser <=0){
			entity.CompleteUserKey = null;
		}
		else {
			entity.CompleteUserKey = new EntityKey<THU.LabSystemBE.User>(dto.CompleteUser);
		}

		entity.Fee = dto.Fee;

		entity.ReportMemo = dto.ReportMemo;

		entity.RepairDate = dto.RepairDate;

		entity.AlarmUser = dto.AlarmUser;

		if(dto.House <=0){
			entity.HouseKey = null;
		}
		else {
			entity.HouseKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.House);
		}

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

