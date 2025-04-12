namespace To_Do_List.Models
{
    public class Task
    {
        public int Id { get; set; }

        public int ListId { get; set; }          // Foreign key
        public List List { get; set; }           // Navigation to List

        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
