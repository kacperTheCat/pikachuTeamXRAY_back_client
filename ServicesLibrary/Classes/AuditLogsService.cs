using ContractLibrary.Models;
using ImageAcquisitionLibrary.Interfaces;
using ServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Classes
{
    public class AuditLogsService : IAuditLogsService
    {
        private readonly IAuditLogsAcquisition _auditLogsAcquisition;

        public AuditLogsService(IAuditLogsAcquisition auditLogsAcquisition)
        {
            _auditLogsAcquisition = auditLogsAcquisition;
        }
        public List<AuditLogResponse> GetAuditLogs()
        {
            return _auditLogsAcquisition.GetAuditLogs();
        }
    }
}
