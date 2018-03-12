using ServicesLibrary.Interfaces;
using ImageAcquisitionLibrary.Interfaces;
using ContractLibrary.Models;
using System.Threading.Tasks;

namespace ServicesLibrary.Classes
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionAcquisition _connectionAcquisition;

        public ConnectionService(IConnectionAcquisition connectionAcquisition)
        {
            _connectionAcquisition = connectionAcquisition;
        }
        public Task<ConnectionDetailsResponse> GetDetails(int machineID)
        {
            var connectionDetailseResponse = _connectionAcquisition.GetDetails(machineID);

            return connectionDetailseResponse;
        }
    }
}
