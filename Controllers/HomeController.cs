﻿using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.ViewModels;

namespace To_Do_List.Controllers
{
	public class HomeController : Controller
	{
		private readonly IListRepository _listRepository;
		public HomeController(IListRepository listRepository)
		{
			_listRepository = listRepository;
		}
		public IActionResult Index()
		{
			ViewBag.UserName = HttpContext.Session.GetString("userName");
			var userId = HttpContext.Session.GetInt32("userId");

            if (ViewBag.UserName == null || userId == null)
			{
				return RedirectToAction("Index", "Login");
			}

			var lists = _listRepository.GetAllList(userId.Value);
			return View(lists);
		}
	}
}
