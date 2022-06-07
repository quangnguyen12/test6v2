using Microsoft.AspNetCore.Mvc;

namespace test6.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
