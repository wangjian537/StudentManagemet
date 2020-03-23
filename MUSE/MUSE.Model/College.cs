using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
    /// College:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class College
    {
        public College()
        { }
        #region Model
        private string _学院号;
        private string _学院;
        private int? _排序;
        private string _是否启用;
        private string _备注;
        /// <summary>
        /// 
        /// </summary>
        public string 学院号
        {
            set { _学院号 = value; }
            get { return _学院号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 学院
        {
            set { _学院 = value; }
            get { return _学院; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 排序
        {
            set { _排序 = value; }
            get { return _排序; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 是否启用
        {
            set { _是否启用 = value; }
            get { return _是否启用; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 备注
        {
            set { _备注 = value; }
            get { return _备注; }
        }
        #endregion Model

    }
}
