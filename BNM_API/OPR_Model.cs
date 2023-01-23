using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API
{
    internal class OPR_Model
    {
        public string? year { get; set; }
        public string? date { get; set; }
        public double? change_in_opr { get; set; }
        public double? new_opr_level { get; set; }
    }
}
