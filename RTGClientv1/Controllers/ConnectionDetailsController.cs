using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ContractLibrary.Models;
using ServicesLibrary.Interfaces;

namespace RTGClientv1.Controllers
{
    public class ConnectionDetailsController : ApiController
    {
        private readonly IConnectionService _connectionService;

        public ConnectionDetailsController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        //GET: api/ConnectionInfo
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public Task<ConnectionDetailsResponse> GetDetails()
        {
            var connectionDetailsResponse = _connectionService.GetDetails();

            return connectionDetailsResponse;
        }
    }
}
