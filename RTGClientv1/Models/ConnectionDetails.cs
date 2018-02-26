using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace RTGClientv1.Models
{
    public class ConnectionDetails
    {
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public int Version { get; set; }

        public async Task<ConnectionDetails> GetConnectionDetails()
        {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectiondetails");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<ConnectionDetails>(responseBody);
        }
    }
}