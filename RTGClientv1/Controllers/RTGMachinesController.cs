using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using ContractLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServicesLibrary.Interfaces;

namespace RTGClientv1.Controllers
{
    public class RTGMachinesController : ApiController
    {
       
        // GET: api/RTGMachines       
        public List<RTGMachines> GetRTGMachines()
        {

            List<RTGMachines> rTGMachines = new List<RTGMachines>();
            for(int i=0; i<RTGMachinesList.RTGMachineAddress.Length; i++)
            {
                RTGMachines rTGMachine = new RTGMachines();
                rTGMachine.Machine = RTGMachinesList.RTGMachineAddress[i];
                //rTGMachines.Machine.Add();
                rTGMachines.Add(rTGMachine);
            }
            return rTGMachines;
        }

        

    }
}
