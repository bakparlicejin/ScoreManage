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
    public class RoleService : BaseService<EDU_ROLE>, IRoleService
    {
        private IRoleDal _roleDal;
        public RoleService(IRoleDal roleDal) : base(roleDal)
        {
            _roleDal = roleDal;
        }
    }
}
