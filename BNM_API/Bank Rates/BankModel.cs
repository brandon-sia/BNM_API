using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API.Bank_Rates
{
    internal class BankModel
    {
        public string? Bank_code { get; set; }
        public string? Bank_name { get; set; }
        public float Base_rate { get; set; }
        public float Base_lending_rate { get; set; }
        public float Indicative_eff_lending_rate { get; set; }

    }

}
