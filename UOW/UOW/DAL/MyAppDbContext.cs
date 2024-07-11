using Microsoft.EntityFrameworkCore;
using UOW.Models;

namespace UOW.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
    }
}
