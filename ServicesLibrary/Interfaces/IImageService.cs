using ContractLibrary.Interfaces;
using ContractLibrary.Models;
using System.Drawing;
using System.Threading.Tasks;

namespace ServicesLibrary.Interfaces
{
    public interface IImageService : ICameraImage
    {
        Bitmap FromBase64Converter(string image);
        Bitmap BlackAndWhiteImage(Bitmap image);
        Bitmap GreyscaleImage(Bitmap image);
        string ToBase64Converter(byte[] imageBytes);
        Task<CameraImageResponse> GetBlackAndWhiteImage(CameraImageCaptureRequest rtgParametersRequest);
    }
}
