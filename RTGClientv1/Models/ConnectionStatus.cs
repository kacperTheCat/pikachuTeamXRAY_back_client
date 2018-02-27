using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RTGClientv1.Models
{
    public class ConnectionStatus
    {
        public bool ConnectionStatusInformation { get; set; }


        public async Task<ConnectionStatus> GetStatus()
        {
            HttpClient client = new HttpClient();


                
                //return JsonConvert.DeserializeObject<ConnectionStatus>(responseBody);
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectionstatus");
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    // handle the second type of error (404, 400, etc.)
                    return JsonConvert.DeserializeObject<ConnectionStatus>(responseBody);
                }
                else
                {
                    return JsonConvert.DeserializeObject<ConnectionStatus>(responseBody);
                }
            }
            catch (HttpRequestException ex)
            {
                // handle the first type of error (no connectivity, etc)
                ConnectionStatus connectionStatus = new ConnectionStatus();
                connectionStatus.ConnectionStatusInformation = false;
                return connectionStatus;
            }
        }
    }
}