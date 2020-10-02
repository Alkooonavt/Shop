using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Shop.Domain.DataAccess
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Comment> Coments { get; set; }
        public DbSet<ShopingCartItem> ShopingCart { get; set; }
    }
}
