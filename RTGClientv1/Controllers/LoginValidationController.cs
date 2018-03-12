using ContractLibrary.Models;
using ServicesLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class LoginValidationController : ApiController
    {
        private readonly ILoginValidationService _loginValidationService;

        public LoginValidationController(ILoginValidationService loginValidationService)
        {
            _loginValidationService = loginValidationService;
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public LoginValidationResponse PostLoginValidation([FromBody]LoginValidationRequest loginValidationRequest)
        {
            return _loginValidationService.GetValidationStatus(loginValidationRequest);
        }

    }
}
