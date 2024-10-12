 
using Microsoft.AspNetCore.Mvc;
 
namespace Macondo.Api.Controller
{
 [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/test
        [HttpGet]
        public IActionResult Get()
        {
            // Breakpoint را اینجا قرار دهید
            return Ok("Debugging works!");
        }
    }
}