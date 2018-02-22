using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RTGClientv1.Controllers
{
    public class ConnectionInfoController : ApiController
    {
        // GET: api/ConnectionInfo
        public Task<string> Get()
        {
            return Test();
        }

        static async Task<string> Test()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectioninfo");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
