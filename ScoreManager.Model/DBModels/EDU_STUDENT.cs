using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_STUDENT
    {
           public EDU_STUDENT(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>         
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:班级id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? CLASSID {get;set;}

           /// <summary>
           /// Desc:姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NAME {get;set;}
        /// <summary>
        /// 用户id
        /// </summary>
        public long? USERID { get; set; }

    }
}
