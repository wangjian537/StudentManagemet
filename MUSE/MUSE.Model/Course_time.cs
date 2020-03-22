using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
    /// Course_time:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Course_time
    {
        public Course_time()
        { }
        #region Model
        private int teachCode;                  //_授课号
        private string schooltimeCode;           // _上课时间代码
        private string teachWeekCode;         //_上课周次代码
        private string classroomCode;              //_教室代码
        /// <summary>
        /// 
        /// </summary>
        public int _teachCode
        {
            set { teachCode = value; }
            get { return teachCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _schooltimeCode
        {
            set { schooltimeCode = value; }
            get { return schooltimeCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _teachWeekCode
        {
            set { teachWeekCode = value; }
            get { return teachWeekCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _classroomCode
        {
            set { classroomCode = value; }
            get { return classroomCode; }
        }
        #endregion Model

    }
}
