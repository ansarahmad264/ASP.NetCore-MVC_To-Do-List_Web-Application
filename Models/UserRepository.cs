using System;

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
		public User? ValidateUser(string Email, string Password)
		{
			
			if(Email == string.Empty || Password == string.Empty)
			{
				return null;
			}
			var userExist = _toDoListDbConext.Users.
				FirstOrDefault(u => u.Email == Email && u.Password == Password);
            
			return userExist;				
        }
	}
}
