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
    public class RoleDal : BaseDal<EDU_ROLE>, IRoleDal
    {
        public RoleDal(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }
        /// <summary>
        /// 级联查询
        /// </summary>
        /// <param name="actionInclude">子表查询条件</param>
        /// <param name="filter">主表过滤条件</param>
        /// <returns></returns>
        public List<EDU_ROLE> QueryWithAction(Expression<Func<EDU_ROLE, List<EDU_ACTION>>> actionInclude, Expression<Func<EDU_ROLE, bool>> filter)
        {
            return _sqlSugarClient.Queryable<EDU_ROLE>().Includes(actionInclude).Where(filter).ToList();
        }

        /// <summary>
        /// 级联增加
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool AddWithActions(EDU_ROLE roleWithActions, out string msg)
        {
            try
            {
                _sqlSugarClient.InsertNav(roleWithActions).Include(c => c.ActionList).ExecuteCommand();
                msg = "";
                return true;

            }
            catch (Exception ex)
            {

                msg = "增加角色失败";
                return false;
            }
        }

        /// <summary>
        /// 删除角色和中间表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoleWithRelation(int id)
        {
           return _sqlSugarClient.DeleteNav<EDU_ROLE>(c=>c.ID==id).Include(c => c.ActionList,new DeleteNavOptions() { ManyToManyIsDeleteA=true}).ExecuteCommand();
        }

        /// <summary>
        /// 更新角色和中间表
        /// </summary>
        /// <param name="roleWithActions"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool UpdateWithActions(EDU_ROLE roleWithActions, out string msg)
        {
            try
            {

                _sqlSugarClient.UpdateNav<EDU_ROLE>(roleWithActions).Include(c => c.ActionList, new UpdateNavOptions() { ManyToManyIsUpdateA = true }).ExecuteCommand();
                msg = "";
                return true;
            }
            catch (Exception ex)
            {
                msg = "修改角色失败";
                return false;
            }
        }
    }
}
