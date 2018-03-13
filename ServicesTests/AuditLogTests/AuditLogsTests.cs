using System;
using ContractLibrary.Models;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using FluentAssertions;

namespace ServicesTests.AuditLogTests
{
    [TestClass]
    public class AuditLogsTests
    {
        private IImageAcquisition _imageAcquisition;
        private IAuditLogsAcquisition _auditLogsAcquisition;
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
            _auditLogsAcquisition = new AuditLogsAcquisition();
        }
        [TestMethod]
        public void CreateCaptureLogForImageTest()
        {
            var cameraImageCaptureRequest = new CameraImageCaptureRequest()
            {
                 light=0,
                 contrast=-50,
                 negative=true,
                 patientName="Marek",
                 userName="doctor",
                 machineID=0,
                 imageDate="12.12.2018",
                 imageTime="12:13:14",
            };

            _imageAcquisition.CreateCaptureLogForImage(JsonConvert.SerializeObject(cameraImageCaptureRequest));
            var auditLogsList = _auditLogsAcquisition.GetAuditLogs();



        }
    }
}
