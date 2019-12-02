using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYM.Transfers
{
    public class LoginTransfers
    {
        public string Message { get; set; }
        public bool Auth { get; set; }
        public string Token { get; set; }
        public ICollection<ListDataLoginTransfers> User { get; set; } = new List<ListDataLoginTransfers>();
    }
}
