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

            _toDoListDbConext.Tasks.Add(task);
            _toDoListDbConext.SaveChanges();

            return true;

        }

        public Task? GetTaskById(int id)
        {
            return _toDoListDbConext.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public bool UpdateTask(Task task)
        {
            var existingTask = _toDoListDbConext.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask == null) return false;

            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.ListId = task.ListId;

            _toDoListDbConext.SaveChanges();
            return true;
        }
    }
}
