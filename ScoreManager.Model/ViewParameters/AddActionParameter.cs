using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class AddActionParameter
    {
        public string ActionName { get; set; }
        public string ActionDescription { get; set; }
        public string IsEnable { get; set; } = "0";
    }
}
