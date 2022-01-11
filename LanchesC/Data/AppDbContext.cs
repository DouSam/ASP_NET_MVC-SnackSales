using LanchesC.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Snack> Snacks { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
