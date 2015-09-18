using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.User",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_USER")]
public partial class User : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<User> _key;
  public new virtual EntityKey<User> Key
   {
      get
    {
       return this.GetEntityKey<User>(ref _key);
  }
  }
  public static new string Guid ="4c47c367-5698-4cae-81b0-eab071ce87ab";
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
  public static new User Create(){
		return Create(true);
  }
  private static User Create(bool inList){
  	User entity = new User();
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
	public new virtual User OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as User;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<User> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<User>(hql ,paramList,startIndex ,recordCount);
	}
	public static User Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<User>(hql ,paramList,startIndex);
	}
	public static User FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<User>(id);
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

public User():base()
 {
  this._entityName = "THU.LabSystemBE.User";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	User cloneObj = new User();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(User cloneObj) {
    base.Clone(cloneObj);




cloneObj.SN = this.SN;


cloneObj.Name = this.Name;


cloneObj.Tel = this.Tel;


cloneObj.Password = this.Password;


if(this.Degree != null){
	cloneObj.Degree = new THU.LabSystemBE.CommonEnum();
	cloneObj.Degree.ID = this.Degree.ID;
}else{
	cloneObj.Degree = null;
}



if(this.Status != null){
	cloneObj.Status = new THU.LabSystemBE.CommonEnum();
	cloneObj.Status.ID = this.Status.ID;
}else{
	cloneObj.Status = null;
}



if(this.Type != null){
	cloneObj.Type = new THU.LabSystemBE.UserTypeEnum();
	cloneObj.Type.EnumValue = this.Type.EnumValue;
	cloneObj.Type.Code = this.Type.Code;
	cloneObj.Type.Name = this.Type.Name;
}else{
	cloneObj.Type = null;
}

cloneObj.Email = this.Email;


cloneObj.Code = this.Code;


cloneObj.IsDelete = this.IsDelete;


cloneObj.BeginTime = this.BeginTime;


cloneObj.EndTime = this.EndTime;


if(this.Teacher != null){
	cloneObj.Teacher = new THU.LabSystemBE.Teacher();
	cloneObj.Teacher.ID = this.Teacher.ID;
}else{
	cloneObj.Teacher = null;
}



}

/// <summary>
/// 学号
/// </summary>
//private string  _SN ;
/// <summary>
/// 学号
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="SN",Description = "学号",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string SN
{
get{
 return this.GetValue<string>("SN");
}
set{
this.SetValue<string>("SN", value);}
}

/// <summary>
/// 姓名
/// </summary>
//private string  _Name ;
/// <summary>
/// 姓名
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Name",Description = "姓名",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Name
{
get{
 return this.GetValue<string>("Name");
}
set{
this.SetValue<string>("Name", value);}
}

/// <summary>
/// 电话
/// </summary>
//private string  _Tel ;
/// <summary>
/// 电话
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Tel",Description = "电话",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Tel
{
get{
 return this.GetValue<string>("Tel");
}
set{
this.SetValue<string>("Tel", value);}
}

/// <summary>
/// 密码
/// </summary>
//private string  _Password ;
/// <summary>
/// 密码
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Password",Description = "密码",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string Password
{
get{
 return this.GetValue<string>("Password");
}
set{
this.SetValue<string>("Password", value);}
}

/// <summary>
/// 学历
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Degree",Description = "学历",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual THU.LabSystemBE.CommonEnum Degree
{
get{
 return this.GetRefrence<THU.LabSystemBE.CommonEnum>("Degree");
}
set{
 this.SetRefrence<THU.LabSystemBE.CommonEnum>("Degree",value);
}
}
/// <summary>
/// 学历实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.CommonEnum> DegreeKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.CommonEnum>("Degree");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.CommonEnum>("Degree",value);
  }
}

/// <summary>
/// 身份
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Entity,TargetEntity="THU.LabSystemBE.CommonEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Status",Description = "身份",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual THU.LabSystemBE.CommonEnum Status
{
get{
 return this.GetRefrence<THU.LabSystemBE.CommonEnum>("Status");
}
set{
 this.SetRefrence<THU.LabSystemBE.CommonEnum>("Status",value);
}
}
/// <summary>
/// 身份实体Key
/// </summary>
public virtual EntityKey<THU.LabSystemBE.CommonEnum> StatusKey
{
 get
  {
	 return this.GetRefrenceKey<THU.LabSystemBE.CommonEnum>("Status");
  }
 set
  {
  this.SetRefrenceKey<THU.LabSystemBE.CommonEnum>("Status",value);
  }
}

