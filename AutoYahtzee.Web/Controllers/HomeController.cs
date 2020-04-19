using System;
using System.Threading.Tasks;
using AutoYahtzee.Business;
using AutoYahtzee.Business.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AutoYahtzee.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ThrowManager _throwManager;
        private readonly SendGridManager _sendgridManager;
        public HomeController(ThrowManager throwManager, SendGridManager sendgridManager)
        {
            _throwManager = throwManager;
            _sendgridManager = sendgridManager;
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

        [Route("/contact")]
        [HttpPost]
        public async Task<IActionResult> Contact(ContactEntry contactEntry)
        {
            string result = String.Empty;

            if(ModelState.IsValid)
            {
                result = await _sendgridManager.SendEmail(contactEntry) ? "SUCCESS" : "FAIL";  
            }
            else
            {
                return BadRequest();
            }

            return View("Contact", result);
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

        [Route("/hardware")]
        public IActionResult Hardware()
        {
            return View("Hardware");
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View("About");
        }
    }
}