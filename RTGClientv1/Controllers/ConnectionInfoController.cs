using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using RTGClientv1.Models;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class ConnectionInfoController : ApiController
    {
        // GET: api/ConnectionInfo
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Task<ConnectionInfo> Get()
        {
            return Test();
        }

        static async Task<ConnectionInfo> Test()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectioninfo");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConnectionInfo>(responseBody);
        }
    }
}
