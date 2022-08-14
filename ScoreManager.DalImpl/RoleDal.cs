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
    public class RoleDal : BaseDal<EDU_ROLE>, IRoleDal
    {
        public RoleDal(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }
    }
}
