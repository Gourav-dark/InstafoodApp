using InstafoodApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstafoodApp.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .Property(x => x.UserId)
                .HasValueGenerator<CustomIdValueGenerator>()
                .IsRequired();
            modelBuilder.Entity<Order>()
                .Property(x => x.OrderId)
                .HasValueGenerator<CustomIdValueGenerator>()
                .IsRequired();

            modelBuilder.Entity<CartItem>().HasKey(x => new { x.CustomerId, x.ProductId });
            modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderId, x.ProductId });
            modelBuilder.Entity<User>().Property(x => x.Email).IsUnicode(true);
            modelBuilder.Entity<User>().Property(x => x.Role).HasDefaultValue("Customer");

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { OrderStatusId = 1, Status = "Placed" },
                new OrderStatus { OrderStatusId = 2, Status = "Accepted and Preparing" },
                new OrderStatus { OrderStatusId = 3, Status = "Declined" },
                new OrderStatus { OrderStatusId = 4, Status = "Cancelled" },
                new OrderStatus { OrderStatusId = 5, Status = "Out of Delivery" },
                new OrderStatus { OrderStatusId = 6, Status = "Delivered" }
                );
            modelBuilder.Entity<Order>().Property(x => x.OrderStatusId).HasDefaultValue(1).IsRequired();
        }
        public class CustomIdValueGenerator : ValueGenerator<string>
        {
            public override bool GeneratesTemporaryValues => false;

            public override string Next(EntityEntry entry)
            {
                return Guid.NewGuid().ToString().Substring(0, 8);
            }
        }
    }
}
