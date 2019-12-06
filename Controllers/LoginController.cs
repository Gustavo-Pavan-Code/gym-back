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
        private readonly UserServices _userServices;

        public LoginController(LoginServices service, UserServices userServices)
        {
            _service = service;
            _userServices = userServices;
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
        [HttpGet("reset")]
        public ActionResult ResetToken([FromHeader] string Authorization)
        {
            try
            {
                if (Authorization == null || Authorization == "")
                {
                    return BadRequest("Argument is null");
                }

                LoginTransfers obj = _userServices.ResetToken(Authorization);
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
        [HttpGet("logout")]
        public ActionResult Logout([FromHeader] string Authorization)
        {
            try
            {
                if (Authorization == null || Authorization == "")
                {
                    return BadRequest("Argument is null");
                }

                LoginTransfers obj = _service.Logout(Authorization);
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