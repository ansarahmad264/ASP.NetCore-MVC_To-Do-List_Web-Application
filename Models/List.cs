namespace To_Do_List.Models
{
	public class List
	{
		public int Id { get; set; }
		public User user_Id { get; set; }
		public string Title { get; set; }
		public DateOnly Creation_Date { get; set; }
	}
}
