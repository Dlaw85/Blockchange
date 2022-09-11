using Microsoft.EntityFrameworkCore;
using WellaMvc.Models;


namespace WellaMvc.DatabaseContext
{


    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserData> UserDataTable { get; set; }

    }
}