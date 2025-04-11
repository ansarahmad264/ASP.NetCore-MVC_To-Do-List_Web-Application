using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.ViewModels;

namespace To_Do_List.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserRepository _userRepository;
		public LoginController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(LoginViewModel login)
		{
			if (!ModelState.IsValid)
			{
				return View(login);
			}

            var user = new User
            {
                Email = login.Email,
                Password = login.Password
            };

            var userName = _userRepository.ValidateUser(user);

			if (string.IsNullOrEmpty(userName))
			{
				ModelState.AddModelError("", "Invalid Email or Password!");
				return View(login);
			}

			HttpContext.Session.SetString("userName", userName);
			return RedirectToAction("Index", "Home");

		}
	}
}
