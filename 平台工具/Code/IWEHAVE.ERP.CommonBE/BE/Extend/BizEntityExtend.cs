using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
using System.Text.RegularExpressions;
namespace IWEHAVE.ERP.CommonBE
{
    public partial class BizEntity
    {
        public virtual bool IgnoreOrgFilter { get; set; }
        private void FromDTOImpl(Deploy.BizEntityDTO dto)
        {
            if (this.OrignalData != null)
            {
                this.Creator = this.OrignalData.Creator;
                this.Orgnization = this.OrignalData.Orgnization;
                this.CreateDate = this.OrignalData.CreateDate;
                this.OrgnizationC = this.OrignalData.OrgnizationC;
            }
        }
        private void ToDTOImpl(Deploy.BizEntityDTO dto)
        {

        }
        private void OnSetDefaultValue()
        {
            if (this.Orgnization <= 0)
            {
                if (NHExt.Runtime.Session.SessionCache.Current != null)
                {
                    if (NHExt.Runtime.Session.SessionCache.Current.AuthContext != null)
                    {
                        this.Orgnization = NHExt.Runtime.Session.SessionCache.Current.AuthContext.GetData<long>("Org");
                    }
                }
            }
            if (this.OrgnizationC <= 0)
            {
                if (NHExt.Runtime.Session.SessionCache.Current != null)
                {
                    if (NHExt.Runtime.Session.SessionCache.Current.AuthContext != null)
                    {
                        this.OrgnizationC = NHExt.Runtime.Session.SessionCache.Current.AuthContext.GetData<long>("OrgC");
                    }
                }
            }
        }
        private void OnValidate()
        {
            if (this.Orgnization <= 0)
            {
                throw new Exception("数据所属根组织不能为空");
            }
            if (this.OrgnizationC <= 0)
            {
                throw new Exception("数据所属子组织不能为空");
            }
            if (this.OrgFilter && this.Range != NHExt.Runtime.Enums.ViewRangeEnum.ALL && !this.IgnoreOrgFilter)
            {
                if (this.OrgnizationC != NHExt.Runtime.Session.SessionCache.Current.AuthContext.GetData<long>("OrgC"))
                {
                    throw new Exception("当前登录组织和数据所属组织不是同一个组织，数据操作失败");
                }
            }

            foreach (BaseEntity entity in this.EntityRefrence)
            {
                if (entity is BizEntity)
                {
                    if (entity.OrgFilter && entity.Range != NHExt.Runtime.Enums.ViewRangeEnum.ALL)
                    {
                        long orgC = Convert.ToInt64(entity.GetData("OrgnizationC"));
                        if (this.OrgnizationC != orgC)
                        {
                            throw new Exception("当前登录组织和数据所属组织不是同一个组织，数据操作失败");
                        }
                    }
                }
            }

        }
        private void OnInserting()
        {
            this.CreateDate = DateTime.Now;
            this.ModifyDate = this.CreateDate;
            if (this.Creator <= 0)
            {
                if (NHExt.Runtime.Session.SessionCache.Current != null)
                {
                    if (NHExt.Runtime.Session.SessionCache.Current.AuthContext != null)
                    {
                        this.Creator = NHExt.Runtime.Session.SessionCache.Current.AuthContext.UserID;
                    }
                }
            }
        }
        private void OnInserted()
        {
            this.IgnoreOrgFilter = false;
        }
        private void OnUpdating()
        {
            this.ModifyDate = DateTime.Now;
        }
        private void OnUpdated()
        {
            this.IgnoreOrgFilter = false;
        }
        private void OnDeleting()
        {

        }
        private void OnDeleted()
        {
            this.IgnoreOrgFilter = false;
        }

