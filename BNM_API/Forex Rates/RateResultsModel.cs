using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API
{
    internal class RateResultsModel
    {
        public string? date { get; set; }
        public double? buying_rate { get; set; }
        public double? selling_rate { get; set; }
        public double? middle_rate { get; set; }

    }
}
