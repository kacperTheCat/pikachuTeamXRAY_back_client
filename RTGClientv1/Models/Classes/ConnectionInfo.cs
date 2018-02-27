using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RTGClientv1.Models
{
    public class ConnectionInfo : IConnectionInfo
    {
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public string Version { get; set; }


        public async Task<ConnectionInfo> GettingConnectionInfo()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectioninfo");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ConnectionInfo>(responseBody);
        }

    }
}