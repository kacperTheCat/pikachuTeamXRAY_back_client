using ContractLibrary.Interfaces;
using ContractLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAcquisitionLibrary.Interfaces
{
    public interface ILoginAcquisition : ILoginValidation
    {
        LoginValidationResponse ValidateLoginRequest(LoginValidationRequest loginValidationRequest);
    }
}
