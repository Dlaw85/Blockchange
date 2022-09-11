using Microsoft.AspNetCore.Mvc;

namespace WellaMvc.Controllers
{

    public class AboutController : Controller
    {

        public IActionResult Index()
        {
           return View();
        }
    }
}
