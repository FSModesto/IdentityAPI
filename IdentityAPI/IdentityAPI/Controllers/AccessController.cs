using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController : ControllerBase
    {
        [Authorize(Policy = "MinimumAge")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Access Allowed!");
        }
    }
}
