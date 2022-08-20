using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_USER
    {
           public EDU_USER(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:登录名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string USERNAME {get;set;}

           /// <summary>
           /// Desc:密码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PASSWORD {get;set;}

        /// <summary>
        /// Desc:用户类型 0：管理员 1：老师 2：学生
        /// Default:
        /// Nullable:True
        /// </summary>           
        public short TYPE { get; set; }
        /// <summary>
        /// 是否启用 0：不启用 1：启用 默认启用
        /// </summary>
        public string ISENABLE { get; set; } = "1";

    }
}
