using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.Text;



namespace ImageAcquisitionLibrary.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        public async Task<CameraImageResponse> GetPerviewImage(int machineID)
        {
            //int machineID = 1;
            HttpClient client = new HttpClient();
            /// HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/camera");
            HttpResponseMessage response = await client.GetAsync("http://"+ RTGMachines.RTGMachineAddress[machineID] + "/api/camera");
            //HttpResponseMessage response = await client.GetAsync("http://10.28.14.34/api/camera");
            //HttpResponseMessage response = await client.GetAsync()
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
        }

        public void CreateCaptureLogForImage(string image)
        {
            //Test log
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\rymszmon\source\webapi\log.txt", true))
            {
                file.WriteLine(image);
            }
        }

        public async Task<CameraImageResponse> GetXRAYImage(CameraImageCaptureRequest rtgParametersRequest)
        {
            //int machineID = rtgParametersRequest.machineID;
            int machineID = rtgParametersRequest.machineID;
            HttpClient client = new HttpClient();
            StringContent rtgParametersStringContent = new StringContent(JsonConvert.SerializeObject(rtgParametersRequest), Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("http://"+RTGMachines.RTGMachineAddress[machineID] +"/api/camera/capture", rtgParametersStringContent);
            HttpResponseMessage response = await client.PostAsync("http://localhost:63766/api/camera/capture", rtgParametersStringContent);
            response.EnsureSuccessStatusCode();
            CreateCaptureLogForImage(JsonConvert.SerializeObject(rtgParametersRequest));
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
        }
    }
}
