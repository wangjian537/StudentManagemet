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
    /// 数据访问类:Course
    /// </summary>
    public partial class CourseService
    {
        public CourseService()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int 课程号)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from 课程表");
            strSql.Append(" where 课程号=@课程号");
            SqlParameter[] parameters = {
					new SqlParameter("@课程号", SqlDbType.Int,4)
			};
            parameters[0].Value = 课程号;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MUSE.Model.Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 课程表(");
            strSql.Append("课程名,课程学分,课程学时,课程类型,课程类型代码,学院号,学院,开课时间,课程封面,备注)");
            strSql.Append(" values (");
            strSql.Append("@课程名,@课程学分,@课程学时,@课程类型,@课程类型代码,@学院号,@学院,@开课时间,@课程封面,@备注)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@课程名", SqlDbType.VarChar,50),
					new SqlParameter("@课程学分", SqlDbType.Float,8),
					new SqlParameter("@课程学时", SqlDbType.Int,4),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,50),
					new SqlParameter("@学院号", SqlDbType.VarChar,50),
					new SqlParameter("@学院", SqlDbType.VarChar,50),
					new SqlParameter("@开课时间", SqlDbType.VarChar,50),
					new SqlParameter("@课程封面", SqlDbType.VarChar,50),
					new SqlParameter("@备注", SqlDbType.VarChar,50)};
            parameters[0].Value = model._Course;
            parameters[1].Value = model.CourseCredit;
            parameters[2].Value = model._coursePeriod;
            parameters[3].Value = model._courseType;
            parameters[4].Value = model.CourseTypeCode;
            parameters[5].Value = model._academyCode;
            parameters[6].Value = model._academy;
            parameters[7].Value = model._courseBeginTime;
            parameters[8].Value = model._courseCover;
            parameters[9].Value = model._note;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(MUSE.Model.Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update 课程表 set ");
            strSql.Append("课程名=@课程名,");
            strSql.Append("课程学分=@课程学分,");
            strSql.Append("课程学时=@课程学时,");
            strSql.Append("课程类型=@课程类型,");
            strSql.Append("课程类型代码=@课程类型代码,");
            strSql.Append("学院号=@学院号,");
            strSql.Append("学院=@学院,");
            strSql.Append("开课时间=@开课时间,");
            strSql.Append("课程封面=@课程封面,");
            strSql.Append("备注=@备注");
            strSql.Append(" where 课程号=@课程号");
            SqlParameter[] parameters = {
					new SqlParameter("@课程名", SqlDbType.VarChar,50),
					new SqlParameter("@课程学分", SqlDbType.Float,8),
					new SqlParameter("@课程学时", SqlDbType.Int,4),
					new SqlParameter("@课程类型", SqlDbType.VarChar,10),
					new SqlParameter("@课程类型代码", SqlDbType.VarChar,50),
					new SqlParameter("@学院号", SqlDbType.VarChar,50),
					new SqlParameter("@学院", SqlDbType.VarChar,50),
					new SqlParameter("@开课时间", SqlDbType.VarChar,50),
					new SqlParameter("@课程封面", SqlDbType.VarChar,50),
					new SqlParameter("@备注", SqlDbType.VarChar,50),
					new SqlParameter("@课程号", SqlDbType.Int,4)};
            parameters[0].Value = model._Course;
            parameters[1].Value = model.CourseCredit;
            parameters[2].Value = model._coursePeriod;
            parameters[3].Value = model._courseType;
            parameters[4].Value = model.CourseTypeCode;
            parameters[5].Value = model._academyCode;
            parameters[6].Value = model._academy;
            parameters[7].Value = model._courseBeginTime;
            parameters[8].Value = model._courseCover;
            parameters[9].Value = model._note;

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
        public bool Delete(int 课程号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 课程表 ");
            strSql.Append(" where 课程号=@课程号");
            SqlParameter[] parameters = {
					new SqlParameter("@课程号", SqlDbType.Int,4)
			};
            parameters[0].Value = 课程号;

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
        public bool DeleteList(string 课程号list)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 课程表 ");
            strSql.Append(" where 课程号 in (" + 课程号list + ")  ");
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
        public MUSE.Model.Course GetModel(int 课程号)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 课程号,课程名,课程学分,课程学时,课程类型,课程类型代码,学院号,学院,开课时间,课程封面,备注 from 课程表 ");
            strSql.Append(" where 课程号=@课程号");
            SqlParameter[] parameters = {
					new SqlParameter("@课程号", SqlDbType.Int,4)
			};
            parameters[0].Value = 课程号;

            MUSE.Model.Course model = new MUSE.Model.Course();
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
        public MUSE.Model.Course DataRowToModel(DataRow row)
        {
            MUSE.Model.Course model = new MUSE.Model.Course();
            if (row != null)
            {
                if (row["课程号"] != null && row["课程号"].ToString() != "")
                {
                    model._courseCode = int.Parse(row["课程号"].ToString());
                }
                if (row["课程名"] != null)
                {
                    model._Course = row["课程名"].ToString();
                }
                if (row["课程学分"] != null && row["课程学分"].ToString() != "")
                {
                    model.CourseCredit = decimal.Parse(row["课程学分"].ToString());
                }
                if (row["课程学时"] != null && row["课程学时"].ToString() != "")
                {
                    model._coursePeriod = int.Parse(row["课程学时"].ToString());
                }
                if (row["课程类型"] != null)
                {
                    model._courseType = row["课程类型"].ToString();
                }
                if (row["课程类型代码"] != null)
                {
                    model.CourseTypeCode = row["课程类型代码"].ToString();
                }
                if (row["学院号"] != null)
                {
                    model._academyCode = row["学院号"].ToString();
                }
                if (row["学院"] != null)
                {
                    model._academy = row["学院"].ToString();
                }
                if (row["开课时间"] != null)
                {
                    model._courseBeginTime = row["开课时间"].ToString();
                }
                if (row["课程封面"] != null)
                {
                    model._courseCover = row["课程封面"].ToString();
                }
                if (row["备注"] != null)
                {
                    model._note = row["备注"].ToString();
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
            strSql.Append("select 课程号,课程名,课程学分,课程学时,课程类型,课程类型代码,学院号,学院,开课时间,课程封面,备注 ");
            strSql.Append(" FROM 课程表 ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + "课程名 like \'%" + strWhere + "%\'");
            }
            System.Diagnostics.Debug.WriteLine(strSql.ToString());
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
            strSql.Append(" 课程号,课程名,课程学分,课程学时,课程类型,课程类型代码,学院号,学院,开课时间,课程封面,备注 ");
            strSql.Append(" FROM 课程表 ");
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
            strSql.Append("select count(1) FROM 课程表 ");
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
                strSql.Append("order by T.课程号 desc");
            }
            strSql.Append(")AS Row, T.*  from 课程表 T ");
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
            parameters[0].Value = "课程表";
            parameters[1].Value = "课程号";
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
