using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.BL.DTOs;

namespace University.API.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        public IHttpActionResult Login(LoginDTO loginDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            bool isCredentialValid = (loginDTO.Password == "123456");//Aqui verifico que sea un usuario valido
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDTO.Username);
                return Ok(token);
            }
            else return Unauthorized();
        }
    }
}
