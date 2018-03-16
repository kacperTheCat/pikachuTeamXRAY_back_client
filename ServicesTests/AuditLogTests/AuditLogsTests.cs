using System;
using ContractLibrary.Models;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using FluentAssertions;
using RTGClientv1.Controllers;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Classes;

namespace ServicesTests.AuditLogTests
{
    [TestClass]
    public class AuditLogsTests
    {
        private IImageAcquisition _imageAcquisition;
        private IAuditLogsAcquisition _auditLogsAcquisition;
        private IAuditLogsService _auditLogsService;
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
            _auditLogsAcquisition = new AuditLogsAcquisition();
            _auditLogsService = new AuditLogsService(_auditLogsAcquisition);
            var controller = new AuditLogsController(_auditLogsService);
        }
        [TestMethod]
        public void CreateCaptureLogForImageTest()
        {
            var cameraImageCaptureRequest = new CameraImageCaptureRequest()
            {
                 light=2,
                 contrast=50,
                 negative=true,
                 patientName="Marek",
                 userName="doctor",
                 imageDate="12.12.2018",
                 imageTime="12:13:14",
            };

            _imageAcquisition.CreateCaptureLogForImage(JsonConvert.SerializeObject(cameraImageCaptureRequest));
            var auditLogs =_auditLogsAcquisition.GetAuditLogs();
            var auditLogsCount = auditLogs.Count;
            var lastAuditlog = auditLogs[auditLogsCount - 1];

            lastAuditlog.light.Should().Be(2);
            lastAuditlog.contrast.Should().Be(50);
            lastAuditlog.negative.Should().Be(true);
            lastAuditlog.patientName.Should().Be("Marek");
            lastAuditlog.userName.Should().Be("doctor");
            lastAuditlog.imageDate.Should().Be("12.12.2018");
            lastAuditlog.imageTime.Should().Be("12:13:14");

        }
        [TestMethod]
        public void AuditLogsControllerGetAuditLogsTest()
        {
            var controller = new AuditLogsController(_auditLogsService);
            var cameraImageCaptureRequest = new CameraImageCaptureRequest()
            {
                light = 2,
                contrast = 50,
                negative = true,
                patientName = "Marek",
                userName = "doctor",
                imageDate = "12.12.2018",
                imageTime = "12:13:14",
            };

            _imageAcquisition.CreateCaptureLogForImage(JsonConvert.SerializeObject(cameraImageCaptureRequest));

            var response = controller.GetAuditLogs();

            response.Should().NotBeNull();
        }
    }
}
