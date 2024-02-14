using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
