using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MUSE.Model;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MUSE.DAL
{
    /// <summary>
    /// 数据访问类:Admin
    /// </summary>
    public partial class AdminService
    {
        public AdminService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 账号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 管理员表");
            strSql.Append(" where 账号=@账号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.VarChar,20)			};
            parameters[0].Value = 账号;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 管理员表(");
            strSql.Append("账号,密码,身份,身份代码)");
            strSql.Append(" values (");
            strSql.Append("@账号,@密码,@身份,@身份代码)");
            SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@身份", SqlDbType.VarChar,10),
					new SqlParameter("@身份代码", SqlDbType.VarChar,10)};
            parameters[0].Value = model._user;
            parameters[1].Value = model._password;
            parameters[2].Value = model._status;
            parameters[3].Value = model._statusCode;

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
        public bool Update(MUSE.Model.Admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 管理员表 set ");
            strSql.Append("密码=@密码,");
            strSql.Append("身份=@身份,");
            strSql.Append("身份代码=@身份代码");
            strSql.Append(" where 账号=@账号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@身份", SqlDbType.VarChar,10),
					new SqlParameter("@身份代码", SqlDbType.VarChar,10),
					new SqlParameter("@账号", SqlDbType.VarChar,20)};
            parameters[0].Value = model._user;
            parameters[1].Value = model._password;
            parameters[2].Value = model._status;
            parameters[3].Value = model._statusCode;

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
        public bool Delete(string 账号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 管理员表 ");
            strSql.Append(" where 账号=@账号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.VarChar,20)			};
            parameters[0].Value = 账号;

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
        public bool DeleteList(string 账号list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 管理员表 ");
            strSql.Append(" where 账号 in (" + 账号list + ")  ");
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
        public MUSE.Model.Admin GetModel(string 账号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 账号,密码,身份,身份代码 from 管理员表 ");
            strSql.Append(" where 账号=@账号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@账号", SqlDbType.VarChar,20)			};
            parameters[0].Value = 账号;

            MUSE.Model.Admin model = new MUSE.Model.Admin();
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
        public MUSE.Model.Admin DataRowToModel(DataRow row)
        {
            MUSE.Model.Admin model = new MUSE.Model.Admin();
            if (row != null)
            {
                if (row["账号"] != null)
                {
                    model._user = row["账号"].ToString();
                }
                if (row["密码"] != null)
                {
                    model._password = row["密码"].ToString();
                }
                if (row["身份"] != null)
                {
                    model._status = row["身份"].ToString();
                }
                if (row["身份代码"] != null)
                {
                    model._statusCode = row["身份代码"].ToString();
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
            strSql.Append("select 账号,密码,身份,身份代码 ");
            strSql.Append(" FROM 管理员表 ");
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
            strSql.Append(" 账号,密码,身份,身份代码 ");
            strSql.Append(" FROM 管理员表 ");
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
            strSql.Append("select count(1) FROM 管理员表 ");
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
                strSql.Append("order by T.账号 desc");
            }
            strSql.Append(")AS Row, T.*  from 管理员表 T ");
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
            parameters[0].Value = "管理员表";
            parameters[1].Value = "账号";
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
