using ContractLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RTGClientv1.Controllers
{
    public class RTGMachineController : ApiController
    {
        public void AddMachine(int machineID, string machineAddress)
        {
            RTGMachine rtgMachine = new RTGMachine(machineID, machineAddress);
        }
        public bool ConnectMachine(RTGMachine rtgMachine)
        {
            if(!rtgMachine.MachineBusy)
            {

            }
            return rtgMachine.MachineBusy;
        }

    }
}
