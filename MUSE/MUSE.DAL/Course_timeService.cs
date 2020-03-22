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
    /// 数据访问类:Course_time
    /// </summary>
    public partial class Course_timeService
    {
        public Course_timeService()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 课程时间表");
            strSql.Append(" where 授课号=@授课号 and 上课时间代码=@上课时间代码 and 上课周次代码=@上课周次代码 and 教室代码=@教室代码 and 预留字段1=@预留字段1 and 预留字段2=@预留字段2 and 预留字段3=@预留字段3 and 预留字段4=@预留字段4 and 预留字段5=@预留字段5 ");
            SqlParameter[] parameters = {
					new SqlParameter("@授课号", SqlDbType.Int,4),
					new SqlParameter("@上课时间代码", SqlDbType.VarChar,20),
					new SqlParameter("@上课周次代码", SqlDbType.VarChar,20),
					new SqlParameter("@教室代码", SqlDbType.VarChar,20),
					new SqlParameter("@预留字段1", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段2", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段3", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段4", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段5", SqlDbType.VarChar,50)			};
            parameters[0].Value = 授课号;
            parameters[1].Value = 上课时间代码;
            parameters[2].Value = 上课周次代码;
            parameters[3].Value = 教室代码;
            parameters[4].Value = 预留字段1;
            parameters[5].Value = 预留字段2;
            parameters[6].Value = 预留字段3;
            parameters[7].Value = 预留字段4;
            parameters[8].Value = 预留字段5;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(MUSE.Model.Course_time model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 课程时间表(");
            strSql.Append("授课号,上课时间代码,上课周次代码,教室代码)");
            strSql.Append(" values (");
            strSql.Append("@授课号,@上课时间代码,@上课周次代码,@教室代码)");
            SqlParameter[] parameters = {
					new SqlParameter("@授课号", SqlDbType.Int,4),
					new SqlParameter("@上课时间代码", SqlDbType.VarChar,20),
					new SqlParameter("@上课周次代码", SqlDbType.VarChar,20),
					new SqlParameter("@教室代码", SqlDbType.VarChar,20)};
            parameters[0].Value = model._teachCode;
            parameters[1].Value = model._schooltimeCode;
            parameters[2].Value = model._teachWeekCode;
            parameters[3].Value = model._classroomCode;

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
        public bool Update(MUSE.Model.Course_time model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 课程时间表 set ");
            strSql.Append("授课号=@授课号,");
            strSql.Append("上课时间代码=@上课时间代码,");
            strSql.Append("上课周次代码=@上课周次代码,");
            strSql.Append("教室代码=@教室代码");
            strSql.Append(" where 授课号=@授课号 and 上课时间代码=@上课时间代码 and 上课周次代码=@上课周次代码 and 教室代码=@教室代码 and 预留字段1=@预留字段1 and 预留字段2=@预留字段2 and 预留字段3=@预留字段3 and 预留字段4=@预留字段4 and 预留字段5=@预留字段5 ");
            SqlParameter[] parameters = {
					new SqlParameter("@授课号", SqlDbType.Int,4),
					new SqlParameter("@上课时间代码", SqlDbType.VarChar,20),
					new SqlParameter("@上课周次代码", SqlDbType.VarChar,20),
					new SqlParameter("@教室代码", SqlDbType.VarChar,20)};
            parameters[0].Value = model._teachCode;
            parameters[1].Value = model._schooltimeCode;
            parameters[2].Value = model._teachWeekCode;
            parameters[3].Value = model._classroomCode;

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
        public bool Delete(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 课程时间表 ");
            strSql.Append(" where 授课号=@授课号 and 上课时间代码=@上课时间代码 and 上课周次代码=@上课周次代码 and 教室代码=@教室代码 and 预留字段1=@预留字段1 and 预留字段2=@预留字段2 and 预留字段3=@预留字段3 and 预留字段4=@预留字段4 and 预留字段5=@预留字段5 ");
            SqlParameter[] parameters = {
					new SqlParameter("@授课号", SqlDbType.Int,4),
					new SqlParameter("@上课时间代码", SqlDbType.VarChar,20),
					new SqlParameter("@上课周次代码", SqlDbType.VarChar,20),
					new SqlParameter("@教室代码", SqlDbType.VarChar,20),
					new SqlParameter("@预留字段1", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段2", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段3", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段4", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段5", SqlDbType.VarChar,50)			};
            parameters[0].Value = 授课号;
            parameters[1].Value = 上课时间代码;
            parameters[2].Value = 上课周次代码;
            parameters[3].Value = 教室代码;
            parameters[4].Value = 预留字段1;
            parameters[5].Value = 预留字段2;
            parameters[6].Value = 预留字段3;
            parameters[7].Value = 预留字段4;
            parameters[8].Value = 预留字段5;

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
        public MUSE.Model.Course_time GetModel(int 授课号, string 上课时间代码, string 上课周次代码, string 教室代码, string 预留字段1, string 预留字段2, string 预留字段3, string 预留字段4, string 预留字段5)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 授课号,上课时间代码,上课周次代码,教室代码 from 课程时间表 ");
            strSql.Append(" where 授课号=@授课号 and 上课时间代码=@上课时间代码 and 上课周次代码=@上课周次代码 and 教室代码=@教室代码 and 预留字段1=@预留字段1 and 预留字段2=@预留字段2 and 预留字段3=@预留字段3 and 预留字段4=@预留字段4 and 预留字段5=@预留字段5 ");
            SqlParameter[] parameters = {
					new SqlParameter("@授课号", SqlDbType.Int,4),
					new SqlParameter("@上课时间代码", SqlDbType.VarChar,20),
					new SqlParameter("@上课周次代码", SqlDbType.VarChar,20),
					new SqlParameter("@教室代码", SqlDbType.VarChar,20),
					new SqlParameter("@预留字段1", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段2", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段3", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段4", SqlDbType.VarChar,50),
					new SqlParameter("@预留字段5", SqlDbType.VarChar,50)			};
            parameters[0].Value = 授课号;
            parameters[1].Value = 上课时间代码;
            parameters[2].Value = 上课周次代码;
            parameters[3].Value = 教室代码;
            parameters[4].Value = 预留字段1;
            parameters[5].Value = 预留字段2;
            parameters[6].Value = 预留字段3;
            parameters[7].Value = 预留字段4;
            parameters[8].Value = 预留字段5;

            MUSE.Model.Course_time model = new MUSE.Model.Course_time();
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
        public MUSE.Model.Course_time DataRowToModel(DataRow row)
        {
            MUSE.Model.Course_time model = new MUSE.Model.Course_time();
            if (row != null)
            {
                if (row["授课号"] != null && row["授课号"].ToString() != "")
                {
                    model._teachCode = int.Parse(row["授课号"].ToString());
                }
                if (row["上课时间代码"] != null)
                {
                    model._schooltimeCode = row["上课时间代码"].ToString();
                }
                if (row["上课周次代码"] != null)
                {
                    model._teachWeekCode = row["上课周次代码"].ToString();
                }
                if (row["教室代码"] != null)
                {
                    model._classroomCode = row["教室代码"].ToString();
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
            strSql.Append("select 授课号,上课时间代码,上课周次代码,教室代码 ");
            strSql.Append(" FROM 课程时间表 ");
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
            strSql.Append(" 授课号,上课时间代码,上课周次代码,教室代码 ");
            strSql.Append(" FROM 课程时间表 ");
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
            strSql.Append("select count(1) FROM 课程时间表 ");
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
                strSql.Append("order by T.预留字段5 desc");
            }
            strSql.Append(")AS Row, T.*  from 课程时间表 T ");
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
            parameters[0].Value = "课程时间表";
            parameters[1].Value = "预留字段5";
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
