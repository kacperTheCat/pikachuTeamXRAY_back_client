using ContractLibrary.Models;
using ImageAcquisitionLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAcquisitionLibrary.Classes
{
    public class LoginAcquisition : ILoginAcquisition
    {
        public LoginValidationResponse GetValidationStatus(LoginValidationRequest loginValidationRequest)
        {
            return ValidateLoginRequest(loginValidationRequest); 
        }

        public LoginValidationResponse ValidateLoginRequest(LoginValidationRequest loginValidationRequest)
        {
            var loginValidationResponse = new LoginValidationResponse();
            var usersList = new UserMock().GenerateMockUsers();

            var checkIfUserExists = usersList.Find(x => x.username == loginValidationRequest.username);
            if (checkIfUserExists != null)
            {
                if (checkIfUserExists.password == loginValidationRequest.password)
                {
                    loginValidationResponse.username = checkIfUserExists.username;
                    loginValidationResponse.permissions = checkIfUserExists.permission;
                    loginValidationResponse.status = "OK";
                }
                else
                {
                    loginValidationResponse.username = checkIfUserExists.username;
                    loginValidationResponse.permissions = "Denied";
                    loginValidationResponse.status = "Wrong Password";
                }
            }
            else
            {
                loginValidationResponse.username = loginValidationRequest.username;
                loginValidationResponse.permissions = "Denied";
                loginValidationResponse.status = "The user does not exist";
            }

            return loginValidationResponse;
        }
    }
}
