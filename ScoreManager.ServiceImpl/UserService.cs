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
        private IUserDal _userDal;
        public UserService(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }

        public EDU_USER GetUserByNameAndPass(string userName, string passWord)
        {
           return _userDal.GetUserByNameAndPass(userName, passWord);
        }
    }
}
