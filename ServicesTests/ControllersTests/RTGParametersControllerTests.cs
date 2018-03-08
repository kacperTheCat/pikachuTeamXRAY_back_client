using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTGClientv1.Controllers;
using ContractLibrary.Models;
using System.Web.Http;
using System.Web.Http.Results;
using FluentAssertions;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using ImageAcquisitionLibrary.Classes;

namespace ServicesTests.ControllersTests
{
    [TestClass]
    public class RTGParametersControllerTests
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
        public void RTGParametersControllerPostTest()
        {
         //   var controller = new RtgParametersController(_imageService);
            var postJson = new CameraImageCaptureRequest();

            postJson.light = 1;
            postJson.contrast = 2;
            postJson.blackWhite = true;
            postJson.patientName = "Marek";
            
         //   var response = controller.Post(postJson);

     /*       response.light.Should().Be(1);
            response.contrast.Should().Be(2);
            response.blackWhite.Should().BeTrue();
            response.patientName.Should().Be("Marek");*/
        }
    }
}
