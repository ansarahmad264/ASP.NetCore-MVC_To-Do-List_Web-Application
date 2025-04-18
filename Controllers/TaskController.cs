using Microsoft.AspNetCore.Mvc;
using To_Do_List.Models;
using To_Do_List.ViewModels;

namespace To_Do_List.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public IActionResult AddTask(int listid)
        {
            Console.WriteLine("list it at task controller" +  listid);
            var task = new TaskViewModel
            {
                ListId = listid,
                IsCompleted = false
            };
            return View(task);
        }

        [HttpPost]
        public IActionResult AddTask(ViewModels.TaskViewModel taskViewModel)
        {
            
            if (!ModelState.IsValid)
            {
                return View(taskViewModel);
            }

            var task = new Models.Task
            {
                Description = taskViewModel.Description,
                DueDate = taskViewModel.DueDate,
                ListId = taskViewModel.ListId,
                IsCompleted = false
            };

            _taskRepository.AddTask(task);
            return RedirectToAction("ListDetails", "List", new { id = task.ListId });

        }
    }
}
