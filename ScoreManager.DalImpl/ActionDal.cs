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
    public class ActionDal : BaseDal<EDU_ACTION>, IActionDal
    {
        public ActionDal(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }
    }
}
