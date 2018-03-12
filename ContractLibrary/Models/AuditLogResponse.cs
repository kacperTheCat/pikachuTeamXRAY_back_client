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
        public bool blackWhite;
        public string patientName;
        public string user;
        public string machineIpAddress;
        public int imageId;
        public string imageName;
        public string imageDate;
        public string imageTime;
    }
}
