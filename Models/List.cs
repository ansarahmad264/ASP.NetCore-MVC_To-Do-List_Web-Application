namespace To_Do_List.Models
{
    public class List
    {
        public int Id { get; set; }

        public int UserId { get; set; }          // Foreign Key
        public User User { get; set; }           // Navigation property

        public string Title { get; set; }
        public DateOnly Creation_Date { get; set; }

        public ICollection<Task> Tasks { get; set; } = new List<Task>(); // Navigation to Tasks
    }
}
