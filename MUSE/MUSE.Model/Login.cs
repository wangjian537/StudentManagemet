using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
    /// Login:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Login
    {
        public Login()
        { }
        #region Model
        private string _账号;
        private string _密码;
        private string _身份代码;
        /// <summary>
        /// 
        /// </summary>
        public string 账号
        {
            set { _账号 = value; }
            get { return _账号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 密码
        {
            set { _密码 = value; }
            get { return _密码; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 身份代码
        {
            set { _身份代码 = value; }
            get { return _身份代码; }
        }
        #endregion Model

    }
}
