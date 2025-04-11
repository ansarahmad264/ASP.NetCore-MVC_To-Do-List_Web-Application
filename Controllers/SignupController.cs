using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
	public class SignupController : Controller
	{
		private readonly IUserRepository _userRepository;

		public SignupController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(User user)
		{
			
			if (ModelState.IsValid == true)
			{
				bool result = _userRepository.AddUser(user);

				if (!result)
				{ 
					ModelState.AddModelError("", "The Email you entered is already registered");
					return View(user);
				}
				
				return RedirectToAction("Index", "Login");

			}
			return View(user);
		}
	}
}
