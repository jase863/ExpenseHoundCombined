using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace ExpenseHound.Services
{
    public class AuthService
    {
        private readonly string _secretKey = "fc81305cebbcd49877e5c624cded1f62506ad35d7273bc9a9e036c2215d0JOSE";  
          
        // only for testing
        private readonly string _validUsername = "testuser"; 
        private readonly string _validPassword = "password";


        public bool Authenticate(string username, string password)
        {
            return username == _validUsername && password == _validPassword;
        }

        //to generate the JWT token
        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));  // Using 256-bit key
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "ExpenseHound",
                audience: "ExpenseHoundUsers",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}