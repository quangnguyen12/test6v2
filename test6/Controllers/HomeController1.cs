using Microsoft.AspNetCore.Mvc;

namespace test6.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
