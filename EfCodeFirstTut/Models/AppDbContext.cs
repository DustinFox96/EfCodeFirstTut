using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCodeFirstTut.Models {

    public class AppDbContext : DbContext  {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Orderline> orderlines { get; set; }

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder .IsConfigured) {
                var connStr = "server=localhost\\sqlexpress;" +
                                "database=AppDb1;" +
                                "trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Customer>(cust => {
                cust.HasIndex(x => x.Code).IsUnique(true); // this is creating a unique index for code, meaning every entry for code will need to have or hold a unique value.
            });
        }
    }
}
