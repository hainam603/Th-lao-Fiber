using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Server.auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        Iauth auth;
        public AuthController(Iauth auth)
        {
            this.auth = auth;
        }
        [HttpGet("test")]
        public dynamic test()
        {
            return "success1";
        }
        [HttpPost("login")]
        public dynamic login([FromBody] LoginRequestModel lrm)
        {
            return auth.login(lrm);
        }

    }
}
