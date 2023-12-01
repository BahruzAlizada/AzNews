using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoreLayer.Utilities.Security.Encrypiton
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
