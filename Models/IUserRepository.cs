namespace To_Do_List.Models
{
	public interface IUserRepository
	{
		public bool AddUser(User user);
		public String? ValidateUser(User user);
	}
}
