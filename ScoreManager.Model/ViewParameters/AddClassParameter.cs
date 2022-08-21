using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class AddClassParameter
    {
        public string ClassName { get; set; }
        public string IsEnable { get; set; } = "0";
        public List<int> SubjectTeacherIds { get; set; }
        public int MasterTeacherId { get; set; }
    }
}
