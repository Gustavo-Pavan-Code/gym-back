using GYM.Services;
using GYM.Transfers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace GYM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginServices _service;

        public LoginController(LoginServices service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Index(CredentialTransfers credential)
        {

            try
            {
                if (credential.user == null || credential.user == "" || credential.password == null || credential.password == "")
                {
                    return BadRequest("Argument is null");
                }

                LoginTransfers obj = _service.Login(credential.user, credential.password);
             
                if (obj.Auth)
                {
                    return StatusCode(200, obj);
                }
                else
                {
                    switch (obj.Message)
                    {
                        case "Authentication Failed: User or password incorrect":
                            {
                                return StatusCode(401, obj);
                            }
                        case "Authentication Failed: User is canceled or block":
                            {
                                return StatusCode(502, obj);
                            }
                    }
                    return StatusCode(406, "Denied");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("reset")]
        public ActionResult ResetToken([FromBody]CredentialTransfers tok)
        {
            try
            {
                if (tok.token == null || tok.token == "")
                {
                    return BadRequest("Argument is null");
                }

                LoginTransfers obj = _service.ResetToken(tok.token);
                if (obj.Auth)
                {
                    return StatusCode(200, obj);
                }
                else
                {
                    return StatusCode(406, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("logout")]
        public ActionResult Logout([FromBody]CredentialTransfers tok)
        {
            try
            {
                if (tok.token == null || tok.token == "")
                {
                    return BadRequest("Argument is null");
                }

                LoginTransfers obj = _service.Logout(tok.token);
                if (obj.Auth)
                {
                    return StatusCode(200, obj);
                }
                else
                {
                    return StatusCode(406, obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}