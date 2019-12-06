using GYM.Data;
using GYM.Models;
using GYM.Models.Enum;
using GYM.Services.Exceptions;
using GYM.Transfers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using GYM.Services.Tools;

namespace GYM.Services
{
    public class LoginServices
    {
        private readonly GYMContext _gym;
        public LoginServices(GYMContext gym)
        {
            _gym = gym;
        }
        //Generate Token, Generate date expiration token and access for system
        public LoginTransfers Login(string user, string password)
        {
            try
            {
                LoginTransfers loginTransfers = new LoginTransfers();

                if (user == null || user == "" || password == null || password == "")
                {
                    throw new NotFoundException("This data is not found");
                }

                Employee employee = new Employee();
                string hash = employee.EncryptHash(password);
                var em = _gym.EmployeeContext.Where(x => x.UserLogin == user && x.Password == hash);

                if (em.Count() > 0)
                {
                    var upd = em.FirstOrDefault();

                    if (upd.StatusAccount == StatusAccount.Liberat)
                    {
                        DateTime lastLogin = upd.LastLogin;
                        //set new date
                        upd.Expiration = employee.ExpirationToken();
                        upd.Status = Status.Online;
                        upd.Token = employee.GenerateToken();

                        _gym.Update(upd);
                        _gym.SaveChanges();

                        return Utils.SetTransfer("Authentication Success: User is valid", true, upd.Token, upd.UserLogin, upd.Status.ToString(), lastLogin);
                    }
                    else
                    {
                        return Utils.SetTransfer("Authentication Failed: User is canceled or block", false);
                    }
                }
                else
                {
                    return Utils.SetTransfer("Authentication Failed: User or password incorrect", false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
        public LoginTransfers Logout(string token)
        {
            try
            {
                if (token == null || token == "")
                {
                    throw new NotFoundException("This token is null");
                }
                Employee em = new Employee();
                var analysing = _gym.EmployeeContext.Where(x => x.Token == token);
                if (analysing.Count() > 0)
                {
                    var user = analysing.FirstOrDefault();
                    user.Token = null;
                    user.Status = Status.Offline;
                    _gym.Update(user);
                    _gym.SaveChanges();
                    return Utils.SetTransfer("Logout complete", true);
                }
                else
                {
                    return Utils.SetTransfer("This token is not valid", false);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
     
    }
}
