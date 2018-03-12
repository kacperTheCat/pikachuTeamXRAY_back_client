using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractLibrary.Models
{
    public class RTGMachine
    {
        public int MachineID;
        public string MachineAddress;
        public bool MachineBusy;
        public RTGMachine(int machineID, string machineAddress)
        {
            MachineID = machineID;
            MachineAddress = machineAddress;
            MachineBusy = false;
        }
    }
}
