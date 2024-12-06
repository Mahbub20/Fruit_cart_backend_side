using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Models;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace fruit_cart_backend.Data
{
    public class EComDBContext : DbContext
    {
        public EComDBContext(DbContextOptions<EComDBContext> options) : base(options)
        {
            
        }

        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetails> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<OrderItem>()
            .HasOne(oi=>oi.Order)
            .WithMany(o=>o.OrderItems)
            .HasForeignKey(oi=>oi.OrderId);

            modelBuilder.Entity<OrderItem>()
            .HasOne(oi=>oi.Product)
            .WithMany(p=>p.OrderItems)
            .HasForeignKey(oi=>oi.ProductId);
        }
    }
}