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


        public async Task<CameraImageResponse> GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = await _imageAcquisition.GetXRAYImage(cameraImageCaptureRequest);

            return cameraImageResponse;
        }
        public async Task<CameraImageResponse> GetPerviewImage()
        {
            var cameraImageResponse = await _imageAcquisition.GetPerviewImage();

            return cameraImageResponse;
        }
    }
}
