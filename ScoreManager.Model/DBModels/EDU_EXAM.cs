using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_EXAM
    {
           public EDU_EXAM(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>    
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:科目Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long SUBJECTID {get;set;}

           /// <summary>
           /// Desc:考试名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NAME {get;set;}

    }
}
