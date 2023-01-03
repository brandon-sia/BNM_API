using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API
{
    internal class MetaModel
    {
        public string quote { get; set; }
        public string session { get; set; }
        public string last_updated { get; set; }
        public int total_result { get; set; }
    }
}
