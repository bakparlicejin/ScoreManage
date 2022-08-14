using Models;
using ScoreManager.Model.ViewParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.ServiceInterface
{
    public interface IActionService : IBaseSerice<EDU_ACTION>
    {
        bool AddAction(AddActionParameter addActionParameter, out string msg);
    }
}
