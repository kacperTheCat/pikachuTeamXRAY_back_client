using System;
using ImageAcquisitionLibrary.Interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ContractLibrary.Models;

namespace ImageAcquisitionLibrary.Classes
{
    public class ConnectionAcquisition : IConnectionAcquisition
    {
        public async Task<ConnectionDetailsResponse> GetDetails(int machineID)
        {
            var connectionDetailsResponse = new ConnectionDetailsResponse();            
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/connectiondetails");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ConnectionDetailsResponse>(responseBody);
        }
    }
}
