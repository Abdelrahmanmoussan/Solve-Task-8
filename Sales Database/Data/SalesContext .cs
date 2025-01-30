using Microsoft.EntityFrameworkCore;
using Sales_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Database.Data
{
    internal class SalesContext : DbContext
    {


        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=MOUSSAN\\MSSQLSERVERS;Initial Catalog=SalesDatabase;Integrated Security=True;TrustServerCertificate=True");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Product Class 
            modelBuilder.Entity<Product>()
                .Property(n => n.Name)
                .HasColumnType("varchar(100)")
                .IsUnicode(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasDefaultValue("No description");


            //Customer Class
            modelBuilder.Entity<Customer>()
                .Property(n => n.Name)
                .HasColumnType("varchar(80)")
                .IsUnicode (true);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .HasColumnType("varchar(100)")
                .IsUnicode (false);


            //Store Class
            modelBuilder.Entity<Store>()
                .Property(n => n.Name)
                .HasColumnType("varchar(80)")
                .IsUnicode (true);


            //Sale Class
            modelBuilder.Entity<Sale>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale>()
                .HasOne(st => st.Store)
                .WithMany() 
                .HasForeignKey(st =>  st.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");


        }
    }
    }
