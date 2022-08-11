using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.DalInterface
{
    public interface IUserDal:IBaseDal<EDU_USER>
    {
        public EDU_USER GetUserByNameAndPass(string userName, string passWord);
    }
}
