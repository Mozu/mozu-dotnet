using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mozu.Api.Logging;

namespace Mozu.Api.Security
{
    public class RefreshInterval
    {
        public RefreshInterval(long accessTokenExpirationInterval, long refreshTokenExpirationInterval)
        {

            AccessTokenExpirationInterval = accessTokenExpirationInterval;
            RefreshTokenExpirationInterval = refreshTokenExpirationInterval;
            UpdateExpirationDates(true);
        }

        public long AccessTokenExpirationInterval { get; protected set; }
        public long RefreshTokenExpirationInterval { get; protected set; }
        public DateTime AccessTokenExpiration { get; protected set; }
        public DateTime RefreshTokenExpiration { get;  set; }


        public void UpdateExpirationDates(bool updateRefreshTokenInterval)
        {
           AccessTokenExpiration = DateTime.Now.AddSeconds(AccessTokenExpirationInterval);
           if (updateRefreshTokenInterval)
               RefreshTokenExpiration = DateTime.Now.AddSeconds(RefreshTokenExpirationInterval);
        }
    }
}
