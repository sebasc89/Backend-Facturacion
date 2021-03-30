using DigitalWare.Facturacion.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Facturacion.Infrastructure.Database.Context
{
    public class FacturacionContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public FacturacionContext() { }

        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrderId, o.ProductId });

            modelBuilder.Entity<OrderDetail>()
           .HasOne(x => x.Order)
           .WithMany(x => x.OrderDetail)
           .HasForeignKey(x => x.OrderId)
           .HasPrincipalKey(x => x.OrderId);

            modelBuilder.Entity<OrderDetail>()
          .HasOne(x => x.Product)
          .WithMany(x => x.OrderDetail)
          .HasForeignKey(x => x.ProductId)
          .HasPrincipalKey(x => x.ProductId);


        }
    }
}
