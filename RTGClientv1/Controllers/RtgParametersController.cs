using ContractLibrary.Models;
using Newtonsoft.Json;
using ServicesLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class RtgParametersController : ApiController
    {
        private readonly IImageService _imageService;


        public RtgParametersController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST: api/RtgParameters
        public CameraImageCaptureRequest Post([FromBody]CameraImageCaptureRequest rtgParametersRequest)
        {
            string output = JsonConvert.SerializeObject(rtgParametersRequest);
            //File.WriteAllText(@"C:\Users\hudzipau\Desktop\RTG project\jsonTest.txt", output);
            return rtgParametersRequest;
        }

    }
}
