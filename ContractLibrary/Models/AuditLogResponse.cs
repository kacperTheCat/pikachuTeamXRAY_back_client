using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractLibrary.Models
{
    public class AuditLogResponse
    {
        public int light;
        public int contrast;
        public bool negative;
        public string patientName;
        public string userName;
        public string machineID;
        public string xRayImageName;
        public string imageDate;
        public string imageTime;
    }
}
