using Models;
using ScoreManager.DalInterface;
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
    public class ActionService : BaseService<EDU_ACTION>, IActionService
    {
        public ActionService(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {

        }  

        public bool AddAction(AddActionParameter addActionParameter, out string msg)
        {
            bool addSuccess = false;
            msg = "";
            this.TransactionOperation(c =>
            {
                int existCount= c.Queryable<EDU_ACTION>().Count(c => c.NAME == addActionParameter.ActionName);
                if (existCount > 0) return;
                EDU_ACTION action = new EDU_ACTION();
                action.NAME = addActionParameter.ActionName;
                action.DESCRIPTION = addActionParameter.ActionDescription;
                action.ISENABLE = addActionParameter.IsEnable;
                action.ADDTIME = DateTime.Now;
                int id= c.Insertable<EDU_ACTION>(action).ExecuteReturnIdentity();
                addSuccess = id>0;
            });
            if (!addSuccess)
            {
                msg = "已存在同名权限";
            }
            return addSuccess;
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
