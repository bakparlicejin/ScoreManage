using Models;
using ScoreManager.Model.ViewParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface IActionService : IBaseSerice<EDU_ACTION>
    {
        bool AddAction(AddActionParameter addActionParameter, out string msg);

        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="roleInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ACTION> QueryWithRole(Expression<Func<EDU_ACTION, List<EDU_ROLE>>> roleInclude, Expression<Func<EDU_ACTION, bool>> filter);
    }
}
