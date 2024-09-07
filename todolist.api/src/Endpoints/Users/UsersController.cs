
using Microsoft.AspNetCore.Mvc;

namespace src.Endpoints.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public UsersController()
        {
            
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is an action");
        }
    }

    
}