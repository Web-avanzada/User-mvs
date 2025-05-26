using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataDataContext.DataContext;
using Microsoft.IdentityModel.Tokens;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IAuthenticate;

namespace ServicesSAuthenticate.SAuthenticate
{
    public class SAuthenticate : IAuthenticate
    {
        private readonly IConfiguration config;
        private readonly DataContext _DataContext;

        public SAuthenticate(IConfiguration config, DataContext DbContext)
        {
            this.config = config;
            this._DataContext = DbContext;
        }

        public string GenerateToken(int id, int userProfilesId, string username)
        {
            var secretkey = config["settings:secretkey"];

            if (string.IsNullOrEmpty(secretkey))
                throw new InvalidOperationException("secretkey not found in config.");

            if (secretkey.Length < 32)
                throw new InvalidOperationException("secretkey must be at least 32 characters long.");

            var keyBytes = Encoding.ASCII.GetBytes(secretkey); // Puedes usar UTF8 si prefieres

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim("UserProfilesId", userProfilesId.ToString())
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = "backend",
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public (User user, int userProfilesId) ValidateUser(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                throw new Exception("Please check");

            var validatedUser = _DataContext.Users
                .FirstOrDefault(x => x.UserMail == user && x.UserPassword == password);

            if (validatedUser is null)
                throw new Exception("User not found");

            var profile = _DataContext.UserProfiles
                .FirstOrDefault(p => p.UserId == validatedUser.UserId);

            if (profile is null)
                throw new Exception("UserProfile not found");

            return (validatedUser, profile.UserProfilesId);
        }
    }
}
