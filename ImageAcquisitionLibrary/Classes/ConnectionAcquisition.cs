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
        public async Task<ConnectionDetailsResponse> GetDetails()
        {
            if (RTGMachinesList.chosenMachineID == -1)
                throw new Exception("Please chose a device");
            var connectionDetailsResponse = new ConnectionDetailsResponse();            
            HttpClient client = new HttpClient();
            int machineID = RTGMachinesList.chosenMachineID;
            HttpResponseMessage response = await client.GetAsync("http://" + RTGMachinesList.RTGMachineAddress[machineID] + "/api/connectiondetails");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<ConnectionDetailsResponse>(responseBody);
        }
    }
}
