using System;
using System.Globalization;
using System.Security.Claims;
using System.Security.Principal;

namespace Coop.Models
{
    public static class TicketManager
    {
        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var claim = identity as ClaimsIdentity;
            if (claim != null)
            {
                var id = claim.FindFirst(ClaimTypes.NameIdentifier);
                if (id != null)
                {
                    return (T)Convert.ChangeType(id.Value, typeof(T), CultureInfo.InvariantCulture);
                }
            }
            return default(T);
        }
        public static string GetUserRole(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var claim = identity as ClaimsIdentity;
            string role = "";
            if (claim != null)
            {
                var claimRole = claim.FindFirst(ClaimsIdentity.DefaultRoleClaimType);
                if (claimRole != null)
                    role = claimRole.Value;
            }
            return role;
        }
    }
}