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



        public Bitmap FromBase64Converter(string image)
        {
            byte[] imageBytes = System.Convert.FromBase64String(image);
            Bitmap convertedImage;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                convertedImage = new Bitmap(ms);
            }
            return convertedImage;
            // throw new System.NotImplementedException();
        }
        public Bitmap BlackAndWhiteImage(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    int BWColor;
                    if ((pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 115)
                        BWColor = 255;
                    else
                        BWColor = 0;
                    pixelColor = Color.FromArgb(BWColor, BWColor, BWColor);

                    image.SetPixel(x, y, pixelColor);

                }
            }
            return image;
        }
        public Bitmap GreyscaleImage(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int greyColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    pixelColor = Color.FromArgb(greyColor, greyColor, greyColor);
                    image.SetPixel(x, y, pixelColor);

                }
            }
            return image;
        }
        public string ToBase64Converter(byte[] imageBytes)
        {
            string base64string = System.Convert.ToBase64String(imageBytes);
            return base64string;
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
        public async Task<CameraImageResponse> GetBlackAndWhiteImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = await _imageAcquisition.GetImage(cameraImageCaptureRequest);
            string base64image = cameraImageResponse.Base64;
            MemoryStream stream = new MemoryStream();
            BlackAndWhiteImage(FromBase64Converter(base64image)).Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageStreamByteArray = stream.ToArray();
            //File.WriteAllBytes(@"C:\Users\rymszmon\source\webapi\pikachuTeamXRAY_back_client\RTGClientv1\lastFrame.jpg", imageStreamByteArray);
            //File.WriteAllText(@"C:\Users\rymszmon\source\webapi\pikachuTeamXRAY_back_client\RTGClientv1\lastFrame.txt", ToBase64Converter(imageStreamByteArray));
            cameraImageResponse.Base64 = ToBase64Converter(imageStreamByteArray);
            return cameraImageResponse;
        }
    }
}
