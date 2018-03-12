using ContractLibrary.Models;
using ImageAcquisitionLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
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
                var hashedProvidedPassword = encryptionProvidedPasswordUsingActualSaltPassword(loginValidationRequest.password, checkIfUserExists.password);
                if(comperePasswordsHash(hashedProvidedPassword, Convert.FromBase64String(checkIfUserExists.password)) == true) { 

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


        public byte[] encryptionProvidedPasswordUsingActualSaltPassword(string passwordProvided, string actualPasswordHashed)
        {
            byte[] passwordHashWithSaltBytes = Convert.FromBase64String(actualPasswordHashed);
            byte[] actualPasswordSalt = new byte[16];
            Array.Copy(passwordHashWithSaltBytes, 0, actualPasswordSalt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(passwordProvided, actualPasswordSalt, 10000);
            byte[] hashedProvidedPassword = pbkdf2.GetBytes(20);
            return hashedProvidedPassword;
        }

        public bool comperePasswordsHash(byte[] passwordProvidedHashed, byte[] actualPasswordHashedWithSalt)
        {
            for (int i = 0; i <20; i++)
            {
                if (actualPasswordHashedWithSalt[i + 16] != passwordProvidedHashed[i])
                    return false;
            }

            return true;
        }
    }
}
