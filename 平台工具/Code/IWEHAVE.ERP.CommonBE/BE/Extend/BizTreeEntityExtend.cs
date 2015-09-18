using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHExt.Runtime.EntityAttribute;
using NHExt.Runtime.Model;
using NHExt.Runtime.Session;
namespace IWEHAVE.ERP.CommonBE
{
    public partial class BizTreeEntity
    {
        protected override bool IsBizKeyCheck
        {
            get
            {
                return false;
            }
        }
        private void FromDTOImpl(Deploy.BizTreeEntityDTO dto)
        {
            
        }
        private void ToDTOImpl(Deploy.BizTreeEntityDTO dto)
        {

        }
        private void OnSetDefaultValue()
        {
            if (this.Parent == null)
            {
                this.FullName = this.Name;
                this.Level = 0;
                this.PID = 0;
            }
            else
            {
                this.FullName = this.Parent.FullName + "." + this.Name;
                this.Level = this.Parent.Level + 1;
                this.PID = this.Parent.ID;
            }
            this.resetBizTree();
        }
        private void OnValidate()
        {

            if (string.IsNullOrEmpty(this.Name))
            {
                throw new Exception("树节点Name不能为空");
            }
        }
        private void OnInserting()
        {
            this.BizTreeCheck();
        }
        private void OnInserted()
        {

        }
        private void OnUpdating()
        {
            this.BizTreeCheck();
        }
        private void OnUpdated()
        {

        }
        private void OnDeleting()
        {

        }
        private void OnDeleted()
        {

        }

        private BizTreeEntityCollection _children = null;
        public virtual BizTreeEntityCollection GetChildren(bool containDel)
        {

            if (this.EntityState == NHExt.Runtime.Enums.EntityState.Add)
            {
                if (_children == null) _children = new BizTreeEntityCollection();
                return _children;
            }
            else
            {
                if (this._children == null)
                {
                    _children = new BizTreeEntityCollection();
                    _children.AddRange(LoadChildrenFromDB(this.ID, containDel));
                }
                return _children;
            }
        }

        private BizTreeEntityCollection Children
        {
            get
            {
                return this.GetChildren(true);
            }
        }
        public virtual BizTreeEntity AddChildren(BizTreeEntity entity)
        {
            if (this.Children.Contains(entity))
            {
                return entity;
            }
            this.Children.Add(entity);
            this.Leaf = false;
            entity.PID = this.ID;
            entity.OrderNo = this.Children.Count;
            if (entity.ID <= 0)
            {
                entity.EntityState = NHExt.Runtime.Enums.EntityState.Add;
                entity.ID = NHExt.Runtime.Util.EntityGuidHelper.New();
                NHExt.Runtime.Session.Session.Current.InList(entity);
            }
            return entity;
        }
        public virtual void Remove(bool isDel)
        {
            if (this.Parent != null)
            {
                this.Parent.RemoveChildren(this, isDel);
            }
            else
            {
                this.RemoveAll(isDel);
                if (isDel)
                {
                    NHExt.Runtime.Session.Session.Current.Remove(this);
                }
                else
                {
                    this.IsDelete = true;
                }
            }
        }
        public virtual void RemoveChildren(BizTreeEntity entity, bool isDel = true)
        {
            if (!this.Children.Contains(entity))
            {
                return;
            }
            this.Children.Remove(entity);
            if (this.Children.Count == 0)
            {
                this.Leaf = true;
            }
            if (entity.ID > 0)
            {
                if (isDel)
                {
                    NHExt.Runtime.Session.Session.Current.Remove(entity);
                }
                else
                {
                    entity.IsDelete = true;
                }
            }
            entity.RemoveAll(isDel);
        }
        public virtual void RemoveAll(bool isDel)
        {
            this.Leaf = true;
            for (int i = this.Children.Count - 1; i >= 0; i--)
            {
                BizTreeEntity entity = this.Children[i];
                this.Children.Remove(entity);
                if (entity.ID > 0)
                {
                    if (isDel)
                    {
                        NHExt.Runtime.Session.Session.Current.Remove(entity);
                    }
                    else
                    {
                        entity.IsDelete = true;
                    }
                }
                entity.RemoveAll(isDel);
            }
        }
        public virtual void MoveNode(BizTreeEntity parentNode)
        {
            if (this.Parent == parentNode) return;
            if (this.Parent != null)
            {
                this.Parent.EntityState = NHExt.Runtime.Enums.EntityState.Update;
                NHExt.Runtime.Session.Session.Current.InList(this.Parent);
            }
            this.Parent.Children.Remove(this);
            parentNode.AddChildren(this);
        }

