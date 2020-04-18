using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoYahtzee.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error")]
        public IActionResult Error([FromQuery]int code)
        {
            return code == 404 ? View("NotFound") : View("Error");
        }
    }
}