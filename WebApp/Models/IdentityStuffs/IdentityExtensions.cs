using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtensions
    {


        public static string GetCurrentUserName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Name);

            return claim.Value ?? string.Empty;
        }

        public static string GetCurrentUserID(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst("UserID");

            if (claim != null)
            {
                return claim.Value ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
        public static string GetCurrentStoreID(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst("StoreID");

            if (claim != null)
            {
                return claim.Value ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }



        }
    }
}