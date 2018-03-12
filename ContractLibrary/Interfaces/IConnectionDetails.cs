using System;
using System.Threading.Tasks;
using ContractLibrary.Models;

namespace ContractLibrary.Interfaces
{
    public interface IConnectionDetails
    {
        Task<ConnectionDetailsResponse> GetDetails(int machineID);
    }
}
