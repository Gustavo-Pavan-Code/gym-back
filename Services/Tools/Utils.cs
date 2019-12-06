using GYM.Transfers;
using System;

namespace GYM.Services.Tools
{
    public class Utils
    {
        public static LoginTransfers SetTransfer(string messagem, bool auth, string token = null, string user = null, string status = null, DateTime? lastLogin = null)
        {
            LoginTransfers transfers = new LoginTransfers();
            transfers.Auth = auth;
            transfers.Message = messagem;
            transfers.Token = token;
            transfers.User.Add(new ListDataLoginTransfers
            {
                User = user,
                Status = status,
                LastLogin = lastLogin.ToString()
            });
            return transfers;
        }
    }
}
