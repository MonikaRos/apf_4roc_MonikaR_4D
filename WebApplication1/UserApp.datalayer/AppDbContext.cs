using Microsoft.EntityFrameworkCore;
using UserApp.DataLayer.Entities;   


namespace UserApp.datalayer
{
    public class AppDbContext : DbContext

    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=userApp.db");
        }

    }
}
