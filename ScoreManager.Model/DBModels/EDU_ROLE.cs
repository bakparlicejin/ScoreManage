using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_ROLE
    {
           public EDU_ROLE(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>         
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           

           /// <summary>
           /// Desc:角色名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NAME {get;set;}
        /// <summary>
        /// Desc:描述
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ADDTIME { get; set; }
            /// <summary>
            /// 是否启用 0：不启用 1：启用 默认启用
            /// </summary>
            public string ISENABLE { get; set; }
        [Navigate(typeof(EDU_ROLE_ACTION), nameof(EDU_ROLE_ACTION.ROLEID), nameof(EDU_ROLE_ACTION.ACTIONID))]
        public List<EDU_ACTION> ActionList { get; set; }


        [Navigate(typeof(EDU_TEACHER_ROLE), nameof(EDU_TEACHER_ROLE.ROLEID), nameof(EDU_TEACHER_ROLE.TEACHERID))]//注意顺序
        public List<EDU_TEACHER> Teachers { get; set; }//只能是null不能赋默认值
    }
}
