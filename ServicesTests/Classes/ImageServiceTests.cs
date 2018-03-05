using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicesLibrary.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.IO;
using System.Drawing.Imaging;

namespace ServicesLibrary.Classes.Tests
{
    [TestClass()]
    public class ImageServiceTests
    {
        [TestMethod()]
        public void GreyscaleImageTest()
        {
            Bitmap image = new Bitmap(Image.FromFile(@"C: \Users\rymszmon\source\Converter\sadpepe.jpg"));
            //Bitmap GreyImage = null;
            ImageService service = new ImageService();
            service.image = service.GreyscaleImage(image);
            service.image.Should().NotBeNull();
            //Assert.Fail();
        }

        [TestMethod()]
        public void FromBase64ConverterTest()
        {
            ImageService service = new ImageService();
            var OriginalImage = new Bitmap(Image.FromFile(@"C: \Users\rymszmon\source\Converter\sadpepe.jpg"));
            //var image = null;
            string imageString = Convert.ToBase64String(File.ReadAllBytes(@"C: \Users\rymszmon\source\Converter\base64String.bs64"));
            MemoryStream stream = new MemoryStream();
            OriginalImage.Save(stream, ImageFormat.Bmp);
            byte[] OriginalImageBytes = stream.ToArray();
            service.image = new Bitmap(service.FromBase64Converter(imageString));
            //stream = null;
            service.image.Save(stream, ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            service.image.Should().NotBeNull();
            //Assert.Fail();
        }
    }
}