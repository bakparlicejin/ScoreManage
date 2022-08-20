using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class AddTeacherParameter
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户类型 
        /// </summary>
        public short UserType { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// 学科
        /// </summary>
        public short Subject { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public List<int> SelectRoles { get; set; }
    }
}
