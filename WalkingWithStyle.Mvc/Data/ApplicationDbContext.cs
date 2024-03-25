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

        // DbSet for Users-table
        public DbSet<Users> Users { get; set; }

        // DbSet for Customers-table
        public DbSet<Customers> Customers { get; set; }

        // DbSet for Orders-table
        //public DbSet<Orders> Orders { get; set; }

        //// DbSet for ShoppingCart-table
        //public DbSet<ShoppingCart> ShoppingCart { get; set; }

        //// DbSet for OrderDetails-table
        //public DbSet<OrderDetails> OrderDetails { get; set; }

        //// DbSet for Products-table
        //public DbSet<Products> Products { get; set; }

        //// DbSet for ForumThreads-table
        //public DbSet<ForumThreads> ForumThreads { get; set; }

        //// DbSet for ForumPosts-table
        //public DbSet<ForumPosts> ForumPosts { get; set; }


    }

    public class Customers
    {
    }
}
