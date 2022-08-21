using Models;
using ScoreManager.Model.ViewParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface ISubjectService : IBaseSerice<EDU_SUBJECT>
    {
        bool AddSubject(AddSubjectParameter addSubjectParameter, out string msg);
    }
}
