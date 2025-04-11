using Microsoft.AspNetCore.Mvc;

namespace To_Do_List.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.UserName = HttpContext.Session.GetString("userName");
			if(ViewBag.UserName == null)
			{
				return RedirectToAction("Index", "Login");
			}
			return View();
		}
	}
}
