using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_TEACHER
    {
           public EDU_TEACHER(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>      
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:邮箱地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMAIL_ADDRESS {get;set;}

           /// <summary>
           /// Desc:电话号码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PHONE_NUMBER {get;set;}

           /// <summary>
           /// Desc:老师姓名
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string NAME {get;set;}

           /// <summary>
           /// Desc:用户Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long USERID {get;set;}

           /// <summary>
           /// Desc:学科id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long SUBJECTID {get;set;}

    }
}
