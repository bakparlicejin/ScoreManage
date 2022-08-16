using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EDU_ROLE_ACTION
    {
           public EDU_ROLE_ACTION(){


           }
        
           /// <summary>
           /// Desc:角色id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ROLEID {get;set;}

           /// <summary>
           /// Desc:权限id
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long ACTIONID {get;set;}

    }
}
