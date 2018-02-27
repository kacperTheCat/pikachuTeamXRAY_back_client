using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using RTGClientv1.Models;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class ConnectionDetailsController : ApiController
    {
        // GET: api/ConnectionInfo
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public async Task<ConnectionDetails> Get()
        {
            ConnectionDetails connectionInfo = new ConnectionDetails();
            return await connectionInfo.GetConnectionDetails().ConfigureAwait(false);
        }
    }
}