        private List<BizTreeEntity> LoadChildrenFromDB(long id, bool containDel)
        {
            List<BizTreeEntity> lst = new List<BizTreeEntity>();
            string hql = "PID=${0}$ and IsDelete=0 order by OrderNo";
            if (containDel)
            {
                hql = "PID=${0}$ order by OrderNo";
            }

            List<object> paramList = new List<object>();
            paramList.Add(this.ID);
            List<BaseEntity> queryList = NHExt.Runtime.Query.EntityFinder.FindAll(this.GetType(), hql, paramList);
            if (queryList != null)
            {
                foreach (BaseEntity queryEntity in queryList)
                {
                    lst.Add(queryEntity as BizTreeEntity);
                }
            }
            return lst;
        }

        public virtual BizTreeEntity Parent
        {
            get
            {
                if (this.PID == null || this.PID <= 0)
                {
                    return null;
                }
                else
                {
                    return NHExt.Runtime.Query.EntityFinder.FindById(this.GetType(), this.PID ?? 0) as BizTreeEntity;
                }
            }
        }

        private void resetBizTree()
        {

            if (this.Children == null || this.Children.Count == 0)
            {
                this.Leaf = true;
            }
            else
            {
                int index = 0;
                this.Leaf = false;
                foreach (BizTreeEntity childEntity in this.Children)
                {
                    if (childEntity.ID <= 0)
                    {
                        childEntity.EntityState = NHExt.Runtime.Enums.EntityState.Add;
                        childEntity.ID = NHExt.Runtime.Util.EntityGuidHelper.New();
                        NHExt.Runtime.Session.Session.Current.InList(childEntity);
                    }
                    if (this.OrignalData != null)
                    {
                        if (this.FullName != this.OrignalData.FullName)
                        {
                            childEntity.FullName = "";
                        }
                    }
                    childEntity.PID = this.ID;
                    if (childEntity.OrderNo <= 0)
                    {
                        childEntity.OrderNo = index;
                    }
                    index++;
                    childEntity.resetBizTree();

                }
            }

        }

        /// <summary>
        /// 校验IsDelete
        /// </summary>
        private void BizTreeCheck()
        {
            List<ColumnDescriptionAttribute> columnAttributeList = NHExt.Runtime.Model.BaseEntity.GetPropertyByAttrList(this);
            if (columnAttributeList != null)
            {

                string hql = string.Empty;
                List<object> paramList = new List<object>();
                string errMsg = string.Empty;
                foreach (NHExt.Runtime.EntityAttribute.ColumnDescriptionAttribute attr in columnAttributeList)
                {

                    //硬编码，费组织字段如果有勾选为业务主键的话则需要进行校验
                    if (attr.IsBizKey)
                    {
                        if (string.IsNullOrEmpty(hql))
                        {
                            hql = "ID != ${0}$";
                            paramList.Add(this.ID);
                            errMsg = "主键组合为";
                        }
                        object obj = this.GetData(attr.Code);
                        if (obj == null)
                        {
                            hql += " and " + attr.Code + " is null";
                        }
                        else
                        {
                            hql += " and " + attr.Code + "=${" + paramList.Count + "}$";
                            paramList.Add(obj);
                        }

                        errMsg += " " + attr.Description + ",";

                    }
                }
                hql += " and IsDelete=0";
                BaseEntity be = NHExt.Runtime.Query.EntityFinder.Find(this.GetType(), hql, paramList);
                if (be != null)
                {
                    errMsg = errMsg.Substring(0, errMsg.Length - 1);
                    errMsg += "的数据已经存在";
                    throw new Exception(errMsg);
                }


            }
        }
    }



    #region 用到的类

    public class BizTreeEntityCollection : List<IWEHAVE.ERP.CommonBE.BizTreeEntity>
    {

    }

    #endregion
}

