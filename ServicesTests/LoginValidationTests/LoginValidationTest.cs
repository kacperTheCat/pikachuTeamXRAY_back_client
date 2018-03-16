using System;
using ContractLibrary.Models;
using ImageAcquisitionLibrary.Classes;
using ImageAcquisitionLibrary.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace ServicesTests.LoginValidationTests
{
    [TestClass]
    public class LoginValidationTest
    {
        private ILoginAcquisition _loginAcquisition;
        [TestInitialize]
        public void Initialize()
        {
            _loginAcquisition = new LoginAcquisition();
        }
        [TestMethod]
        public void ValidateLoginAndPasswordTest()
        {
            var loginValidationRequest = new LoginValidationRequest()
            {
                password="admin",
                username="admin"
            };

            var result = _loginAcquisition.ValidateLoginRequest(loginValidationRequest);

            result.username.Should().Be(loginValidationRequest.username);
            result.permissions.Should().Be("admin");
            result.status.Should().Be("OK");
        }
    }
}
