using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BNM_API
{
    internal class RateObject
    {
        public RateModel? data { get; set; }
        public MetaModel? meta { get; set; }

    }
    internal class RateProcessor
    {
        public static async Task<RateModel> LoadRates()
        {
            string url = "";

            // obtain latest exchange rate            

            url = $"https://api.bnm.gov.my/public/exchange-rate/{RateInfo.currency_code}/date/{RateInfo.exchange_rate_date}?session={RateInfo.session}&quote=rm";

            using (HttpResponseMessage? response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //RateModel rates = await response.Content.ReadAsAsync<RateModel>();

                    // Read the response into a string
                    string responseString = await response.Content.ReadAsStringAsync();

                    var jsonObject = JsonConvert.DeserializeObject<RateObject> (responseString);


                    return jsonObject.data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }
    }
}
