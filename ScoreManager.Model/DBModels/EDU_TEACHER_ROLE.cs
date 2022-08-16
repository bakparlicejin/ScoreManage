using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_TEACHER_ROLE
    {
           public EDU_TEACHER_ROLE(){


           }
       

           /// <summary>
           /// Desc:教师id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long TEACHERID {get;set;}

           /// <summary>
           /// Desc:角色id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ROLEID {get;set;}

    }
}
