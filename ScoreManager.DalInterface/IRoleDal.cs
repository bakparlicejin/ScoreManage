using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.DalInterface
{
    public interface IRoleDal: IBaseDal<EDU_ROLE>
    {
        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="actionInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ROLE> QueryWithAction(Expression<Func<EDU_ROLE, List<EDU_ACTION>>> actionInclude, Expression<Func<EDU_ROLE, bool>> filter);
    }
}
