using System.ComponentModel.DataAnnotations;
using UserApp.datalayer;

using (var db = new UserApp.datalayer.AppDbContext())
{
    db.Database.EnsureCreated();
    var user = new UserApp.DataLayer.Entities.UserEntity { Name = "user 1", Email = "user1@example.com", PublicId = Guid.NewGuid() };
    db.Users.Add(user);
    db.SaveChanges();
    Console.WriteLine($"User with ID {user.Id} has been saved to the database.");
}
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
