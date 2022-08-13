using Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface IUserService : IBaseSerice<EDU_USER>
    {
        public EDU_USER GetUserByNameAndPass(string userName, string passWord);
        public bool IsExist(string userName);
    }
}
