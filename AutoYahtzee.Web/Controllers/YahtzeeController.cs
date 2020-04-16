using AutoYahtzee.Business;
using Microsoft.AspNetCore.Mvc;

namespace AutoYahtzee.Web.Controllers
{
    public class YahtzeeController : Controller
    {

        private readonly ThrowManager _throwManager;

        public YahtzeeController(ThrowManager throwManager)
        {
            _throwManager = throwManager;
        }

        public IActionResult Index()
        {
            var data = _throwManager.GetYahtzeeListViewModel();
            return View(data);
        }
    }
}