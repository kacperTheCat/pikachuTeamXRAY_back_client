using ContractLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractLibrary.Models
{
    public class CameraImageResponse
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
    }
}
