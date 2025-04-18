using System.ComponentModel.DataAnnotations;

namespace To_Do_List.ViewModels
{
    public class TaskViewModel
    {
        public int ListId { get; set; }          // Foreign key

        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
