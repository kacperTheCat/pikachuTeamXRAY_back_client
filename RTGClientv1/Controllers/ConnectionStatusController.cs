using RTGClientv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RTGClientv1.Controllers
{
    public class ConnectionStatusController : ApiController
    {
        // GET: api/ConnectionStatus
        public Task<ConnectionStatus> Get()
        {
            ConnectionStatus connectionStatus = new ConnectionStatus();
            return connectionStatus.GetStatus();
        }
    }
}
