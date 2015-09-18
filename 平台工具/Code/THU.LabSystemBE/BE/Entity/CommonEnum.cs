using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.CommonEnum",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_COMMON_ENUM")]
public partial class CommonEnum : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<CommonEnum> _key;
  public new virtual EntityKey<CommonEnum> Key
   {
      get
    {
       return this.GetEntityKey<CommonEnum>(ref _key);
  }
  }
  public static new string Guid ="aa161d3b-4801-48f6-90b4-20f8ae57f853";
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
  public static new CommonEnum Create(){
		return Create(true);
  }
  private static CommonEnum Create(bool inList){
  	CommonEnum entity = new CommonEnum();
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
	public new virtual CommonEnum OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as CommonEnum;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<CommonEnum> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<CommonEnum>(hql ,paramList,startIndex ,recordCount);
	}
	public static CommonEnum Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<CommonEnum>(hql ,paramList,startIndex);
	}
	public static CommonEnum FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<CommonEnum>(id);
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

public CommonEnum():base()
 {
  this._entityName = "THU.LabSystemBE.CommonEnum";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	CommonEnum cloneObj = new CommonEnum();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(CommonEnum cloneObj) {
    base.Clone(cloneObj);




cloneObj.Name = this.Name;


if(this.Type != null){
	cloneObj.Type = new THU.LabSystemBE.TypeEnum();
	cloneObj.Type.EnumValue = this.Type.EnumValue;
	cloneObj.Type.Code = this.Type.Code;
	cloneObj.Type.Name = this.Type.Name;
}else{
	cloneObj.Type = null;
}

cloneObj.Code = this.Code;


cloneObj.IsDelete = this.IsDelete;


}

/// <summary>
/// 枚举名称
/// </summary>
//private string  _Name ;
/// <summary>
/// 枚举名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "枚举名称",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

/// <summary>
/// 类别
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.TypeEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "类别",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.TypeEnum Type
{
get{
  return this.GetEnum<THU.LabSystemBE.TypeEnum>("Type");
}
set{
  this.SetEnum<THU.LabSystemBE.TypeEnum>("Type",value);
	}
}
/// <summary>
/// 编码
/// </summary>
//private string  _Code ;
/// <summary>
/// 编码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Code",Description = "编码",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Code
{
get{
 return this.GetValue<string>("Code");
}
set{
this.SetValue<string>("Code", value);}
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

 public new virtual THU.LabSystemBE.Deploy.CommonEnumDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.CommonEnumDTO dto = new THU.LabSystemBE.Deploy.CommonEnumDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.CommonEnumDTO dto)
	{
		  base.ToDTO(dto);
		dto.Name = this.Name;

		if (this.Type != null)
        {
           dto.Type = this.Type.EnumValue;
        }
		dto.Code = this.Code;

		dto.IsDelete = this.IsDelete;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.CommonEnumDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.CommonEnumDTO dto , THU.LabSystemBE.CommonEnum entity){
		base.FromDTO(dto,entity);

		entity.Name = dto.Name;

		if(dto.Type > 0)
		{
			entity.Type=(THU.LabSystemBE.TypeEnum)dto.Type;
		}

		entity.Code = dto.Code;

		entity.IsDelete = dto.IsDelete;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

