using GYM.Data;
using GYM.Models.Enum;
using GYM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Services
{
    public class RuleServices
    {
        private readonly GYMContext _gym;
        public RuleServices(GYMContext gym)
        {
            _gym = gym;
        }
        public object Rules(string token)
        {
            try
            {
                if (token != null)
                {
                    LoginServices login = new LoginServices(_gym);
                    Employee employee = login.ValidToken(token);
                    if (employee != null)
                    {
                        var rules = _gym.RulesProfilesContext
                            .Where(x => x.PersonId == employee.Person.Id)
                            .Include(x => x.Rule)
                            .Select(x => new { 
                                x.Rule.Label, 
                                x.Rule.Name, 
                                Profile = x.ProfileRule.Name,
                                Employee = x.Person.Name, 
                                Status = employee.Status.ToString(), 
                                employee.Photo  
                            })
                            .ToList();
                        
                        return rules;                    }
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
    }
}
