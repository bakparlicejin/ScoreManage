using Models;
using ScoreManager.DalInterface;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="actionInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ROLE> QueryWithAction(Expression<Func<EDU_ROLE, List<EDU_ACTION>>> actionInclude, Expression<Func<EDU_ROLE, bool>> filter)
        {
            return _roleDal.QueryWithAction(actionInclude, filter);
        }

        /// <summary>
        /// 级联增加
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddWithActions(EDU_ROLE roleWithActions, out string msg)
        {
            msg = "";
            return _roleDal.AddWithActions(roleWithActions, out  msg);

        }

        /// <summary>
        /// 删除角色和中间表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoleWithRelation(int id)
        {
            return _roleDal.DeleteRoleWithRelation(id);
        }

        /// <summary>
        /// 更新角色和中间表
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateWithActions(EDU_ROLE roleWithActions, out string msg)
        {
            return _roleDal.UpdateWithActions(roleWithActions,out msg);
        }
    }
}
