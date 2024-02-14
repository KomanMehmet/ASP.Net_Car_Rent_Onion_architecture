using CarRent.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarRent.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
