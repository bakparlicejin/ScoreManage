using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_EXAMDETIAL
    {
           public EDU_EXAMDETIAL(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>         
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:学生id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long STUDENTID {get;set;}

           /// <summary>
           /// Desc:考试Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long EXAMID {get;set;}

           /// <summary>
           /// Desc:分数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? SCORE {get;set;}

           /// <summary>
           /// Desc:冗余打分老师id
           /// Default:
           /// Nullable:True
           /// </summary>           
           public long? TEACHERID {get;set;}

    }
}
