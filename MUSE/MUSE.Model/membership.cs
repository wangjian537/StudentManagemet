using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUSE.Model
{
    /// <summary>
	/// membership:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class membership
	{
		public membership()
		{}
		#region Model
        private string _user;           //_用户名
        private string _password;             //_密码
        private string _userType;           //_用户类型
		/// <summary>
		/// 
		/// </summary>
        public string user
		{
			set{ _user=value;}
			get{return _user;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string userType
		{
			set{ _userType=value;}
			get{return _userType;}
		}
		#endregion Model

	}
}
