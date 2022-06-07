using Microsoft.AspNetCore.Mvc;

namespace test6.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
