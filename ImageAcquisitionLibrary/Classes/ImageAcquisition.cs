using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.Text;
using System.IO;

namespace ImageAcquisitionLibrary.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        public async Task<CameraImageResponse> GetPerview()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/camera");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
        }

        public void CreateCaptureLogForImage(string image)
        {
            
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory+"log.txt", true))
            {
                file.WriteLine(image);
            }

        }

        public void SaveImage(string base64StringImage)
        {
            var bytes = Convert.FromBase64String(base64StringImage);
            using (var imageFile = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory+"c.jpg", FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }

        public async Task<CameraImageResponse> GetImage(CameraImageCaptureRequest rtgParametersRequest)
        {
            HttpClient client = new HttpClient();
            StringContent rtgParametersStringContent = new StringContent(JsonConvert.SerializeObject(rtgParametersRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:63766/api/camera/capture", rtgParametersStringContent);
            response.EnsureSuccessStatusCode();
            CreateCaptureLogForImage(JsonConvert.SerializeObject(rtgParametersRequest));
            string responseBody = await response.Content.ReadAsStringAsync();
            var convertedResponseBody = JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
            SaveImage(convertedResponseBody.Base64);
            return convertedResponseBody;
        }
    }
}
