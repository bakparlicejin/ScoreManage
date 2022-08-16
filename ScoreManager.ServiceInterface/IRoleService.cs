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
    public interface IRoleService:IBaseSerice<EDU_ROLE>
    {
        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="actionInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ROLE> QueryWithAction(Expression<Func<EDU_ROLE, List<EDU_ACTION>>> actionInclude, Expression<Func<EDU_ROLE, bool>> filter);
        /// <summary>
        /// 级联增加
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool AddWithActions(EDU_ROLE roleWithActions, out string msg);
        /// <summary>
        /// 删除角色和中间表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRoleWithRelation(int id);
        /// <summary>
        /// 更新角色和中间表
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        bool UpdateWithActions(EDU_ROLE roleWithActions, out string msg);
    }
}
