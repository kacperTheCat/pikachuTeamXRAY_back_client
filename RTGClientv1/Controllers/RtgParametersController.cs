using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RTGClientv1.Controllers
{
    public class RtgParametersController : ApiController
    {
        // GET: api/RtgParameters
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RtgParameters/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RtgParameters
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RtgParameters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RtgParameters/5
        public void Delete(int id)
        {
        }
    }
}
