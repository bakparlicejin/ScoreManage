using Models;
using ScoreManager.DalInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.DalImpl
{
    public class ActionDal : BaseDal<EDU_ACTION>, IActionDal
    {
        public ActionDal(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }


        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="roleInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ACTION> QueryWithRole(Expression<Func<EDU_ACTION, List<EDU_ROLE>>> roleInclude, Expression<Func<EDU_ACTION, bool>> filter)
        {
            return _sqlSugarClient.Queryable<EDU_ACTION>().Includes(roleInclude).Where(filter).ToList();
        }
    }
}
