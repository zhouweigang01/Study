using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.DeviceMap",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_DEVICE_MAP")]
public partial class DeviceMap : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<DeviceMap> _key;
  public new virtual EntityKey<DeviceMap> Key
   {
      get
    {
       return this.GetEntityKey<DeviceMap>(ref _key);
  }
  }
  public static new string Guid ="3c5ffb16-361e-462e-b884-52b998b03d3e";
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
  public static new DeviceMap Create(){
		return Create(true);
  }
  private static DeviceMap Create(bool inList){
  	DeviceMap entity = new DeviceMap();
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
	public new virtual DeviceMap OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as DeviceMap;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<DeviceMap> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<DeviceMap>(hql ,paramList,startIndex ,recordCount);
	}
	public static DeviceMap Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<DeviceMap>(hql ,paramList,startIndex);
	}
	public static DeviceMap FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<DeviceMap>(id);
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

public DeviceMap():base()
 {
  this._entityName = "THU.LabSystemBE.DeviceMap";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	DeviceMap cloneObj = new DeviceMap();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(DeviceMap cloneObj) {
    base.Clone(cloneObj);




if(this.House != null){
	cloneObj.House = new THU.LabSystemBE.CommonEnum();
	cloneObj.House.ID = this.House.ID;
}else{
	cloneObj.House = null;
}



cloneObj.SN = this.SN;


if(this.DeviceStatus != null){
	cloneObj.DeviceStatus = new THU.LabSystemBE.DeviceStatusEnum();
	cloneObj.DeviceStatus.EnumValue = this.DeviceStatus.EnumValue;
	cloneObj.DeviceStatus.Code = this.DeviceStatus.Code;
	cloneObj.DeviceStatus.Name = this.DeviceStatus.Name;
}else{
	cloneObj.DeviceStatus = null;
}

if(this.UseStatus != null){
	cloneObj.UseStatus = new THU.LabSystemBE.UseStatusEnum();
	cloneObj.UseStatus.EnumValue = this.UseStatus.EnumValue;
	cloneObj.UseStatus.Code = this.UseStatus.Code;
	cloneObj.UseStatus.Name = this.UseStatus.Name;
}else{
	cloneObj.UseStatus = null;
}

cloneObj.Price = this.Price;


cloneObj.Expression = this.Expression;


cloneObj.IsDelete = this.IsDelete;


if(this.Device != null){
	cloneObj.Device = new THU.LabSystemBE.Device();
	cloneObj.Device.ID = this.Device.ID;
}else{
	cloneObj.Device = null;
}



}

/// <summary>
/// 房间
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="House",Description = "房间",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
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
/// 房间实体Key
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
/// 设备号
/// </summary>
//private string  _SN ;
/// <summary>
/// 设备号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="SN",Description = "设备号",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string SN
{
get{
 return this.GetValue<string>("SN");
}
set{
this.SetValue<string>("SN", value);}
}

/// <summary>
/// 设备状态
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.DeviceStatusEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="DeviceStatus",Description = "设备状态",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.DeviceStatusEnum DeviceStatus
{
get{
  return this.GetEnum<THU.LabSystemBE.DeviceStatusEnum>("DeviceStatus");
}
set{
  this.SetEnum<THU.LabSystemBE.DeviceStatusEnum>("DeviceStatus",value);
	}
}
/// <summary>
/// 使用状态
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.UseStatusEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="UseStatus",Description = "使用状态",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.UseStatusEnum UseStatus
{
get{
  return this.GetEnum<THU.LabSystemBE.UseStatusEnum>("UseStatus");
}
set{
  this.SetEnum<THU.LabSystemBE.UseStatusEnum>("UseStatus",value);
	}
}
/// <summary>
/// 设备单价
/// </summary>
//private decimal ? _Price ;
/// <summary>
/// 设备单价
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Price",Description = "设备单价",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual decimal? Price
{
get{
 return this.GetValue<decimal?>("Price");
}
set{
this.SetValue<decimal?>("Price", value);}
}

/// <summary>
/// 计算公式
/// </summary>
//private string  _Expression ;
/// <summary>
/// 计算公式
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Expression",Description = "计算公式",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Expression
{
get{
 return this.GetValue<string>("Expression");
}
set{
this.SetValue<string>("Expression", value);}
}

/// <summary>
/// 是否删除
/// </summary>
//private bool  _IsDelete ;
/// <summary>
/// 是否删除
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsDelete",Description = "是否删除",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool IsDelete
{
get{
 return this.GetValue<bool>("IsDelete");
}
set{
this.SetValue<bool>("IsDelete", value);}
}

/// <summary>
/// 关联设备
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.Device")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Device",Description = "关联设备",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.Device Device
{
get{
 return this.GetRefrence<THU.LabSystemBE.Device>("Device");
}
set{
 this.SetRefrence<THU.LabSystemBE.Device>("Device",value);
}
}
/// <summary>
/// 关联设备实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.Device> DeviceKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.Device>("Device");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.Device>("Device",value);
  }
}

 public new virtual THU.LabSystemBE.Deploy.DeviceMapDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.DeviceMapDTO dto = new THU.LabSystemBE.Deploy.DeviceMapDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.DeviceMapDTO dto)
	{
		  base.ToDTO(dto);
		if (this.HouseKey != null)
		{
			dto.House = this.HouseKey.ID;
		}

		dto.SN = this.SN;

		if (this.DeviceStatus != null)
        {
           dto.DeviceStatus = this.DeviceStatus.EnumValue;
        }
		if (this.UseStatus != null)
        {
           dto.UseStatus = this.UseStatus.EnumValue;
        }
		dto.Price = this.Price;

		dto.Expression = this.Expression;

		dto.IsDelete = this.IsDelete;

		if (this.DeviceKey != null)
		{
			dto.Device = this.DeviceKey.ID;
		}

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceMapDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceMapDTO dto , THU.LabSystemBE.DeviceMap entity){
		base.FromDTO(dto,entity);

		if(dto.House <=0){
			entity.HouseKey = null;
		}
		else {
			entity.HouseKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.House);
		}

		entity.SN = dto.SN;

		if(dto.DeviceStatus > 0)
		{
			entity.DeviceStatus=(THU.LabSystemBE.DeviceStatusEnum)dto.DeviceStatus;
		}

		if(dto.UseStatus > 0)
		{
			entity.UseStatus=(THU.LabSystemBE.UseStatusEnum)dto.UseStatus;
		}

		entity.Price = dto.Price;

		entity.Expression = dto.Expression;

		entity.IsDelete = dto.IsDelete;

		if(dto.Device <=0){
			entity.DeviceKey = null;
		}
		else {
			entity.DeviceKey = new EntityKey<THU.LabSystemBE.Device>(dto.Device);
		}

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

