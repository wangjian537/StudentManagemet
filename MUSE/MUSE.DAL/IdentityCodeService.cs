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
    /// 数据访问类:IdentityCode
    /// </summary>
    public partial class IdentityCodeService
    {
        public IdentityCodeService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 身份代码)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 身份代码表");
            strSql.Append(" where 身份代码=@身份代码 ");
            SqlParameter[] parameters = {
					new SqlParameter("@身份代码", SqlDbType.VarChar,10)			};
            parameters[0].Value = 身份代码;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.IdentityCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 身份代码表(");
            strSql.Append("身份代码,身份)");
            strSql.Append(" values (");
            strSql.Append("@身份代码,@身份)");
            SqlParameter[] parameters = {
					new SqlParameter("@身份代码", SqlDbType.VarChar,10),
					new SqlParameter("@身份", SqlDbType.VarChar,20)};
            parameters[0].Value = model.身份代码;
            parameters[1].Value = model.身份;

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
        public bool Update(MUSE.Model.IdentityCode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 身份代码表 set ");
            strSql.Append("身份=@身份");
            strSql.Append(" where 身份代码=@身份代码 ");
            SqlParameter[] parameters = {
					new SqlParameter("@身份", SqlDbType.VarChar,20),
					new SqlParameter("@身份代码", SqlDbType.VarChar,10)};
            parameters[0].Value = model.身份;
            parameters[1].Value = model.身份代码;

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
        public bool Delete(string 身份代码)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 身份代码表 ");
            strSql.Append(" where 身份代码=@身份代码 ");
            SqlParameter[] parameters = {
					new SqlParameter("@身份代码", SqlDbType.VarChar,10)			};
            parameters[0].Value = 身份代码;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string 身份代码list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 身份代码表 ");
            strSql.Append(" where 身份代码 in (" + 身份代码list + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public MUSE.Model.IdentityCode GetModel(string 身份代码)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 身份代码,身份 from 身份代码表 ");
            strSql.Append(" where 身份代码=@身份代码 ");
            SqlParameter[] parameters = {
					new SqlParameter("@身份代码", SqlDbType.VarChar,10)			};
            parameters[0].Value = 身份代码;

            MUSE.Model.IdentityCode model = new MUSE.Model.IdentityCode();
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
        public MUSE.Model.IdentityCode DataRowToModel(DataRow row)
        {
            MUSE.Model.IdentityCode model = new MUSE.Model.IdentityCode();
            if (row != null)
            {
                if (row["身份代码"] != null)
                {
                    model.身份代码 = row["身份代码"].ToString();
                }
                if (row["身份"] != null)
                {
                    model.身份 = row["身份"].ToString();
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
            strSql.Append("select 身份代码,身份 ");
            strSql.Append(" FROM 身份代码表 ");
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
            strSql.Append(" 身份代码,身份 ");
            strSql.Append(" FROM 身份代码表 ");
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
            strSql.Append("select count(1) FROM 身份代码表 ");
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
                strSql.Append("order by T.身份代码 desc");
            }
            strSql.Append(")AS Row, T.*  from 身份代码表 T ");
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
            parameters[0].Value = "身份代码表";
            parameters[1].Value = "身份代码";
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
