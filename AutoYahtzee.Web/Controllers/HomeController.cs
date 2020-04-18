using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoYahtzee.Business;
using AutoYahtzee.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoYahtzee.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ThrowManager _throwManager;
        public HomeController(ThrowManager throwManager)
        {
            _throwManager = throwManager;
        }
        public IActionResult Index([FromQuery]int page = 1)
        {
            var vm = _throwManager.GetThrowListViewModel(page);
            return View(vm);
        }

        [Route("/details/{id}")]
        public IActionResult Details(Guid id)
        {
            var vm = _throwManager.GetThrowDetails(id);
            return View(vm);
        }

        [Route("/contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [Route("/code")]
        public IActionResult Code()
        {
            return View("Code");
        }

        [Route("/stats")]
        public IActionResult Stats()
        {
            return View("Stats");
        }
    }
}