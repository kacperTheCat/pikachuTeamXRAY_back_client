using ContractLibrary.Models;
using ImageAcquisitionLibrary.Interfaces;
using ServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Classes
{
    public class LoginValidationService : ILoginValidationService
    {
        private readonly ILoginAcquisition _loginAcquisition;

        public LoginValidationService(ILoginAcquisition loginAcquisition)
        {
            _loginAcquisition = loginAcquisition;
        }
        public LoginValidationResponse GetValidationStatus(LoginValidationRequest loginValidationRequest)
        {
            return _loginAcquisition.GetValidationStatus(loginValidationRequest);
        }
    }
}
