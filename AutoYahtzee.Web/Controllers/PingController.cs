using AutoYahtzee.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AutoYahtzee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly AutoYahtzeeContext _ctx;
        public PingController(AutoYahtzeeContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Ping()
        {
            return new ContentResult()
            {
                Content = _ctx.Throws.Count().ToString()
            };
        }
    }
}