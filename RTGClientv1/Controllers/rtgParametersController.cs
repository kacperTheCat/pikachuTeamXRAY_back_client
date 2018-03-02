using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RTGClientv1.Controllers
{
    public class rtgParametersController : ApiController
    {
        // GET: api/rtgParameters
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/rtgParameters/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/rtgParameters
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/rtgParameters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/rtgParameters/5
        public void Delete(int id)
        {
        }
    }
}
