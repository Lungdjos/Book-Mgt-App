using Book_Mgt_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Mgt_App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
    }
}
