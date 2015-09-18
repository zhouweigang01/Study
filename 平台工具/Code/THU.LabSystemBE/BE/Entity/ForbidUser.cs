using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.ForbidUser",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_FORBID_USER")]
public partial class ForbidUser : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<ForbidUser> _key;
  public new virtual EntityKey<ForbidUser> Key
   {
      get
    {
       return this.GetEntityKey<ForbidUser>(ref _key);
  }
  }
  public static new string Guid ="84843ca3-f7d1-4ae2-8edd-4899f717670e";
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
  public static new ForbidUser Create(){
		return Create(true);
  }
  private static ForbidUser Create(bool inList){
  	ForbidUser entity = new ForbidUser();
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
	public new virtual ForbidUser OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as ForbidUser;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<ForbidUser> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<ForbidUser>(hql ,paramList,startIndex ,recordCount);
	}
	public static ForbidUser Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<ForbidUser>(hql ,paramList,startIndex);
	}
	public static ForbidUser FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<ForbidUser>(id);
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

public ForbidUser():base()
 {
  this._entityName = "THU.LabSystemBE.ForbidUser";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	ForbidUser cloneObj = new ForbidUser();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(ForbidUser cloneObj) {
    base.Clone(cloneObj);




if(this.User != null){
	cloneObj.User = new THU.LabSystemBE.User();
	cloneObj.User.ID = this.User.ID;
}else{
	cloneObj.User = null;
}



cloneObj.StartTime = this.StartTime;


cloneObj.EndTime = this.EndTime;


}

/// <summary>
/// 用户
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.User")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "用户",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
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
/// 用户实体Key
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
/// 开始时间
/// </summary>
//private DateTime  _StartTime ;
/// <summary>
/// 开始时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="StartTime",Description = "开始时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual DateTime StartTime
{
get{
 return this.GetValue<DateTime>("StartTime");
}
set{
this.SetValue<DateTime>("StartTime", value);}
}

/// <summary>
/// 结束时间
/// </summary>
//private DateTime  _EndTime ;
/// <summary>
/// 结束时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "结束时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual DateTime EndTime
{
get{
 return this.GetValue<DateTime>("EndTime");
}
set{
this.SetValue<DateTime>("EndTime", value);}
}

 public new virtual THU.LabSystemBE.Deploy.ForbidUserDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.ForbidUserDTO dto = new THU.LabSystemBE.Deploy.ForbidUserDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.ForbidUserDTO dto)
	{
		  base.ToDTO(dto);
		if (this.UserKey != null)
		{
			dto.User = this.UserKey.ID;
		}

		dto.StartTime = this.StartTime;

		dto.EndTime = this.EndTime;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.ForbidUserDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.ForbidUserDTO dto , THU.LabSystemBE.ForbidUser entity){
		base.FromDTO(dto,entity);

		if(dto.User <=0){
			entity.UserKey = null;
		}
		else {
			entity.UserKey = new EntityKey<THU.LabSystemBE.User>(dto.User);
		}

		entity.StartTime = dto.StartTime;

		entity.EndTime = dto.EndTime;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

