namespace To_Do_List.Models
{
	public interface IUserRepository
	{
		public bool AddUser(User user);
        //public User? ValidateUser(User user);
        public User? ValidateUser(string email, string pass);
    }
}
