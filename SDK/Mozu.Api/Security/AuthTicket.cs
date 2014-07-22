using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozu.Api.Security
{
    public class AuthTicket : Contracts.AppDev.AuthTicket
    {
        public AuthenticationScope AuthenticationScope { get; set; }
        public int? SiteId { get; set; }
        public int? TenantId { get; set; }
    }
}
