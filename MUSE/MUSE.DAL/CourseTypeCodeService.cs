using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MUSE.Model;
using System.Data;
using System.Data.SqlClient;

namespace MUSE.DAL
{
    /// <summary>
    /// 数据访问类:CourseTypeCode
    /// </summary>
    public partial class CourseTypeCodeService
    {
        public CourseTypeCodeService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 课程类型代码, string 课程类型, int 排序, string 是否启用, string 备注)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 课程类型代码表");
            strSql.Append(" where 课程类型代码=@课程类型代码 and 课程类型=@课程类型 and 排序=@排序 and 是否启用=@是否启用 and 备注=@备注 ");
            SqlParameter[] parameters = {
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,2),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)			};
            parameters[0].Value = 课程类型代码;
            parameters[1].Value = 课程类型;
            parameters[2].Value = 排序;
            parameters[3].Value = 是否启用;
            parameters[4].Value = 备注;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.CourseTypeCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 课程类型代码表(");
            strSql.Append("课程类型代码,课程类型,排序,是否启用,备注)");
            strSql.Append(" values (");
            strSql.Append("@课程类型代码,@课程类型,@排序,@是否启用,@备注)");
            SqlParameter[] parameters = {
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,2),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)};
            parameters[0].Value = model.课程类型代码;
            parameters[1].Value = model.课程类型;
            parameters[2].Value = model.排序;
            parameters[3].Value = model.是否启用;
            parameters[4].Value = model.备注;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MUSE.Model.CourseTypeCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 课程类型代码表 set ");
            strSql.Append("课程类型代码=@课程类型代码,");
            strSql.Append("课程类型=@课程类型,");
            strSql.Append("排序=@排序,");
            strSql.Append("是否启用=@是否启用,");
            strSql.Append("备注=@备注");
            strSql.Append(" where 课程类型代码=@课程类型代码 and 课程类型=@课程类型 and 排序=@排序 and 是否启用=@是否启用 and 备注=@备注 ");
            SqlParameter[] parameters = {
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,2),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)};
            parameters[0].Value = model.课程类型代码;
            parameters[1].Value = model.课程类型;
            parameters[2].Value = model.排序;
            parameters[3].Value = model.是否启用;
            parameters[4].Value = model.备注;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string 课程类型代码, string 课程类型, int 排序, string 是否启用, string 备注)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 课程类型代码表 ");
            strSql.Append(" where 课程类型代码=@课程类型代码 and 课程类型=@课程类型 and 排序=@排序 and 是否启用=@是否启用 and 备注=@备注 ");
            SqlParameter[] parameters = {
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,2),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)			};
            parameters[0].Value = 课程类型代码;
            parameters[1].Value = 课程类型;
            parameters[2].Value = 排序;
            parameters[3].Value = 是否启用;
            parameters[4].Value = 备注;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MUSE.Model.CourseTypeCode GetModel(string 课程类型代码, string 课程类型, int 排序, string 是否启用, string 备注)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 课程类型代码,课程类型,排序,是否启用,备注 from 课程类型代码表 ");
            strSql.Append(" where 课程类型代码=@课程类型代码 and 课程类型=@课程类型 and 排序=@排序 and 是否启用=@是否启用 and 备注=@备注 ");
            SqlParameter[] parameters = {
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,2),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)			};
            parameters[0].Value = 课程类型代码;
            parameters[1].Value = 课程类型;
            parameters[2].Value = 排序;
            parameters[3].Value = 是否启用;
            parameters[4].Value = 备注;

            MUSE.Model.CourseTypeCode model = new MUSE.Model.CourseTypeCode();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MUSE.Model.CourseTypeCode DataRowToModel(DataRow row)
        {
            MUSE.Model.CourseTypeCode model = new MUSE.Model.CourseTypeCode();
            if (row != null)
            {
                if (row["课程类型代码"] != null)
                {
                    model.课程类型代码 = row["课程类型代码"].ToString();
                }
                if (row["课程类型"] != null)
                {
                    model.课程类型 = row["课程类型"].ToString();
                }
                if (row["排序"] != null && row["排序"].ToString() != "")
                {
                    model.排序 = int.Parse(row["排序"].ToString());
                }
                if (row["是否启用"] != null)
                {
                    model.是否启用 = row["是否启用"].ToString();
                }
                if (row["备注"] != null)
                {
                    model.备注 = row["备注"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select 课程类型代码,课程类型,排序,是否启用,备注 ");
            strSql.Append(" FROM 课程类型代码表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" 课程类型代码,课程类型,排序,是否启用,备注 ");
            strSql.Append(" FROM 课程类型代码表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM 课程类型代码表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.备注 desc");
            }
            strSql.Append(")AS Row, T.*  from 课程类型代码表 T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "课程类型代码表";
            parameters[1].Value = "备注";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
