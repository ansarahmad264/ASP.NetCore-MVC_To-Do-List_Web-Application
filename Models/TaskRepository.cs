using To_Do_List.ViewModels;
using To_Do_List.Views.Task;

namespace To_Do_List.Models
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListDbConext _toDoListDbConext;

        public TaskRepository(ToDoListDbConext toDoListDbConext)
        {
            _toDoListDbConext = toDoListDbConext;
        }

        public bool AddTask(Task task)
        {
            var listId = task.ListId;
            Console.WriteLine("List Id at Add Task Repository:" + listId);

            task.IsCompleted = false;

            _toDoListDbConext.Tasks.Add(task);
            _toDoListDbConext.SaveChanges();

            return true;

        }
    }
}
