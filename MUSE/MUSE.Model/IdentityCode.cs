using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
    /// IdentityCode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class IdentityCode
    {
        public IdentityCode()
        { }
        #region Model
        private string _身份代码;
        private string _身份;
        /// <summary>
        /// 
        /// </summary>
        public string 身份代码
        {
            set { _身份代码 = value; }
            get { return _身份代码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 身份
        {
            set { _身份 = value; }
            get { return _身份; }
        }
        #endregion Model

    }
}
