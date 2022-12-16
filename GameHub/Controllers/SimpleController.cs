using Microsoft.AspNetCore.Mvc;

namespace GameHub.Controllers
{
    public class SimpleController : Controller
    {
        public IActionResult Index()
        {
            // show message including the current date
            ViewData["Message"] = "Today is " + DateTime.Today.ToString();

            // old code - works but not as good because the view name is implied but not stated explicitly
            //return View();
            
            // new code - better because it's much clearer what the outcome should be
            return View("Index");
        }

        public IActionResult UncoveredMethod()
        {
            return View();
        }
    }
}
