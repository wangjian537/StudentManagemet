using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
    /// Course:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Course
    {
        public Course()
        { }
        #region Model
        private int courseCode;               //_课程号
        private string course;                //_课程名
        private decimal? courseCredit;          //_课程学分
        private int? coursePeriod;              //_课程学时
        private string courseType;            //_课程类型
        private string courseTypeCode;        //_课程类型代码
        private string academyCode;     //_学院号
        private string academy;                 //_学院
        private string courseBeginTime;              //_开课时间
        private string courseCover;                 //_课程封面
        private string note;               //_备注
        /// <summary>
        /// 
        /// </summary>
        public int _courseCode
        {
            set { courseCode = value; }
            get { return courseCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _Course
        {
            set { course = value; }
            get { return course; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? CourseCredit
        {
            set { courseCredit = value; }
            get { return courseCredit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? _coursePeriod
        {
            set { coursePeriod = value; }
            get { return coursePeriod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _courseType
        {
            set { courseType = value; }
            get { return courseType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CourseTypeCode
        {
            set { courseTypeCode = value; }
            get { return courseTypeCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _academyCode
        {
            set { academyCode = value; }
            get { return academyCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _academy
        {
            set { academy = value; }
            get { return academy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _courseBeginTime
        {
            set { courseBeginTime = value; }
            get { return courseBeginTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _courseCover
        {
            set { courseCover = value; }
            get { return courseCover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _note
        {
            set { note = value; }
            get { return note; }
        }
        #endregion Model

    }
}
