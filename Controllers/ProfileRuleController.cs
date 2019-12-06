using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.Services;
using GYM.Transfers;
using Microsoft.AspNetCore.Mvc;

namespace GYM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileRuleController : Controller
    {
        private readonly ProfileRuleServices _profileService;
        public ProfileRuleController(ProfileRuleServices profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("{id}")]
        public ActionResult<object> Index([FromHeader] string authorization, int id)
        {
            try
            {
                if (authorization == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = _profileService.ProfileRuleId(authorization,id);
                    if (rules != null)
                    {
                        return Ok(rules);
                    }
                    else
                    {
                        return StatusCode(406, "User Expired or invalid");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}