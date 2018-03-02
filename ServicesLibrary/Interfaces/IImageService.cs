using ContractLibrary.Interfaces;
using System.Drawing;

namespace ServicesLibrary.Interfaces
{
    public interface IImageService : ICameraImage
    {
        Bitmap FromBase64Converter(string image);
        Bitmap BlackAndWhiteImage(Bitmap image);
        Bitmap GreyscaleImage(Bitmap image);
        string ToBase64Converter(byte[] imageBytes);
    }
}
