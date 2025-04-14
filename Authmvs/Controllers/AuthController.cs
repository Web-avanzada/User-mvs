using Microsoft.AspNetCore.Mvc;
using ModelsUsers.Users;
using RepositoriesIAuthenticate.IAuthenticate;

namespace ControllersCAuthenticate.CAuthenticate
{
    [ApiController]
    [Route("[controller]")]
    public class CAuthenticateController : ControllerBase
    {
        private readonly IAuthenticate _authenticationUser;
        private readonly User _IUser;
        public CAuthenticateController(IAuthenticate authenticationUser)
        {
            this._authenticationUser = authenticationUser;

        }

        [HttpPost("/userValidate")]
        public IActionResult Validate(User user)
        {
           
            try
            {
                if (user.Username == "" || user.Password == "")
                {
                   
                    return BadRequest("Please enter the data");
                }
                else
                {

                    var UserValidated = this._authenticationUser.ValidateUser(user.Username , user.Password );
                    if (UserValidated == null)
                    {
                        throw new Exception("User Not found");
                    }
                    //Create the token
                    string token = _authenticationUser.GenerateToken(UserValidated.Id, UserValidated.Username);
                    return Ok(token);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}