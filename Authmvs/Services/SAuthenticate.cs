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

        public string GenerateToken(int id, string username)
        {

            var secretkey = this.config.GetSection("settings").GetSection("secretkey").ToString();

            if (string.IsNullOrEmpty(secretkey))
            {


                throw new InvalidOperationException("secretkey not config or not found.");
            }


            if (id == 0 || string.IsNullOrEmpty(username))
            {

                throw new ArgumentException("username is empty.");
            }


            var tokenHandler = new JwtSecurityTokenHandler();

            var keyBytes = Encoding.ASCII.GetBytes(secretkey);


            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, id.ToString()));

            claims.AddClaim(new Claim(ClaimTypes.Name, username));


            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = claims,

                Issuer = "backend",

                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            // return the token
            return tokenHandler.WriteToken(token);
        }

        public User ValidateUser(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {

                throw new Exception("Please check");

            }
            else
            {

                User? validatedUser = _DataContext.Users.FirstOrDefault(x => x.UserMail == user && x.UserPassword == password);
                if (validatedUser != null)
                {
                    return validatedUser;
                }
                else
                {
                    throw new Exception("User  not found");
                }

            }
        }
    }
}