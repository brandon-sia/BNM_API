using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BNM_API.Bank_Rates
{

    internal class BankObject:IJsonObject<BankMetaModel>
    {
        public List<BankModel>? data { get; set; }
        public BankMetaModel? meta { get; set; }

    }
    internal class BankProcessor
    {
        public static async Task<List<BankModel>> LoadListOfBankNames()
        {         

            string url = $"https://api.bnm.gov.my/public/base-rate";

            using (HttpResponseMessage? response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    //RateModel rates = await response.Content.ReadAsAsync<RateModel>();

                    // Read the response into a string
                    string responseString = await response.Content.ReadAsStringAsync();

                    var jsonObject = JsonConvert.DeserializeObject<BankObject>(responseString);

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
