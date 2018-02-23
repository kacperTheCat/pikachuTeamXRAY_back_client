using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTGClientv1.Models
{
    public class ConnectionInfo
    {
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public int Version { get; set; }
    }
}