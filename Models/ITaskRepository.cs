namespace To_Do_List.Models
{
    public interface ITaskRepository
    {
        public bool AddTask(Task task);
        public Task? GetTaskById(int id);

        public bool UpdateTask(Task task);
    }
}
