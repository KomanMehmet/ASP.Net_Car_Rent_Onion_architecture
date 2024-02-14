using Microsoft.AspNetCore.Mvc;

namespace CarRent.WebUI.ViewComponents.AboutViewComponents
{
	public class _BecomeADriverComponentPartial : ViewComponent
	{

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
