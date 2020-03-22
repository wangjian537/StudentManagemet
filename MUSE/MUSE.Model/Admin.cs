using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MUSE.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{}
		#region Model
        private string user;             //_账号
        private string password;             //_密码
        private string status;               //_身份
        private string statusCode;             //_身份代码
		/// <summary>
		/// 
		/// </summary>
        public string _user
		{
			set{ user=value;}
			get{return user;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string _password
		{
			set{ password=value;}
			get{return password;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string _status
		{
			set{ status=value;}
			get{return status;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string _statusCode
		{
			set{ statusCode=value;}
			get{return statusCode;}
		}
		#endregion Model

	}
}
