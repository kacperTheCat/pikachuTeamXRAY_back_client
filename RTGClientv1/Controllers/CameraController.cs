using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using RTGClientv1.Models;

namespace RTGClientv1.Controllers
{
    public class CameraController : ApiController
    {
        // GET: api/Camera
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<CameraImage> Get()
        {
            CameraImage cameraImage = new CameraImage();
            return await cameraImage.GetImage();
        }

        // GET: api/Camera/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Camera
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Camera/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Camera/5
        public void Delete(int id)
        {
        }
    }
}
