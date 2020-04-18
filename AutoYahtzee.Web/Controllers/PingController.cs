using Microsoft.AspNetCore.Mvc;

namespace AutoYahtzee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        public IActionResult Ping()
        {
            return new OkResult();
        }
    }
}