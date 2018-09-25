using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using BakeUpBackendR1.Models.Claim;
using Newtonsoft;
using Newtonsoft.Json;

namespace BakeUpBackendR1.Controllers.ApiClaim
{
    public class BaseApiController:ApiController
    {
        const string Token = "0ae4c3d34d55d5b7a3de042c1ceb089e31f732d1f46856ceb7bf974c6cbb315f";
        internal string ComposeBaseUrl()
        {
            var token = "WzL9mcs62dFAfpsOBDVXBbNRCedNuVV5";
            return $"https://cms.bconsole.com/api/v1.1/{token}/syncronize/";
        }
        

        internal async System.Threading.Tasks.Task<T> CallClaimAsync<T>(string apiUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Token", Token);
            client.DefaultRequestHeaders.Add("User-Agent", "mobileapp");
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            
            if (response.IsSuccessStatusCode)
            {
                var res=  response.Content.ReadAsStringAsync().Result;

                var r = JsonConvert.DeserializeObject<List<T>>(res);
                //List <T> p = await response.Content.ReadAsAsync<List<T>>();
                return r.FirstOrDefault();
            }
            else
            {
                var r = await response.Content.ReadAsStringAsync();
                Console.WriteLine(r);
            }
            return default(T);
        }
    }
}