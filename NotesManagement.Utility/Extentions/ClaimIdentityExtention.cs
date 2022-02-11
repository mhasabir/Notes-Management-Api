using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NotesManagement.Utility.Extentions
{
    public static class ClaimIdentityExtention
    {
        public static int GetUserIdFromClaimIdentity(this IPrincipal identity)
        {
            ClaimsIdentity claimsIdentity = identity.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity?.FindFirst("UserId");
            return Convert.ToInt32(claim?.Value);
        }
    }
}
