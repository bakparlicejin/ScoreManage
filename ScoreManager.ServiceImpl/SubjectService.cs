using Models;
using ScoreManager.Model.ViewParameters;
using ScoreManager.ServiceInterface;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceImpl
{
    public class SubjectService : BaseService<EDU_SUBJECT>, ISubjectService
    {
        public SubjectService(ISqlSugarClient sqlSugarClient) : base(sqlSugarClient)
        {
        }

        public bool AddSubject(AddSubjectParameter addSubjectParameter, out string msg)
        {
            bool addSuccess = false;
            msg = "";
            this.TransactionOperation(c =>
            {
                int existCount = c.Queryable<EDU_SUBJECT>().Count(c => c.NAME == addSubjectParameter.SubjectName);
                if (existCount > 0) return;
                EDU_SUBJECT subject = new EDU_SUBJECT();
                subject.NAME = addSubjectParameter.SubjectName;
                subject.DESCRIPTION = addSubjectParameter.SubjectDescription;
                subject.ISENABLE = addSubjectParameter.IsEnable;
                subject.ADDTIME = DateTime.Now;
                int id = c.Insertable<EDU_SUBJECT>(subject).ExecuteReturnIdentity();
                addSuccess = id > 0;
            });
            if (!addSuccess)
            {
                msg = "已存在同名权限";
            }
            return addSuccess;
        }
    }
}
