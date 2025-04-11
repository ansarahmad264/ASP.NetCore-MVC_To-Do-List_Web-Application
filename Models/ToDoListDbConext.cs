using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace To_Do_List.Models
{
	public class ToDoListDbConext : IdentityDbContext
	{
		public ToDoListDbConext(DbContextOptions<ToDoListDbConext> options)
			: base(options)
		{
		}
		public DbSet<User> Users {  get; set; }
		public DbSet<List> Lists { get; set; }
		public DbSet<Task> Tasks { get; set; }
	}
}
