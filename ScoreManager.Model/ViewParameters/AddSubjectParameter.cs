using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class AddSubjectParameter
    {
        public string SubjectName { get; set; }
        public string SubjectDescription { get; set; }
        public string IsEnable { get; set; } = "0";
    }
}
