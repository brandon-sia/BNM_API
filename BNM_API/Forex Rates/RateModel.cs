using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API
{
    internal class RateModel
    {
        public string? currency_code { get; set; }
        public int? unit { get; set; }
        public RateResultsModel? rate { get; set; }

    }
}
