using Microsoft.AspNetCore.Mvc;

namespace ServiceOdata.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
