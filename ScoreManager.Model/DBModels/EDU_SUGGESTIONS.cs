using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_SUGGESTIONS
    {
           public EDU_SUGGESTIONS(){


           }
        /// <summary>
        /// Desc:主键
        /// Default:
        /// Nullable:False
        /// </summary>      
        [SqlSugar.SugarColumn(IsPrimaryKey = true, OracleSequenceName = "SEQ_ID")]
        public long ID {get;set;}

           /// <summary>
           /// Desc:教师Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long TEACHERID {get;set;}

           /// <summary>
           /// Desc:学生id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long STUDENTID {get;set;}

           /// <summary>
           /// Desc:建议内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONTENT {get;set;}

           /// <summary>
           /// Desc:考试详情Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long EXAMDETAILID {get;set;}

    }
}
