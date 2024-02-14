using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
