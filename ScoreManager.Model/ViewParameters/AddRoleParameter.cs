using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreManager.Model.ViewParameters
{
    public class AddRoleParameter
    {

        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        public List<int> SelectActions { get; set; }
        public string IsEnable { get; set; } = "0";
    }
}
