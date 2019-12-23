using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Data
{
    public class mvcdemo: DbContext
    {
        public mvcdemo()
            :base()
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<SaleInvoiceHeader> SaleInvoiceHeaders { get; set; }
        public DbSet<SaleInvoiceLine> SaleInvoiceLines { get; set; }
        public DbSet<Invoice> invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   //primary key

            modelBuilder.Entity<Customer>().HasKey<int>(c => c.CustomerId);
            
                 modelBuilder.Entity<Customer>()
                .Property(a => a.CustomerName)
                .HasColumnName("Name")
                .HasMaxLength(20)
                .IsConcurrencyToken();

            modelBuilder.Entity<Customer>()
                .Property(a => a.Address)
                .HasColumnName("Address Line")
                //.HasColumnName("Address Line-2")
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(a => a.City);

            modelBuilder.Entity<Item>().HasKey<int>(c => c.ItemId);

            modelBuilder.Entity<Item>()
                .Property(a => a.ItemName)
                .HasColumnOrder(1);

            modelBuilder.Entity<Unit>().HasKey<int>(c => c.UnitId);

            modelBuilder.Entity<Unit>()
                .Property(a => a.UnitName)
                .HasColumnOrder(4);
                            
             modelBuilder.Entity<SaleInvoiceHeader>().HasKey<int>(c => c.SaleId);

            modelBuilder.Entity<SaleInvoiceHeader>()
                .Property(a => a.SaleDate)
                .HasColumnName("Date"); 
            
            modelBuilder.Entity<SaleInvoiceHeader>()
                .Property(a => a.InvoiceNo);

            modelBuilder.Entity<SaleInvoiceLine>().HasKey<int>(c => c.SaleLineId);

            modelBuilder.Entity<SaleInvoiceLine>()
                .Property(a => a.Qty)
                .HasColumnName("Quantity")
                .HasColumnOrder(2)
                .HasPrecision(2, 2);

            modelBuilder.Entity<SaleInvoiceLine>()
                .Property(a => a.Rate)
                .HasColumnOrder(3)
                .HasPrecision(2, 2);


          //  modelBuilder.Entity<SaleInvoiceHeader>()
            //.HasRequired(c => c.SaleId)
            //.WithMany(p => p.SaleInvoiceHeader)
            //.HasForeignKey(c => c.SaleId);

            

        }

        public System.Data.Entity.DbSet<mvcdemo.Models.Invoice> Invoices { get; set; }
    }
}