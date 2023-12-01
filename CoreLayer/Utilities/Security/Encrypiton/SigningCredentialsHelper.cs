using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace CoreLayer.Utilities.Security.Encrypiton
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
