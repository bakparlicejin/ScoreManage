using Models;
using ScoreManager.DalInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.DalImpl
{
    public class UserDal : BaseDal<EDU_USER>, IUserDal
    {
        public UserDal(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }
    }
}
