using Models;
using ScoreManager.DalInterface;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class ActionService : BaseService<EDU_ACTION>, IActionService
    {
        private IActionDal _actionDal;
        public ActionService(IActionDal actionDal) : base(actionDal)
        {
            _actionDal = actionDal;
        }

        public bool AddAction(AddActionParameter addActionParameter, out string msg)
        {
            bool addSuccess = false;
            msg = "";
            _actionDal.TransactionOperation(c =>
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
    }
}
