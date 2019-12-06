using GYM.Data;
using GYM.Models;
using GYM.Services.Exceptions;
using GYM.Services.Tools;
using GYM.Transfers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GYM.Services
{
    public class UserServices
    {
        private readonly GYMContext _gym;
        public UserServices(GYMContext gym)
        {
            _gym = gym;
        }
        public Employee ValidToken(string token)
        {
            try
            {
                if (token == null || token == "")
                {
                    throw new NotFoundException("This token is not valid");
                }
                Employee emp = _gym.EmployeeContext.Where(x => x.Token == token && x.Expiration >= DateTime.Now)
                    .Include(x => x.Person).FirstOrDefault();
                if (emp != null)
                {
                    return emp;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public LoginTransfers ResetToken(string token)
        {
            try
            {

                if (token == null || token == "")
                {
                    throw new NotFoundException("This token is null");
                }

                Employee em = new Employee();
                var analysing = _gym.EmployeeContext.Where(x => x.Token == token).Count();
                if (analysing > 0)
                {
                    var user = _gym.EmployeeContext.Where(x => x.Token == token).FirstOrDefault();
                    DateTime lastLogin = user.LastLogin;
                    user.Token = em.GenerateToken();
                    user.Expiration = em.ExpirationToken();
                    user.LastLogin = DateTime.Now;
                    _gym.Update(user);
                    _gym.SaveChanges();
                    return Utils.SetTransfer("Reset Successs: New token create", true, user.Token, user.UserLogin, user.Status.ToString(), lastLogin);
                }
                return Utils.SetTransfer("This token is not valid", false);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
