using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using SqlSugar;
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

        public RoleService(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
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
                _sqlSugarClient.InsertNav(roleWithActions).Include(c => c.Actions).ExecuteCommand();
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
            return _sqlSugarClient.DeleteNav<EDU_ROLE>(c => c.ID == id).Include(c => c.Actions, new DeleteNavOptions() { ManyToManyIsDeleteA = true }).ExecuteCommand();
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
                this.TransactionOperation(client =>
                {
                    client.Updateable<EDU_ROLE>(roleWithActions).ExecuteCommand();
                    client.Deleteable<EDU_ROLE_ACTION>(c=>c.ROLEID==roleWithActions.ID).ExecuteCommand();
                    if (roleWithActions.Actions!=null&&roleWithActions.Actions.Any())
                    {
                        List<EDU_ROLE_ACTION> role_actions=new List<EDU_ROLE_ACTION>();
                        foreach (var item in roleWithActions.Actions)
                        {
                            EDU_ROLE_ACTION eDU_ROLE_ACTION = new EDU_ROLE_ACTION() { ACTIONID = item.ID, ROLEID = roleWithActions.ID };
                            role_actions.Add(eDU_ROLE_ACTION);
                        }
                        client.Insertable<EDU_ROLE_ACTION>(role_actions).ExecuteCommand();
                    }

                });
                //_sqlSugarClient.UpdateNav<EDU_ROLE>(roleWithActions).Include(c => c.ActionList, new UpdateNavOptions() { ManyToManyIsUpdateA = true }).ExecuteCommand();
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
