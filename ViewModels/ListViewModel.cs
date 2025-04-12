using System.ComponentModel.DataAnnotations;

namespace To_Do_List.ViewModels
{
    public class ListViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
