using Microsoft.AspNetCore.Mvc;

namespace Mission06_Corrigan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}