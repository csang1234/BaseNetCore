using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CtrlShiftH.Helper
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }

        private static JwtSecurityToken HandlingToken(string jwt)
        {
            if (jwt.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                jwt = Regex.Replace(jwt.ToString(), "Bearer ", string.Empty, RegexOptions.IgnoreCase);
            }

            var handler = new JwtSecurityTokenHandler();

            return handler.ReadJwtToken(jwt);
        }

        public static string GetUsername(string jwt)
        {
            try
            {
                var token = HandlingToken(jwt);

                var username = token.Claims.First(claim => claim.Type == "Username").Value;
                return username;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }

}
