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
    /// 数据访问类:membership
    /// </summary>
    public partial class membershipService
    {
        public membershipService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 用户名, string 密码, string 用户类型)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from membership");
            strSql.Append(" where 用户名=@用户名 and 密码=@密码 and 用户类型=@用户类型 ");
            SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@用户类型", SqlDbType.VarChar,6)			};
            parameters[0].Value = 用户名;
            parameters[1].Value = 密码;
            parameters[2].Value = 用户类型;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.membership model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into membership(");
            strSql.Append("用户名,密码,用户类型)");
            strSql.Append(" values (");
            strSql.Append("@用户名,@密码,@用户类型)");
            SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@用户类型", SqlDbType.VarChar,6)};
            parameters[0].Value = model.user;
            parameters[1].Value = model.password;
            parameters[2].Value = model.userType;

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
        public bool Update(MUSE.Model.membership model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update membership set ");
            strSql.Append("用户名=@用户名,");
            strSql.Append("密码=@密码,");
            strSql.Append("用户类型=@用户类型");
            strSql.Append(" where 用户名=@用户名 and 密码=@密码 and 用户类型=@用户类型 ");
            SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@用户类型", SqlDbType.VarChar,6)};
            parameters[0].Value = model.user;
            parameters[1].Value = model.password;
            parameters[2].Value = model.userType;

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
        public bool Delete(string 用户名, string 密码, string 用户类型)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from membership ");
            strSql.Append(" where 用户名=@用户名 and 密码=@密码 and 用户类型=@用户类型 ");
            SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@用户类型", SqlDbType.VarChar,6)			};
            parameters[0].Value = 用户名;
            parameters[1].Value = 密码;
            parameters[2].Value = 用户类型;

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
        public MUSE.Model.membership GetModel(string 用户名, string 密码, string 用户类型)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 用户名,密码,用户类型 from membership ");
            strSql.Append(" where 用户名=@用户名 and 密码=@密码 and 用户类型=@用户类型 ");
            SqlParameter[] parameters = {
					new SqlParameter("@用户名", SqlDbType.VarChar,20),
					new SqlParameter("@密码", SqlDbType.VarChar,50),
					new SqlParameter("@用户类型", SqlDbType.VarChar,6)			};
            parameters[0].Value = 用户名;
            parameters[1].Value = 密码;
            parameters[2].Value = 用户类型;

            MUSE.Model.membership model = new MUSE.Model.membership();
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
        public MUSE.Model.membership DataRowToModel(DataRow row)
        {
            MUSE.Model.membership model = new MUSE.Model.membership();
            if (row != null)
            {
                if (row["用户名"] != null)
                {
                    model.user = row["用户名"].ToString();
                }
                if (row["密码"] != null)
                {
                    model.password = row["密码"].ToString();
                }
                if (row["用户类型"] != null)
                {
                    model.userType = row["用户类型"].ToString();
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
            strSql.Append("select 用户名,密码,用户类型 ");
            strSql.Append(" FROM membership ");
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
            strSql.Append(" 用户名,密码,用户类型 ");
            strSql.Append(" FROM membership ");
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
            strSql.Append("select count(1) FROM membership ");
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
                strSql.Append("order by T.用户类型 desc");
            }
            strSql.Append(")AS Row, T.*  from membership T ");
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
            parameters[0].Value = "membership";
            parameters[1].Value = "用户类型";
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