/// <summary>
/// 用户类别
/// </summary>
[NHExt.Runtime.EntityAttribute.Refrence(RefType=NHExt.Runtime.Enums.RefrenceTypeEnum.Enum,TargetEntity="THU.LabSystemBE.UserTypeEnum")]
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Type",Description = "用户类别",EntityRefrence=true,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual THU.LabSystemBE.UserTypeEnum Type
{
get{
  return this.GetEnum<THU.LabSystemBE.UserTypeEnum>("Type");
}
set{
  this.SetEnum<THU.LabSystemBE.UserTypeEnum>("Type",value);
	}
}
/// <summary>
/// 邮件
/// </summary>
//private string  _Email ;
/// <summary>
/// 邮件
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Email",Description = "邮件",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string Email
{
get{
 return this.GetValue<string>("Email");
}
set{
this.SetValue<string>("Email", value);}
}

/// <summary>
/// 登录名
/// </summary>
//private string  _Code ;
/// <summary>
/// 登录名
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Code",Description = "登录名",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
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

/// <summary>
/// 启用时间
/// </summary>
//private DateTime ? _BeginTime ;
/// <summary>
/// 启用时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="BeginTime",Description = "启用时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? BeginTime
{
get{
 return this.GetValue<DateTime?>("BeginTime");
}
set{
this.SetValue<DateTime?>("BeginTime", value);}
}

/// <summary>
/// 停用时间
/// </summary>
//private DateTime ? _EndTime ;
/// <summary>
/// 停用时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="EndTime",Description = "停用时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual DateTime? EndTime
{
get{
 return this.GetValue<DateTime?>("EndTime");
}
set{
this.SetValue<DateTime?>("EndTime", value);}
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

 public new virtual THU.LabSystemBE.Deploy.UserDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.UserDTO dto = new THU.LabSystemBE.Deploy.UserDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.UserDTO dto)
	{
		  base.ToDTO(dto);
		dto.SN = this.SN;

		dto.Name = this.Name;

		dto.Tel = this.Tel;

		dto.Password = this.Password;

		if (this.DegreeKey != null)
		{
			dto.Degree = this.DegreeKey.ID;
		}

		if (this.StatusKey != null)
		{
			dto.Status = this.StatusKey.ID;
		}

		if (this.Type != null)
        {
           dto.Type = this.Type.EnumValue;
        }
		dto.Email = this.Email;

		dto.Code = this.Code;

		dto.IsDelete = this.IsDelete;

		dto.BeginTime = this.BeginTime;

		dto.EndTime = this.EndTime;

		if (this.TeacherKey != null)
		{
			dto.Teacher = this.TeacherKey.ID;
		}

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.UserDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.UserDTO dto , THU.LabSystemBE.User entity){
		base.FromDTO(dto,entity);

		entity.SN = dto.SN;

		entity.Name = dto.Name;

		entity.Tel = dto.Tel;

		entity.Password = dto.Password;

		if(dto.Degree <=0){
			entity.DegreeKey = null;
		}
		else {
			entity.DegreeKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.Degree);
		}

		if(dto.Status <=0){
			entity.StatusKey = null;
		}
		else {
			entity.StatusKey = new EntityKey<THU.LabSystemBE.CommonEnum>(dto.Status);
		}

		if(dto.Type > 0)
		{
			entity.Type=(THU.LabSystemBE.UserTypeEnum)dto.Type;
		}

		entity.Email = dto.Email;

		entity.Code = dto.Code;

		entity.IsDelete = dto.IsDelete;

		entity.BeginTime = dto.BeginTime;

		entity.EndTime = dto.EndTime;

		if(dto.Teacher <=0){
			entity.TeacherKey = null;
		}
		else {
			entity.TeacherKey = new EntityKey<THU.LabSystemBE.Teacher>(dto.Teacher);
		}

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

