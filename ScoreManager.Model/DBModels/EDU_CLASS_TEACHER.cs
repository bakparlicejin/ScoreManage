using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_CLASS_TEACHER
    {
           public EDU_CLASS_TEACHER(){


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
           /// Desc:班级Id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long CLASSID {get;set;}

    }
}
