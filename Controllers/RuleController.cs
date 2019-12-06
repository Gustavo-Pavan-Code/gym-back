using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.Services;
using GYM.Transfers;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public ActionResult<IEnumerable<object>> Rule([FromHeader] string authorization)
        {
            try
            {
                if (authorization == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = ruleServices.Rules(authorization);
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

        [HttpPost]
        public ActionResult<List<string>> Create([FromHeader] string authorization, [FromBody] RuleTransfers transfers)
        {

            try
            {
                if (authorization == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = ruleServices.Create(transfers, authorization);
                    if (rules.Count() > 0)
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

        [HttpPut]
        public ActionResult<List<string>> Update([FromHeader] string authorization, [FromBody] RuleTransfers transfers)
        {

            try
            {
                if (authorization == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = ruleServices.Update(transfers, authorization);
                    if (rules.Count() > 0)
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

        [HttpDelete]
        public ActionResult<List<string>> Remove([FromHeader] string authorization, [FromBody] RuleTransfers transfers)
        {

            try
            {
                if (authorization == null)
                {
                    return BadRequest("Token is null");
                }
                else
                {
                    var rules = ruleServices.Remove(transfers, authorization);
                    if (rules.Count() > 0)
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