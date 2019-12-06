using GYM.Data;
using GYM.Models;
using GYM.Transfers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Services
{
    public class ProfileRuleServices
    {
        private readonly UserServices _userServices;
        private readonly GYMContext _gym;
        public ProfileRuleServices(UserServices userServices, GYMContext gym)
        {
            _userServices = userServices;
            _gym = gym;
        }

        public IEnumerable<ProfileRule> ProfileRuleAll(string authorization)
        {
            try
            {
                var emp = _userServices.ValidToken(authorization);
                if (emp != null)
                {
                    return _gym.ProfileRuleContext.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public object ProfileRuleId(string authorization, int id)
        {
            try
            {
                var emp = _userServices.ValidToken(authorization);
                if(emp != null)
                {
                    var rule = _gym.RulesProfilesContext
                        .Where(x => x.ProfileRule.Id == id)
                        .Include(x => x.ProfileRule)
                        .Include(x => x.Rule)
                        .ToList();

                    RuleTransfers ruleTransfers = new RuleTransfers();
                    var profile = rule.Where(x => x.ProfileRule.Id == id).Select(x => x.ProfileRule).FirstOrDefault();
                    var rules = rule.Select(x => x.Rule);
                    ruleTransfers.ProfileRules = profile;
                    ruleTransfers.Rules = rules.ToList();
                    return ruleTransfers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
