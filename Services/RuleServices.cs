using GYM.Data;
using GYM.Models.Enum;
using GYM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYM.Transfers;

namespace GYM.Services
{
    public class RuleServices
    {
        private readonly GYMContext _gym;
        private readonly UserServices _userServices;
        public RuleServices(GYMContext gym, UserServices userServices)
        {
            _gym = gym;
            _userServices = userServices;
        }
        public object Rules(string token)
        {
            try
            {
                if (token != null)
                {
                    Employee employee = _userServices.ValidToken(token);
                    if (employee != null)
                    {
                        var rules = _gym.RulesProfilesContext
                            .Where(x => x.PersonId == employee.Person.Id)
                            .Include(x => x.Rule)
                            .Select(x => new
                            {
                                x.Rule.Label,
                                x.Rule.Name,
                                Profile = x.ProfileRule.Name,
                                Employee = x.Person.Name,
                                Status = employee.Status.ToString(),
                                employee.Photo
                            })
                            .ToList();

                        return rules;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new NullReferenceException("Token reference is null");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> Create(RuleTransfers ruleTransfers, string token)
        {
            try
            {
                var emp = _userServices.ValidToken(token);
                List<string> status = new List<string>();
                if (emp != null)
                {
                    ruleTransfers.Rules.ForEach((x) =>
                    {
                        Rule rule = new Rule(x.Name, x.Label);
                        _gym.Add(rule);
                        _gym.SaveChanges();
                        string create = "Create Rule: " + x.Name;
                        status.Add(create);
                    });

                    return status;
                }
                return status;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<string> Update(RuleTransfers ruleTransfers, string token)
        {
            try
            {
                var emp = _userServices.ValidToken(token);
                List<string> status = new List<string>();
                if (emp != null)
                {
                    ruleTransfers.Rules.ForEach((x) =>
                    {
                        _gym.Update(x);
                        _gym.SaveChanges();
                        string update = "Update: " + x.Id + " Rule: " + x.Name;
                        status.Add(update);
                    });

                    return status;
                }
                return status;
            }
            catch (DbUpdateException ex)
            {

                throw new DbUpdateException(ex.Message);
            }
        }

        public List<string> Remove(RuleTransfers ruleTransfers, string token)
        {
            try
            {
                var emp = _userServices.ValidToken(token);
                List<string> status = new List<string>();
                if (emp != null)
                {
                    ruleTransfers.Rules.ForEach((x) =>
                    {
                        var rule = _gym.RuleContext.Find(x.Id);
                        _gym.Remove(rule);
                       _gym.SaveChanges();
                        string remove = "Delete: " + x.Id + " Rule: " + x.Name;
                        status.Add(remove);

                    });

                    return status;
                }
                return status;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                throw new DbUpdateConcurrencyException(ex.Message);
            }
        }
    }
}
