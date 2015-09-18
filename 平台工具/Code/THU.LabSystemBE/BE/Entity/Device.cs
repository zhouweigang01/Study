using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.Device",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_DEVICE")]
public partial class Device : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<Device> _key;
  public new virtual EntityKey<Device> Key
   {
      get
    {
       return this.GetEntityKey<Device>(ref _key);
  }
  }
  public static new string Guid ="ed7be607-7e7b-4976-b1bf-3f18efe5b9df";
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
  public static new Device Create(){
		return Create(true);
  }
  private static Device Create(bool inList){
  	Device entity = new Device();
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
	public new virtual Device OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as Device;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<Device> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<Device>(hql ,paramList,startIndex ,recordCount);
	}
	public static Device Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<Device>(hql ,paramList,startIndex);
	}
	public static Device FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<Device>(id);
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

public Device():base()
 {
  this._entityName = "THU.LabSystemBE.Device";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	Device cloneObj = new Device();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(Device cloneObj) {
    base.Clone(cloneObj);




cloneObj.Name = this.Name;


if(this.Type != null){
	cloneObj.Type = new THU.LabSystemBE.DeviceTypeEnum();
	cloneObj.Type.EnumValue = this.Type.EnumValue;
	cloneObj.Type.Code = this.Type.Code;
	cloneObj.Type.Name = this.Type.Name;
}else{
	cloneObj.Type = null;
}

cloneObj.Expression = this.Expression;


cloneObj.Tag = this.Tag;


cloneObj.Price = this.Price;


cloneObj.IsDelete = this.IsDelete;


}

/// <summary>
/// 设备名称
/// </summary>
//private string  _Name ;
/// <summary>
/// 设备名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "设备名称",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

/// <summary>
/// 设备类型
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.DeviceTypeEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "设备类型",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.DeviceTypeEnum Type
{
get{
  return this.GetEnum<THU.LabSystemBE.DeviceTypeEnum>("Type");
}
set{
  this.SetEnum<THU.LabSystemBE.DeviceTypeEnum>("Type",value);
	}
}
/// <summary>
/// 计费方式
/// </summary>
//private string  _Expression ;
/// <summary>
/// 计费方式
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Expression",Description = "计费方式",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Expression
{
get{
 return this.GetValue<string>("Expression");
}
set{
this.SetValue<string>("Expression", value);}
}

/// <summary>
/// 搜索码
/// </summary>
//private string  _Tag ;
/// <summary>
/// 搜索码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Tag",Description = "搜索码",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Tag
{
get{
 return this.GetValue<string>("Tag");
}
set{
this.SetValue<string>("Tag", value);}
}

/// <summary>
/// 设备价格
/// </summary>
//private decimal ? _Price ;
/// <summary>
/// 设备价格
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Price",Description = "设备价格",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual decimal? Price
{
get{
 return this.GetValue<decimal?>("Price");
}
set{
this.SetValue<decimal?>("Price", value);}
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

 public new virtual THU.LabSystemBE.Deploy.DeviceDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.DeviceDTO dto = new THU.LabSystemBE.Deploy.DeviceDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.DeviceDTO dto)
	{
		  base.ToDTO(dto);
		dto.Name = this.Name;

		if (this.Type != null)
        {
           dto.Type = this.Type.EnumValue;
        }
		dto.Expression = this.Expression;

		dto.Tag = this.Tag;

		dto.Price = this.Price;

		dto.IsDelete = this.IsDelete;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.DeviceDTO dto , THU.LabSystemBE.Device entity){
		base.FromDTO(dto,entity);

		entity.Name = dto.Name;

		if(dto.Type > 0)
		{
			entity.Type=(THU.LabSystemBE.DeviceTypeEnum)dto.Type;
		}

		entity.Expression = dto.Expression;

		entity.Tag = dto.Tag;

		entity.Price = dto.Price;

		entity.IsDelete = dto.IsDelete;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