        public virtual decimal Evaluate(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                throw new Exception("表达式不能为空");
            }
            string[] fields = expression.Split(new char[6] { '+', '-', '*', '/', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            if (fields.Count() > 0)
            {
                Regex r = new Regex(@"^[1-9]\d*");//去掉数字
                List<string> fieldList = new List<string>(fields);
                fieldList.Sort((a, b) =>
                {
                    if (a.Length > b.Length)
                    {
                        return -1;
                    }
                    else if (a.Length == b.Length)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                });
                fields = fieldList.ToArray();
                foreach (string field in fields)
                {
                    //如果是数字就不管
                    if (r.IsMatch(field))
                    {
                        continue;
                    }
                    decimal objV = 0;
                    if (field.StartsWith("$."))
                    {
                        //调用服务获取数据$.IWEHAVE.ERP.PubBP.Agent.GetYearDaysBPProxy(Month:12,Year:2015)
                        string newStr = field.Replace("$.", "");
                        string bpStr = newStr.Substring(0, newStr.IndexOf("{"));
                        string argStr = newStr.Substring(newStr.IndexOf("{") + 1, (newStr.LastIndexOf("}") - newStr.IndexOf("{") - 1));
                        NHExt.Runtime.Proxy.AgentInvoker invoker = new NHExt.Runtime.Proxy.AgentInvoker();
                        invoker.AssemblyName = bpStr;
                        invoker.DllName = bpStr.Substring(0, bpStr.IndexOf("Agent.")) + "Agent.dll";
                        string[] args = argStr.Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (args.Count() > 0)
                        {
                            foreach (string arg in args)
                            {
                                //$.IWEHAVE.ERP.PubBP.Agent.GetYearDaysBPProxy(Month:#.PMerchantRent.Rent,Year:2015)
                                string fieldName = arg.Substring(0, arg.IndexOf(":"));
                                object fieldValue = new object();
                                if (!arg.Contains("@"))
                                {
                                    throw new Exception("表达式解析错误，没有配置自定义函数参数类型");

                                }
                                string fieldArgV = arg.Substring(arg.IndexOf(":") + 1, (arg.IndexOf("@") - arg.IndexOf(":") - 1));//参数值
                                string fieldType = arg.Substring(arg.IndexOf("@") + 1);//参数类型
                                if (fieldArgV.StartsWith("#."))//变量的话需要先获取变量
                                {
                                    fieldArgV = fieldArgV.Replace("#.", "");
                                    var objValue = this.GetData(fieldArgV);
                                    if (objValue != null)
                                    {
                                        fieldValue = this.GetValue(objValue, fieldType);
                                    }
                                }
                                else
                                {
                                    fieldValue = this.GetValue(fieldArgV, fieldType);
                                }
                                invoker.AppendField(new NHExt.Runtime.Proxy.PropertyField() { FieldName = fieldName, FieldValue = fieldValue });
                            }
                        }
                        Object obj = invoker.Do();
                        if (obj != null)
                        {
                            objV = Convert.ToDecimal(obj);
                        }
                    }
                    else
                    {
                        var obj = this.GetData(field);
                        if (obj != null)
                        {
                            objV = Convert.ToDecimal(obj);
                        }
                    }
                    expression = expression.Replace(field, objV.ToString());
                }
            }
            try
            {
                NHExt.Runtime.Util.RPN rpn = new NHExt.Runtime.Util.RPN();
                rpn.Parse(expression);
                return Convert.ToDecimal(rpn.Evaluate());
            }
            catch (Exception ex)
            {
                throw new Exception("计算公式格式错误");
            }
        }

        private object GetValue(object value, string typeStr)
        {
            object returnValue;
            switch (typeStr)
            {
                case "bool":
                    returnValue = Convert.ToBoolean(value);
                    break;
                case "byte":
                    returnValue = Convert.ToByte(value);
                    break;
                case "char":
                    returnValue = Convert.ToChar(value);
                    break;
                case "DateTime":
                    returnValue = Convert.ToDateTime(value);
                    break;
                case "decimal":
                    returnValue = Convert.ToDecimal(value);
                    break;
                case "double":
                    returnValue = Convert.ToDouble(value);
                    break;
                case "short":
                    returnValue = Convert.ToInt16(value);
                    break;
                case "int":
                    returnValue = Convert.ToInt32(value);
                    break;
                case "long":
                    returnValue = Convert.ToInt64(value);
                    break;
                case "string":
                    returnValue = Convert.ToString(value);
                    break;
                case "object":
                    returnValue = value;
                    break;
                default:
                    returnValue = value;
                    break;
            }
            return returnValue;
        }
    }
}

