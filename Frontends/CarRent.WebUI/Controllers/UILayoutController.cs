using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
