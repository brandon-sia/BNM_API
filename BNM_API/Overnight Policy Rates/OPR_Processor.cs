using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BNM_API
{

    internal class OPR_Object
    {
        public List<OPR_Model>? data { get; set; }
        public OPR_MetaModel? meta { get; set; }

    }
    class OPR_Processor
    {
        public static async Task<List<OPR_Model>> Load_OPR()
        {
            string url = "";

            // obtain latest exchange rate            

            url = $"https://api.bnm.gov.my/public/opr/year/{OPR_Info.year}";

            using (HttpResponseMessage? response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Read the response into a string
                    string responseString = await response.Content.ReadAsStringAsync();

                    var jsonObject = JsonConvert.DeserializeObject<OPR_Object>(responseString);

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
