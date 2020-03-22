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
    /// Course_time
    /// </summary>
    public partial class Course_timeManager
    {
        private readonly MUSE.DAL.Course_timeService dal = new MUSE.DAL.Course_timeService();
        public Course_timeManager()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {
            return dal.Exists(授课号, 上课时间代码, 上课周次代码, 教室代码, 预留字段1, 预留字段2, 预留字段3, 预留字段4, 预留字段5);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.Course_time model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MUSE.Model.Course_time model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {

            return dal.Delete(授课号, 上课时间代码, 上课周次代码, 教室代码, 预留字段1, 预留字段2, 预留字段3, 预留字段4, 预留字段5);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MUSE.Model.Course_time GetModel(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {

            return dal.GetModel(授课号, 上课时间代码, 上课周次代码, 教室代码, 预留字段1, 预留字段2, 预留字段3, 预留字段4, 预留字段5);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public MUSE.Model.Course_time GetModelByCache(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {

            string CacheKey = "Course_timeModel-" + 授课号 + 上课时间代码 + 上课周次代码 + 教室代码 + 预留字段1 + 预留字段2 + 预留字段3 + 预留字段4 + 预留字段5;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(授课号, 上课时间代码, 上课周次代码, 教室代码, 预留字段1, 预留字段2, 预留字段3, 预留字段4, 预留字段5);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (MUSE.Model.Course_time)objModel;
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
        public List<MUSE.Model.Course_time> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MUSE.Model.Course_time> DataTableToList(DataTable dt)
        {
            List<MUSE.Model.Course_time> modelList = new List<MUSE.Model.Course_time>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MUSE.Model.Course_time model;
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
