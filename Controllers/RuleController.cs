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
    public class RuleController : Controller
    {
        private readonly RuleServices ruleServices;

        public RuleController(RuleServices rule)
        {
            ruleServices = rule;
        }

        [HttpPost]
        public ActionResult<IEnumerable<object>> Rule([FromBody] LoginTransfers token)
        {
            try
            {
                if (token.Token == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = ruleServices.Rules(token.Token);
                    if (rules != null)
                    {
                        return Ok(rules);
                    }
                    else
                    {
                        return StatusCode(406, "User expired");
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