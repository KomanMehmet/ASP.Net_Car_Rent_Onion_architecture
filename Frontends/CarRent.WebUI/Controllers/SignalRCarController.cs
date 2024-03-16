using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
