using ContractLibrary.Interfaces;
using ContractLibrary.Models;

namespace ImageAcquisitionLibrary.Interfaces
{
    public interface IImageAcquisition : ICameraImage
    {
        void CreateCaptureLogForImage(string image);
        void SaveImage(CameraImageCaptureRequest cameraImageCaptureRequest, string base64StringImage);
    }
}
