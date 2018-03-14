using ContractLibrary.Models;
using ServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class AuditLogsController : ApiController
    {
        private readonly IAuditLogsService _auditLogsService;

        public AuditLogsController(IAuditLogsService auditLogsService)
        {
            _auditLogsService = auditLogsService;
        }
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/AuditLogs
       
        public List<AuditLogResponse> GetAuditLogs()
        {
            return _auditLogsService.GetAuditLogs();
        }
    }
}
