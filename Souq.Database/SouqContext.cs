using Microsoft.EntityFrameworkCore;
using Souq.Models;
using System;

namespace Souq.Database
{
    public class SouqContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=.;Database=Souq;Trusted_Connection=True;");
        //}
        public SouqContext(DbContextOptions<SouqContext> options)
       : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
