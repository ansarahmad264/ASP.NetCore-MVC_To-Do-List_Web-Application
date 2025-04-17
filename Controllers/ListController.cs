using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.ViewModels;

namespace To_Do_List.Controllers
{
    public class ListController : Controller
    {
        private readonly IListRepository _listRepository;
        public ListController(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }
        
        public IActionResult NewListDetails()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult NewListDetails(ListViewModel listViewModel)
        {
            var userId = HttpContext.Session.GetInt32("userId");

            var list = new List
            {
                Title = listViewModel.Title,
                UserId = userId.Value
            };

            bool result = _listRepository.CreateList(list);

            if (!result)
            {
                ModelState.AddModelError("", "This User Doesnot Exist!");
                return View(listViewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
