using ServicesLibrary.Interfaces;
using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Threading.Tasks;

namespace ServicesLibrary.Classes
{
    public class ImageService : IImageService
    {
        private readonly IImageAcquisition _imageAcquisition;

        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }
        public Task<CameraImageResponse> GetImage()
        {
            var cameraImageResponse = _imageAcquisition.GetImage();

            return cameraImageResponse;
        }
    }
}
