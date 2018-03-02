using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ImageAcquisitionLibrary.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        public async Task<CameraImageResponse> GetImage()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:63766/api/camera");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CameraImageResponse>(responseBody);
        }
    }
}
