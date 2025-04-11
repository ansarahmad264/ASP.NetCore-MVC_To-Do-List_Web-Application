namespace To_Do_List.Models
{
	public class UserRepository : IUserRepository
	{
		private readonly ToDoListDbConext _toDoListDbConext;

		public UserRepository(ToDoListDbConext toDoListDbConext)
		{
			_toDoListDbConext = toDoListDbConext;
		}

		public bool AddUser(User user)
		{
			var userinfo = user;

			if(userinfo == null)
			{
				return false;
			}

			bool emailExist =_toDoListDbConext.Users
				.Any(u => u.Email.ToLower() == user.Email.ToLower());

			if (emailExist)
			{
				return false;
			}

			_toDoListDbConext.Users.Add(userinfo);
			_toDoListDbConext.SaveChanges();

			return true;
		}
		public string? ValidateUser(User user)
		{
			if (user == null)
				return null;

			var userExist = _toDoListDbConext.Users.
				FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

			return userExist?.Name;				
        }
	}
}
