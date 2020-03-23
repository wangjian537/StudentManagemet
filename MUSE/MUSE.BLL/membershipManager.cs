using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MUSE.Model;
using MUSE.DAL;
using System.Data;
using Maticsoft.Common;

namespace MUSE.BLL
{
    /// <summary>
    /// membership
    /// </summary>
    public partial class membershipManager
    {
        private readonly MUSE.DAL.membershipService dal = new MUSE.DAL.membershipService();
        public membershipManager()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 用户名, string 密码, string 用户类型)
        {
            return dal.Exists(用户名, 密码, 用户类型);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.membership model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MUSE.Model.membership model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string 用户名, string 密码, string 用户类型)
        {

            return dal.Delete(用户名, 密码, 用户类型);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MUSE.Model.membership GetModel(string 用户名, string 密码, string 用户类型)
        {

            return dal.GetModel(用户名, 密码, 用户类型);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public MUSE.Model.membership GetModelByCache(string 用户名, string 密码, string 用户类型)
        {

            string CacheKey = "membershipModel-" + 用户名 + 密码 + 用户类型;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(用户名, 密码, 用户类型);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (MUSE.Model.membership)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MUSE.Model.membership> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MUSE.Model.membership> DataTableToList(DataTable dt)
        {
            List<MUSE.Model.membership> modelList = new List<MUSE.Model.membership>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MUSE.Model.membership model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
