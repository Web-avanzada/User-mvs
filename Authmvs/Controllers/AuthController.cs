using Microsoft.AspNetCore.Mvc;
namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase{

        public AuthController(){
            
        }


        [HttpGet]

        public string HelloWorld(){
            return "Hello word ";
        }
    }
}