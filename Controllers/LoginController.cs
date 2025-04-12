using Microsoft.AspNetCore.Http;
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

            /* var tempUser = new User
             {
                 Email = login.Email,
                 Password = login.Password
             };

             var user = _userRepository.ValidateUser(tempUser);*/

            var user = _userRepository.ValidateUser(login.Email, login.Password);

            if (user == null)
			{
				ModelState.AddModelError("", "Invalid Email or Password!");
				return View(login);
			}

            HttpContext.Session.SetString("userName", user.Name);
            HttpContext.Session.SetInt32("userId", user.Id);
            return RedirectToAction("Index", "Home");

		}
	}
}
