using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v = "aaaa";
            TempData["Value"] = v;

            return View();
        }
    }
}
