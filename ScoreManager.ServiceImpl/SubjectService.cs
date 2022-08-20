using Models;
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
    }
}
