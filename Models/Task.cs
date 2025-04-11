namespace To_Do_List.Models
{
	public class Task
	{
		public int Id { get; set; }
		public List list_Id { get; set; }
		public string description { get; set; }
		public DateTime dueDate { get; set; }
		public bool IsCompleted { get; set; }
	}
}
