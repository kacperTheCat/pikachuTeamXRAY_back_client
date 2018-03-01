using ContractLibrary.Models;
using System.Threading.Tasks;

namespace ContractLibrary.Interfaces
{
    public interface ICameraImage
    {
        Task<CameraImageResponse> GetImage();
    }
}
