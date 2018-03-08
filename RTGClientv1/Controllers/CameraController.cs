﻿using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ContractLibrary.Models;
using ServicesLibrary.Interfaces;

namespace RTGClientv1.Controllers
{
    public class CameraController : ApiController
    {

        private readonly IImageService _imageService;

        public CameraController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Camera
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Task<CameraImageResponse> GetPreviewImage()
        {
            var cameraImageResponse = _imageService.GetPerviewImage();

            return cameraImageResponse;
        }

        [HttpPost]
        [Route("api/Camera/Capture")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Task<CameraImageResponse> GetXRAYImage([FromBody]CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = _imageService.GetXRAYImage(cameraImageCaptureRequest);
            return cameraImageResponse;
        }
    }
}
