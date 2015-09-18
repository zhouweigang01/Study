using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.Org",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_ORG")]
public partial class Org : IWEHAVE.ERP.CommonBE.BizEntity
{
 private EntityKey<Org> _key;
  public new virtual EntityKey<Org> Key
   {
      get
    {
       return this.GetEntityKey<Org>(ref _key);
  }
  }
  public static new string Guid ="c071587b-a589-42aa-ad65-296bcd1fc04f";
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
  public static new Org Create(){
		return Create(true);
  }
  private static Org Create(bool inList){
  	Org entity = new Org();
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
	public new virtual Org OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as Org;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<Org> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<Org>(hql ,paramList,startIndex ,recordCount);
	}
	public static Org Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<Org>(hql ,paramList,startIndex);
	}
	public static Org FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<Org>(id);
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

public Org():base()
 {
  this._entityName = "THU.LabSystemBE.Org";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	Org cloneObj = new Org();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(Org cloneObj) {
    base.Clone(cloneObj);




cloneObj.Code = this.Code;


cloneObj.Name = this.Name;


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
/// 名称
/// </summary>
//private string  _Name ;
/// <summary>
/// 名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "名称",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

 public new virtual THU.LabSystemBE.Deploy.OrgDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.OrgDTO dto = new THU.LabSystemBE.Deploy.OrgDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.OrgDTO dto)
	{
		  base.ToDTO(dto);
		dto.Code = this.Code;

		dto.Name = this.Name;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.OrgDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.OrgDTO dto , THU.LabSystemBE.Org entity){
		base.FromDTO(dto,entity);

		entity.Code = dto.Code;

		entity.Name = dto.Name;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

