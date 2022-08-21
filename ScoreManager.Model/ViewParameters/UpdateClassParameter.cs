using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class UpdateClassParameter
    {
        public int Id { get; set; }
        public List<int> SubjectTeacherIds { get; set; }
        public int MasterTeacherId { get; set; }
    }
}
