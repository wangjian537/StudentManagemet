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
    /// 数据访问类:College
    /// </summary>
    public partial class CollegeService
    {
        public CollegeService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string 学院号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 学院表");
            strSql.Append(" where 学院号=@学院号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@学院号", SqlDbType.VarChar,10)			};
            parameters[0].Value = 学院号;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.College model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 学院表(");
            strSql.Append("学院号,学院,排序,是否启用,备注)");
            strSql.Append(" values (");
            strSql.Append("@学院号,@学院,@排序,@是否启用,@备注)");
            SqlParameter[] parameters = {
					new SqlParameter("@学院号", SqlDbType.VarChar,10),
					new SqlParameter("@学院", SqlDbType.VarChar,20),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50)};
            parameters[0].Value = model.学院号;
            parameters[1].Value = model.学院;
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
        public bool Update(MUSE.Model.College model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 学院表 set ");
            strSql.Append("学院=@学院,");
            strSql.Append("排序=@排序,");
            strSql.Append("是否启用=@是否启用,");
            strSql.Append("备注=@备注");
            strSql.Append(" where 学院号=@学院号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@学院", SqlDbType.VarChar,20),
					new SqlParameter("@排序", SqlDbType.Int,4),
					new SqlParameter("@是否启用", SqlDbType.VarChar,2),
					new SqlParameter("@备注", SqlDbType.VarChar,50),
					new SqlParameter("@学院号", SqlDbType.VarChar,10)};
            parameters[0].Value = model.学院;
            parameters[1].Value = model.排序;
            parameters[2].Value = model.是否启用;
            parameters[3].Value = model.备注;
            parameters[4].Value = model.学院号;

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
        public bool Delete(string 学院号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 学院表 ");
            strSql.Append(" where 学院号=@学院号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@学院号", SqlDbType.VarChar,10)			};
            parameters[0].Value = 学院号;

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
        public bool DeleteList(string 学院号list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 学院表 ");
            strSql.Append(" where 学院号 in (" + 学院号list + ")  ");
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
        public MUSE.Model.College GetModel(string 学院号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 学院号,学院,排序,是否启用,备注 from 学院表 ");
            strSql.Append(" where 学院号=@学院号 ");
            SqlParameter[] parameters = {
					new SqlParameter("@学院号", SqlDbType.VarChar,10)			};
            parameters[0].Value = 学院号;

            MUSE.Model.College model = new MUSE.Model.College();
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
        public MUSE.Model.College DataRowToModel(DataRow row)
        {
            MUSE.Model.College model = new MUSE.Model.College();
            if (row != null)
            {
                if (row["学院号"] != null)
                {
                    model.学院号 = row["学院号"].ToString();
                }
                if (row["学院"] != null)
                {
                    model.学院 = row["学院"].ToString();
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
            strSql.Append("select 学院号,学院,排序,是否启用,备注 ");
            strSql.Append(" FROM 学院表 ");
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
            strSql.Append(" 学院号,学院,排序,是否启用,备注 ");
            strSql.Append(" FROM 学院表 ");
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
            strSql.Append("select count(1) FROM 学院表 ");
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
                strSql.Append("order by T.学院号 desc");
            }
            strSql.Append(")AS Row, T.*  from 学院表 T ");
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
            parameters[0].Value = "学院表";
            parameters[1].Value = "学院号";
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
