using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
 namespace THU.LabSystemBE{
 [Serializable]
[Bussines(EntityName = "THU.LabSystemBE.LoginLogger",Range=NHExt.Runtime.Enums.ViewRangeEnum.UPPER,OrgFilter=true,Table="T_LAB_LOGIN_LOGGER")]
public partial class LoginLogger : NHExt.Runtime.Model.BaseEntity
{
 private EntityKey<LoginLogger> _key;
  public new virtual EntityKey<LoginLogger> Key
   {
      get
    {
       return this.GetEntityKey<LoginLogger>(ref _key);
  }
  }
  public static new string Guid ="ee4d1161-0b79-4a92-b66a-1f677b15bd8c";
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
  public static new LoginLogger Create(){
		return Create(true);
  }
  private static LoginLogger Create(bool inList){
  	LoginLogger entity = new LoginLogger();
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
	public new virtual LoginLogger OrignalData {
		get{
			if(this._orignalData == null){
				this.InitOrignalData();
			}
			return this._orignalData as LoginLogger;
		}
	}
	public override void InitOrignalData() { 
		base.InitOrignalData();
	}

#region 实体查询相关函数
public new static class Finder{
	public static List<LoginLogger> FindAll(string hql ,List<object> paramList = null, int startIndex = -1, int recordCount = -1){
		return  NHExt.Runtime.Query.EntityFinder.FindAll<LoginLogger>(hql ,paramList,startIndex ,recordCount);
	}
	public static LoginLogger Find(string hql ,List<object> paramList = null,int startIndex=-1){
		return  NHExt.Runtime.Query.EntityFinder.Find<LoginLogger>(hql ,paramList,startIndex);
	}
	public static LoginLogger FindById(long id){
		return  NHExt.Runtime.Query.EntityFinder.FindById<LoginLogger>(id);
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

public LoginLogger():base()
 {
  this._entityName = "THU.LabSystemBE.LoginLogger";
}
public override NHExt.Runtime.Model.BaseEntity Clone()
{
	LoginLogger cloneObj = new LoginLogger();
	this.Clone(cloneObj);
	return cloneObj;
}

public virtual void Clone(LoginLogger cloneObj) {
    base.Clone(cloneObj);




cloneObj.User = this.User;


cloneObj.Name = this.Name;


cloneObj.IP = this.IP;


cloneObj.Success = this.Success;


cloneObj.ErrorMsg = this.ErrorMsg;


cloneObj.LoginDate = this.LoginDate;


}

/// <summary>
/// 登陆用户
/// </summary>
//private long  _User ;
/// <summary>
/// 登陆用户
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="User",Description = "登陆用户",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual long User
{
get{
 return this.GetValue<long>("User");
}
set{
this.SetValue<long>("User", value);}
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
/// 登陆IP
/// </summary>
//private string  _IP ;
/// <summary>
/// 登陆IP
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="IP",Description = "登陆IP",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual string IP
{
get{
 return this.GetValue<string>("IP");
}
set{
this.SetValue<string>("IP", value);}
}

/// <summary>
/// 是否成功
/// </summary>
//private bool  _Success ;
/// <summary>
/// 是否成功
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="Success",Description = "是否成功",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual bool Success
{
get{
 return this.GetValue<bool>("Success");
}
set{
this.SetValue<bool>("Success", value);}
}

/// <summary>
/// 错误原因
/// </summary>
//private string  _ErrorMsg ;
/// <summary>
/// 错误原因
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="ErrorMsg",Description = "错误原因",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=true)]
public virtual string ErrorMsg
{
get{
 return this.GetValue<string>("ErrorMsg");
}
set{
this.SetValue<string>("ErrorMsg", value);}
}

/// <summary>
/// 登录时间
/// </summary>
//private DateTime  _LoginDate ;
/// <summary>
/// 登录时间
/// </summary>
[NHExt.Runtime.EntityAttribute.ColumnDescription(Code="LoginDate",Description = "登录时间",EntityRefrence=false,IsViewer=false,IsBizKey=false,IsNull=false)]
public virtual DateTime LoginDate
{
get{
 return this.GetValue<DateTime>("LoginDate");
}
set{
this.SetValue<DateTime>("LoginDate", value);}
}

 public new virtual THU.LabSystemBE.Deploy.LoginLoggerDTO ToDTO()
	{
        THU.LabSystemBE.Deploy.LoginLoggerDTO dto = new THU.LabSystemBE.Deploy.LoginLoggerDTO();
        this.ToDTO(dto);
        return dto;
    }
protected virtual void ToDTO(THU.LabSystemBE.Deploy.LoginLoggerDTO dto)
	{
		  base.ToDTO(dto);
		dto.User = this.User;

		dto.Name = this.Name;

		dto.IP = this.IP;

		dto.Success = this.Success;

		dto.ErrorMsg = this.ErrorMsg;

		dto.LoginDate = this.LoginDate;

	
	this.ToDTOImpl(dto);
}
	public virtual void FromDTO(THU.LabSystemBE.Deploy.LoginLoggerDTO dto){
		this.FromDTO(dto,this);
	}
	protected virtual void FromDTO(THU.LabSystemBE.Deploy.LoginLoggerDTO dto , THU.LabSystemBE.LoginLogger entity){
		base.FromDTO(dto,entity);

		entity.User = dto.User;

		entity.Name = dto.Name;

		entity.IP = dto.IP;

		entity.Success = dto.Success;

		entity.ErrorMsg = dto.ErrorMsg;

		entity.LoginDate = dto.LoginDate;

		this.FromDTOImpl(dto);
	}

	public override NHExt.Runtime.Model.BaseDTO ToBaseDTO(){
		return this.ToDTO();
	}
 }
}

