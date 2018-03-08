using System.Threading.Tasks;
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
        public Task<CameraImageResponse> GetImage()
        {
            var cameraImageResponse = _imageService.GetPerview();

            return cameraImageResponse;
        }

        [HttpPost]
        [Route("api/Camera/Capture")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Task<CameraImageResponse> GetBlackAndWhiteImage([FromBody]CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = _imageService.GetImage(cameraImageCaptureRequest);
            return cameraImageResponse;
        }
    }
}
