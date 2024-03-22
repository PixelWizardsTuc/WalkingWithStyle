using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using WalkingWithStyle.Mvc.Models;

namespace WalkingWithStyle.Mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet för Users-tabellen
        public DbSet<Users> Users { get; set; }

        // DbSet för Customers-tabellen
        public DbSet<Customers> Customers { get; set; }

        // DbSet för Orders-tabellen
        public DbSet<Orders> Orders { get; set; }

        // DbSet för ShoppingCart-tabellen
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        // DbSet för OrderDetails-tabellen
        public DbSet<OrderDetails> OrderDetails { get; set; }

        // DbSet för Products-tabellen
        public DbSet<Products> Products { get; set; }

        // DbSet för ForumThreads-tabellen
        public DbSet<ForumThreads> ForumThreads { get; set; }

        // DbSet för ForumPosts-tabellen
        public DbSet<ForumPosts> ForumPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguration för primärnycklar
            modelBuilder.Entity<Users>().HasKey(u => u.UserID);
            modelBuilder.Entity<Customers>().HasKey(c => c.UserID);
            modelBuilder.Entity<Orders>().HasKey(o => o.OrderID);
            modelBuilder.Entity<ShoppingCart>().HasKey(s => s.CartID);
            modelBuilder.Entity<OrderDetails>().HasKey(od => od.ODID);
            modelBuilder.Entity<Products>().HasKey(p => p.ProductID);

        }
    }

    public class Customers
    {
    }
}
