using ServicesLibrary.Interfaces;
using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System;

namespace ServicesLibrary.Classes
{
    public class ImageService : IImageService
    {
        private readonly IImageAcquisition _imageAcquisition;
        public Bitmap image;

        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }


        public async Task<CameraImageResponse> GetImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = await _imageAcquisition.GetImage(cameraImageCaptureRequest);

            return cameraImageResponse;
        }
        public async Task<CameraImageResponse> GetPerview()
        {
            var cameraImageResponse = await _imageAcquisition.GetPerview();

            return cameraImageResponse;
        }
    }
}
