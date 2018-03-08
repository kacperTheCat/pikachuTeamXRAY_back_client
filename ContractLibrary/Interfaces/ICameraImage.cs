using ContractLibrary.Models;
using System.Threading.Tasks;

namespace ContractLibrary.Interfaces
{
    public interface ICameraImage
    {
        Task<CameraImageResponse> GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest);
        Task<CameraImageResponse> GetPerviewImage();
    }
}
