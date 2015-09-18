using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace IWEHAVE.ERP.CommonBE{
 [Serializable]
[Bussines(EntityName = "IWEHAVE.ERP.CommonBE.BizTreeEntity",Range=NHExt.Runtime.Enums.ViewRangeEnum.NONE,OrgFilter=false,Table="T_BIZTREEENTITY")]
public partial class BizTreeEntity : IWEHAVE.ERP.CommonBE.BizEntity
{
 private EntityKey<BizTreeEntity> _key;
  public new virtual EntityKey<BizTreeEntity> Key
   {
      get
    {
       return this.GetEntityKey<BizTreeEntity>(ref _key);
  }
  }
  public static new string Guid ="1d9694f8-740a-4bb9-bfa0-d0a055873ced";
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
  public static new BizTreeEntity Create(){
		return Create(true);
  }
  private static BizTreeEntity Create(bool inList){
  	BizTreeEntity entity = new BizTreeEntity();
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
	public new virtual BizTreeEntity OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as BizTreeEntity;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<BizTreeEntity> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<BizTreeEntity>(hql ,paramList,startIndex ,recordCount);
	}
	public static BizTreeEntity Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<BizTreeEntity>(hql ,paramList,startIndex);
	}
	public static BizTreeEntity FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<BizTreeEntity>(id);
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

public BizTreeEntity():base()
 {
  this._entityName = "IWEHAVE.ERP.CommonBE.BizTreeEntity";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	BizTreeEntity cloneObj = new BizTreeEntity();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(BizTreeEntity cloneObj) {
    base.Clone(cloneObj);




cloneObj.PID = this.PID;


cloneObj.Name = this.Name;


cloneObj.FullName = this.FullName;


cloneObj.Level = this.Level;


cloneObj.OrderNo = this.OrderNo;


cloneObj.Leaf = this.Leaf;


cloneObj.IsDelete = this.IsDelete;


}

/// <summary>
/// 父节点ID
/// </summary>
//private long ? _PID ;
/// <summary>
/// 父节点ID
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="PID",Description = "父节点ID",EntityRefrence=false,IsViewer=false,IsBizKey=true,IsNull=true)]
public virtual long? PID
{
get{
 return this.GetValue<long?>("PID");
}
set{
this.SetValue<long?>("PID", value);}
}

/// <summary>
/// 节点名称
/// </summary>
//private string  _Name ;
/// <summary>
/// 节点名称
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "节点名称",EntityRefrence=false,IsViewer=false,IsBizKey=true,IsNull=false)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

/// <summary>
/// 节点全路径
/// </summary>
//private string  _FullName ;
/// <summary>
/// 节点全路径
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="FullName",Description = "节点全路径",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string FullName
{
get{
 return this.GetValue<string>("FullName");
}
set{
this.SetValue<string>("FullName", value);}
}

/// <summary>
/// 节点层级
/// </summary>
//private int  _Level ;
/// <summary>
/// 节点层级
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Level",Description = "节点层级",EntityRefrence=false,IsViewer=false,IsBizKey=true,IsNull=false)]
public virtual int Level
{
get{
 return this.GetValue<int>("Level");
}
set{
this.SetValue<int>("Level", value);}
}

/// <summary>
/// 同级顺序号
/// </summary>
//private int  _OrderNo ;
/// <summary>
/// 同级顺序号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="OrderNo",Description = "同级顺序号",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual int OrderNo
{
get{
 return this.GetValue<int>("OrderNo");
}
set{
this.SetValue<int>("OrderNo", value);}
}

/// <summary>
/// 是否叶节点
/// </summary>
//private bool  _Leaf ;
/// <summary>
/// 是否叶节点
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Leaf",Description = "是否叶节点",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool Leaf
{
get{
 return this.GetValue<bool>("Leaf");
}
set{
this.SetValue<bool>("Leaf", value);}
}

/// <summary>
/// 是否删除
/// </summary>
//private bool  _IsDelete ;
/// <summary>
/// 是否删除
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IsDelete",Description = "是否删除",EntityRefrence=false,IsViewer=false,IsBizKey=true,IsNull=false)]
public virtual bool IsDelete
{
get{
 return this.GetValue<bool>("IsDelete");
}
set{
this.SetValue<bool>("IsDelete", value);}
}

 public new virtual IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO ToDTO()
	{
        IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO dto = new IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO dto)
	{
		  base.ToDTO(dto);
		dto.PID = this.PID;

		dto.Name = this.Name;

		dto.FullName = this.FullName;

		dto.Level = this.Level;

		dto.OrderNo = this.OrderNo;

		dto.Leaf = this.Leaf;

		dto.IsDelete = this.IsDelete;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(IWEHAVE.ERP.CommonBE.Deploy.BizTreeEntityDTO dto , IWEHAVE.ERP.CommonBE.BizTreeEntity entity){
		base.FromDTO(dto,entity);

		entity.PID = dto.PID;

		entity.Name = dto.Name;

		entity.FullName = dto.FullName;

		entity.Level = dto.Level;

		entity.OrderNo = dto.OrderNo;

		entity.Leaf = dto.Leaf;

		entity.IsDelete = dto.IsDelete;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

