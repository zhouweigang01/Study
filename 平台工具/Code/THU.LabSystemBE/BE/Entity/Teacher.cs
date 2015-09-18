using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.Teacher",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_TEACHER")]
public partial class Teacher : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<Teacher> _key;
  public new virtual EntityKey<Teacher> Key
   {
      get
    {
       return this.GetEntityKey<Teacher>(ref _key);
  }
  }
  public static new string Guid ="66daf590-39cf-4f27-b265-a9f3f122a3e9";
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
  public static new Teacher Create(){
		return Create(true);
  }
  private static Teacher Create(bool inList){
  	Teacher entity = new Teacher();
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
	public new virtual Teacher OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as Teacher;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<Teacher> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<Teacher>(hql ,paramList,startIndex ,recordCount);
	}
	public static Teacher Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<Teacher>(hql ,paramList,startIndex);
	}
	public static Teacher FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<Teacher>(id);
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

public Teacher():base()
 {
  this._entityName = "THU.LabSystemBE.Teacher";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	Teacher cloneObj = new Teacher();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(Teacher cloneObj) {
    base.Clone(cloneObj);




cloneObj.Name = this.Name;


if(this.Sex != null){
	cloneObj.Sex = new THU.LabSystemBE.SexEnum();
	cloneObj.Sex.EnumValue = this.Sex.EnumValue;
	cloneObj.Sex.Code = this.Sex.Code;
	cloneObj.Sex.Name = this.Sex.Name;
}else{
	cloneObj.Sex = null;
}

if(this.Position != null){
	cloneObj.Position = new THU.LabSystemBE.CommonEnum();
	cloneObj.Position.ID = this.Position.ID;
}else{
	cloneObj.Position = null;
}



if(this.Department != null){
	cloneObj.Department = new THU.LabSystemBE.CommonEnum();
	cloneObj.Department.ID = this.Department.ID;
}else{
	cloneObj.Department = null;
}



cloneObj.Tag = this.Tag;


cloneObj.IsDelete = this.IsDelete;


}

/// <summary>
/// 姓名
/// </summary>
//private string  _Name ;
/// <summary>
/// 姓名
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "姓名",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

/// <summary>
/// 性别
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.SexEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Sex",Description = "性别",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.SexEnum Sex
{
get{
  return this.GetEnum<THU.LabSystemBE.SexEnum>("Sex");
}
set{
  this.SetEnum<THU.LabSystemBE.SexEnum>("Sex",value);
	}
}
/// <summary>
/// 职位
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Position",Description = "职位",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.CommonEnum Position
{
get{
 return this.GetRefrence<THU.LabSystemBE.CommonEnum>("Position");
}
set{
 this.SetRefrence<THU.LabSystemBE.CommonEnum>("Position",value);
}
}
/// <summary>
/// 职位实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.CommonEnum> PositionKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.CommonEnum>("Position");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.CommonEnum>("Position",value);
  }
}

/// <summary>
/// 所属院系
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Department",Description = "所属院系",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual THU.LabSystemBE.CommonEnum Department
{
get{
 return this.GetRefrence<THU.LabSystemBE.CommonEnum>("Department");
}
set{
 this.SetRefrence<THU.LabSystemBE.CommonEnum>("Department",value);
}
}
/// <summary>
/// 所属院系实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.CommonEnum> DepartmentKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.CommonEnum>("Department");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.CommonEnum>("Department",value);
  }
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

 public new virtual THU.LabSystemBE.Deploy.TeacherDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.TeacherDTO dto = new THU.LabSystemBE.Deploy.TeacherDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.TeacherDTO dto)
	{
		  base.ToDTO(dto);
		dto.Name = this.Name;

		if (this.Sex != null)
        {
           dto.Sex = this.Sex.EnumValue;
        }
		if (this.PositionKey != null)
		{
			dto.Position = this.PositionKey.ID;
		}

		if (this.DepartmentKey != null)
		{
			dto.Department = this.DepartmentKey.ID;
		}

		dto.Tag = this.Tag;

		dto.IsDelete = this.IsDelete;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.TeacherDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.TeacherDTO dto , THU.LabSystemBE.Teacher entity){
		base.FromDTO(dto,entity);

		entity.Name = dto.Name;

		if(dto.Sex > 0)
		{
			entity.Sex=(THU.LabSystemBE.SexEnum)dto.Sex;
		}

		if(dto.Position <=0){
			entity.PositionKey = null;
		}
		else {
			entity.PositionKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.Position);
		}

		if(dto.Department <=0){
			entity.DepartmentKey = null;
		}
		else {
			entity.DepartmentKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.Department);
		}

		entity.Tag = dto.Tag;

		entity.IsDelete = dto.IsDelete;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

