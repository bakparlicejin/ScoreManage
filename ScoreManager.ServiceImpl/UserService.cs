using Models;
using ScoreManager.DalInterface;
using ScoreManager.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class UserService : BaseService<EDU_USER>, IUserService
    {
        public UserService(IUserDal userDal) : base(userDal)
        {
        }
    }
}
