using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace IWEHAVE.ERP.CommonBE{
 [Serializable]
[Bussines(EntityName = "IWEHAVE.ERP.CommonBE.BizEntity",Range=NHExt.Runtime.Enums.ViewRangeEnum.NONE,OrgFilter=false,Table="T_BIZENTITY")]
public partial class BizEntity : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<BizEntity> _key;
  public new virtual EntityKey<BizEntity> Key
   {
      get
    {
       return this.GetEntityKey<BizEntity>(ref _key);
  }
  }
  public static new string Guid ="46555b52-7bbf-4667-81a7-6d0b11681400";
  ///是否多组织数据处理
   public override NHExt.Runtime.Enums.ViewRangeEnum Range
        {
            get
            {
                return NHExt.Runtime.Enums.ViewRangeEnum.NONE;
            }
        }
  ///数据是否按照根组织进行过滤
  public override bool OrgFilter {
	get{
		return false;
	}
  }

/// <summary>
/// 生成实体默认创建代码
/// </summary>
  public static new BizEntity Create(){
		return Create(true);
  }
  private static BizEntity Create(bool inList){
  	BizEntity entity = new BizEntity();
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
	public new virtual BizEntity OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as BizEntity;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<BizEntity> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<BizEntity>(hql ,paramList,startIndex ,recordCount);
	}
	public static BizEntity Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<BizEntity>(hql ,paramList,startIndex);
	}
	public static BizEntity FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<BizEntity>(id);
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

public BizEntity():base()
 {
  this._entityName = "IWEHAVE.ERP.CommonBE.BizEntity";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	BizEntity cloneObj = new BizEntity();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(BizEntity cloneObj) {
    base.Clone(cloneObj);




cloneObj.Creator = this.Creator;


cloneObj.Orgnization = this.Orgnization;


cloneObj.CreateDate = this.CreateDate;


cloneObj.ModifyDate = this.ModifyDate;


cloneObj.OrgnizationC = this.OrgnizationC;


}

/// <summary>
/// 创建人
/// </summary>
//private long  _Creator ;
/// <summary>
/// 创建人
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Creator",Description = "创建人",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual long Creator
{
get{
 return this.GetValue<long>("Creator");
}
set{
this.SetValue<long>("Creator", value);}
}

/// <summary>
/// 所属根组织
/// </summary>
//private long  _Orgnization ;
/// <summary>
/// 所属根组织
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Orgnization",Description = "所属根组织",EntityRefrence=false,IsViewer=false,IsBizKey=true,IsNull=false)]
public virtual long Orgnization
{
get{
 return this.GetValue<long>("Orgnization");
}
set{
this.SetValue<long>("Orgnization", value);}
}

/// <summary>
/// 创建日期
/// </summary>
//private DateTime ? _CreateDate ;
/// <summary>
/// 创建日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="CreateDate",Description = "创建日期",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? CreateDate
{
get{
 return this.GetValue<DateTime?>("CreateDate");
}
set{
this.SetValue<DateTime?>("CreateDate", value);}
}

/// <summary>
/// 修改日期
/// </summary>
//private DateTime ? _ModifyDate ;
/// <summary>
/// 修改日期
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ModifyDate",Description = "修改日期",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? ModifyDate
{
get{
 return this.GetValue<DateTime?>("ModifyDate");
}
set{
this.SetValue<DateTime?>("ModifyDate", value);}
}

/// <summary>
/// 所属子组织
/// </summary>
//private long  _OrgnizationC ;
/// <summary>
/// 所属子组织
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="OrgnizationC",Description = "所属子组织",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual long OrgnizationC
{
get{
 return this.GetValue<long>("OrgnizationC");
}
set{
this.SetValue<long>("OrgnizationC", value);}
}

 public new virtual IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO ToDTO()
	{
        IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO dto = new IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO dto)
	{
		  base.ToDTO(dto);
		dto.Creator = this.Creator;

		dto.Orgnization = this.Orgnization;

		dto.CreateDate = this.CreateDate;

		dto.ModifyDate = this.ModifyDate;

		dto.OrgnizationC = this.OrgnizationC;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(IWEHAVE.ERP.CommonBE.Deploy.BizEntityDTO dto , IWEHAVE.ERP.CommonBE.BizEntity entity){
		base.FromDTO(dto,entity);

		entity.Creator = dto.Creator;

		entity.Orgnization = dto.Orgnization;

		entity.CreateDate = dto.CreateDate;

		entity.ModifyDate = dto.ModifyDate;

		entity.OrgnizationC = dto.OrgnizationC;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

