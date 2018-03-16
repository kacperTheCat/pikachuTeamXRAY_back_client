using System;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RTGClientv1.Controllers;
using ServicesLibrary.Classes;
using ServicesLibrary.Interfaces;
using FluentAssertions;

namespace ServicesTests.CameraImageTests
{
    [TestClass]
    public class CameraImageTests
    {
        private IImageService _imageService;
        private IImageAcquisition _imageAcquisition;
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
            _imageService = new ImageService(_imageAcquisition);
        }
        [TestMethod]
        public void CameraControllerGetPerviewTests()
        {
            var controller = new CameraController(_imageService);

            var response = controller.GetPreviewImage();

            response.Should().NotBeNull();
        }
    }
}
