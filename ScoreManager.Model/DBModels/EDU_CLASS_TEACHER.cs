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
        /// <summary>
        /// 教师角色Id
        /// </summary>
        public long ROLEID { get; set; }

    }
}
