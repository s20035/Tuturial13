using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracTest_Tut13.Entities
{
    public class MyDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<Confectionery_Order> Confectionery_Orders { get; set; }
        public MyDbContext() { }

        public MyDbContext(DbContextOptions options) :base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.Property(e => e.IdClient).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(60);

                entity.HasMany(e => e.Orders)
                      .WithOne(e => e.Customer)
                      .HasForeignKey(e => e.IdClient)
                      .IsRequired();

                entity.ToTable("Customer");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmpl);
                entity.Property(e => e.IdEmpl).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Surname).HasMaxLength(60);

                entity.HasMany(e => e.Orders)
                      .WithOne(e => e.Employee)
                      .HasForeignKey(e => e.IdEmpl)
                      .IsRequired();

                entity.ToTable("Employee");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.Property(e => e.IdOrder).ValueGeneratedOnAdd();
                entity.Property(e => e.Notes).HasMaxLength(255);

                entity.HasOne(e => e.Confectionery_Order).WithOne(e => e.Order);

                entity.ToTable("Order");
            });

            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfection);
                entity.Property(e => e.IdConfection).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(200);
                entity.Property(e => e.Type).HasMaxLength(40);

                entity.HasOne(e => e.Confectionery_Order).WithOne(e => e.Confectionery);

                entity.ToTable("Confectionery");
            });

            modelBuilder.Entity<Confectionery_Order>(entity =>
            {
                entity.HasKey(e => new { e.IdConfection, e.IdOrder });
                entity.Property(e => e.Notes).HasMaxLength(255);

                //entity.HasOne(e => e.Confectionery).WithOne(e => e.Confectionery_Order);
                //entity.HasOne(e => e.Order).WithOne(e => e.Confectionery_Order);

                entity.ToTable("Confectionery_Order");
            });

            modelBuilder.Entity<Order>().HasData(
                new Order { IdOrder= 23,DateAccepted = DateTime.Parse("12-12-2019"), Notes = "Notes for order" }
                );
            modelBuilder.Entity<Confectionery>().HasData(
                new Confectionery {IdConfection=234, Name="Confectionery Name",PricePerite=234.43,Type="Confectionert Type"}
                );
            modelBuilder.Entity<Confectionery_Order>().HasData(
                new Confectionery_Order { IdConfection=234,IdOrder=23, Quantity=4,Notes="Confectionery Order Notes"}
                );
        }
    }
}
