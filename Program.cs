using To_Do_List.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString
    ("ToDoListDbContextConnection") ?? throw new InvalidOperationException
    ("Connection String 'ToDoListDbContextConnection' not found");

// Add services to the container.
builder.Services.AddDbContext<ToDoListDbConext>(options =>
options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ToDoListDbConext>();

builder.Services.AddDbContext<ToDoListDbConext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ToDoListDbContextConnection"]);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
